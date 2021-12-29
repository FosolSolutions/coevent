namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using System.Security.Claims;
using Coevent.Api.Authentication;
using Coevent.Api.Models.Tokens;
using Coevent.Core.Extensions;
using CoEvent.Api.Authentication;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// AuthController class, provides endpoints to manage tokens.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/auth")]
[Route("auth")]
public class AuthController : ControllerBase
{
    #region Variables
    private readonly IAuthenticator _authenticator;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new instance of an AuthController object, initializes with specified parameters.
    /// </summary>
    /// <param name="authenticator">DAL service object</param>
    /// <param name="mapper">Mapster object</param>
    public AuthController(IAuthenticator authenticator, IMapper mapper)
    {
        _authenticator = authenticator;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Validate the username and password and authenticate the user.
    /// </summary>
    /// <returns></returns>
    [HttpPost("login")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AuthenticateAsync(LoginModel model)
    {
        return await AccessTokenAsync(new RequestTokenModel() { GrantType = GrantTypes.Password, Username = model.Username, Password = model.Password });
    }

    /// <summary>
    /// Authenticate the participant.
    /// </summary>
    /// <returns></returns>
    [HttpPost("participants/login")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AuthenticateAsync(ParticipantLoginModel model)
    {
        return await AccessTokenAsync(new RequestTokenModel() { GrantType = GrantTypes.AuthorizationCode, Code = model.Key.ToString() });
    }

    /// <summary>
    /// Generate or refresh the access token if the provided credentials are authenticated and authorized.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="SecurityTokenException"></exception>
    /// <exception cref="SecurityTokenExpiredException"></exception>
    [HttpPost("token")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AccessTokenAsync(RequestTokenModel model)
    {
        try
        {
            if (model.GrantType == GrantTypes.Password)
            {
                var user = _authenticator.Validate(model.Username, model.Password);
                var token = await _authenticator.AuthenticateAsync(user);
                return new JsonResult(token);
            }
            else if (model.GrantType == GrantTypes.AuthorizationCode)
            {
                if (Guid.TryParse(model.Code, out Guid key))
                {
                    var user = _authenticator.FindUser(key);
                    if (user == null)
                        return BadRequest("Invalid Participant Key");

                    var token = await _authenticator.AuthenticateAsync(user);
                    return new JsonResult(token);
                }

                return BadRequest("Key is missing or is invalid.");
            }
            else if (model.GrantType == GrantTypes.RefreshToken)
            {
                var id = User.GetClaim(ClaimTypes.NameIdentifier)?.Value ?? throw new SecurityTokenException();
                var key = Guid.Parse(id);
                var user = _authenticator.FindUser(key);

                if (user != null)
                    return new JsonResult(await _authenticator.AuthenticateAsync(user));

                throw new SecurityTokenExpiredException();
            }
            else if (model.GrantType == GrantTypes.ClientCredentials)
            {
                return BadRequest("Client credentials grant not available.");
            }
            else if (model.GrantType == GrantTypes.JWTBearer)
            {
                return BadRequest("JWT bearer assertion grant not available.");
            }
            else if (model.GrantType == GrantTypes.SAML2Bearer)
            {
                return BadRequest("SAML 2.0 bearer assertion grant not available.");
                throw new AuthenticationException();
            }

            return BadRequest("Grant type invalid");
        }
        catch (AuthenticationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get the current authenticated user's information.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="SecurityTokenException"></exception>
    [HttpGet("user/info")]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public IActionResult GetUserInfo()
    {
        var id = User.GetClaim(ClaimTypes.NameIdentifier)?.Value ?? throw new SecurityTokenException();
        var key = Guid.Parse(id);
        var user = _authenticator.FindUser(key);

        if (user == null)
            return BadRequest("User account is missing");

        return new JsonResult(_mapper.Map<UserModel>(user));
    }
    #endregion
}
