namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// UserController class, provides endpoints to manage users.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/users")]
[Route("[area]/users")]
public class UserController : ControllerBase
{
    #region Variables
    private readonly IUserService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an UserController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">User service object</param>
    /// <param name="mapper">Mapster object</param>
    public UserController(IUserService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var users = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<UserModel[]>(users));
    }

    /// <summary>
    /// Get the user for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var user = _dbService.Find(id);

        if (user == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<UserModel>(user));
    }

    /// <summary>
    /// Add a new user.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(UserModel model)
    {
        var user = _dbService.AddAndSave(_mapper.Map<User>(model));
        return CreatedAtAction(nameof(Get), new { id = user.Id }, _mapper.Map<UserModel>(user));
    }

    /// <summary>
    /// Update the specified user.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(UserModel model)
    {
        var user = _dbService.UpdateAndSave(_mapper.Map<User>(model));
        return new JsonResult(_mapper.Map<UserModel>(user));
    }

    /// <summary>
    /// Delete the specified user.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(UserModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<User>(model));
        return new JsonResult(model);
    }
    #endregion
}
