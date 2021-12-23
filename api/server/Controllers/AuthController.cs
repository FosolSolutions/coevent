namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using System.Security.Claims;
using Coevent.Api.Authentication;
using Coevent.Api.Models.Tokens;
using Coevent.Core.Extensions;
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
        try
        {
            var user = _authenticator.Validate(model.Username, model.Password);
            var token = await _authenticator.AuthenticateAsync(user);
            return new JsonResult(token);
        }
        catch (AuthenticationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Authenticate the participant.
    /// </summary>
    /// <returns></returns>
    [HttpPost("participants/token")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AuthenticateAsync(ParticipantLoginModel model)
    {
        var user = _authenticator.FindUser(model.Key);
        if (user == null)
            return BadRequest("Invalid Participant Key");

        var token = await _authenticator.AuthenticateAsync(user);
        return new JsonResult(token);
    }

    /// <summary>
    /// Refresh the access token if the refresh token is valid.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="SecurityTokenException"></exception>
    /// <exception cref="SecurityTokenExpiredException"></exception>
    [HttpPost("token/refresh")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> RefreshTokenAsync()
    {
        var id = User.GetClaim(ClaimTypes.NameIdentifier)?.Value ?? throw new SecurityTokenException();
        var key = Guid.Parse(id);
        var user = _authenticator.FindUser(key);

        if (user != null)
            return new JsonResult(await _authenticator.AuthenticateAsync(user));

        throw new SecurityTokenExpiredException();
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
