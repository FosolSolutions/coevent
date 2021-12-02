namespace Coevent.Api.Authentication;

using System.Security.Claims;
using System.Text;
using Coevent.Api.Configuration;
using Coevent.Dal.Services.Interfaces;
using Entities = Coevent.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Coevent.Api.Models.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Coevent.Dal.Security;

public class Authenticator : IAuthenticator
{
    #region Variables
    private readonly CoeventAuthenticationOptions _options;
    private readonly byte[] _salt;
    private readonly IUserService _dbService;
    private readonly IHttpContextAccessor _httpContext;
    #endregion

    #region Constructors
    public Authenticator(IOptions<CoeventAuthenticationOptions> options, IUserService dbService, IHttpContextAccessor httpContext)
    {
        _options = options.Value;
        _salt = Encoding.UTF8.GetBytes(_options.Salt ?? throw new InvalidOperationException("Authentication:Secret configuration is required."));
        _dbService = dbService;
        _httpContext = httpContext;
    }
    #endregion

    #region Methods
    public string HashPassword(string password)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: _salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
            ));
    }

    public Entities.User FindUser(string username)
    {
        return _dbService.FindByUsername(username);
    }

    public Entities.User FindUser(Guid key)
    {
        return _dbService.FindByKey(key);
    }

    public Entities.User Validate(string username, string password)
    {
        var user = FindUser(username);
        var hash = HashPassword(password);
        // if (user.Password != hash) throw new InvalidOperationException("Unable to authenticate user.");

        return user;
    }

    public async Task<TokenModel> AuthenticateAsync(Entities.User user)
    {
        var claims = _dbService.GetClaims(user.Id).Select(c => new Claim(c.Name, c.Value, typeof(string).FullName, CoeventIssuer.Account(c.AccountId), CoeventIssuer.OriginalIssuer)).ToList();
        var refreshClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, $"{user.Key}", typeof(string).FullName, CoeventIssuer.Issuer, CoeventIssuer.OriginalIssuer),
            new Claim(CoeventClaimTypes.AccessType, Enum.GetName(user.UserType) ?? String.Empty, typeof(string).FullName, CoeventIssuer.Issuer, CoeventIssuer.OriginalIssuer)
        };
        claims.AddRange(refreshClaims);
        var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
        return await AuthenticationAsync(identity, refreshClaims);
    }

    private async Task<TokenModel> AuthenticationAsync(ClaimsIdentity identity, params Claim[] refreshClaims)
    {
        var accessToken = GenerateJwtToken(new ClaimsPrincipal(identity), _options.AccessTokenExpiresIn);
        var refreshToken = GenerateJwtToken(GeneratePrincipal(JwtBearerDefaults.AuthenticationScheme, refreshClaims), _options.RefreshTokenExpiresIn);

        return await Task.FromResult(new TokenModel(accessToken, _options.AccessTokenExpiresIn, refreshToken, _options.RefreshTokenExpiresIn, _options.DefaultScope));
    }

    private ClaimsPrincipal GeneratePrincipal(string authenticationScheme, params Claim[] claims)
    {
        var identity = new ClaimsIdentity(claims, authenticationScheme);
        return new ClaimsPrincipal(identity);
    }

    private string GenerateJwtToken(ClaimsPrincipal user, TimeSpan expiresIn)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            Subject = user.Identity as ClaimsIdentity,
            Expires = DateTime.UtcNow.Add(expiresIn),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_salt), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    #endregion
}
