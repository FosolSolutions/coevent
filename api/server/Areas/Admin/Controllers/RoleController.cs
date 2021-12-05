namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// RoleController class, provides endpoints to manage roles.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/roles")]
[Route("[area]/roles")]
public class RoleController : ControllerBase
{
    #region Variables
    private readonly IRoleService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an RoleController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Role service object</param>
    /// <param name="mapper">Mapster object</param>
    public RoleController(IRoleService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the roles.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var roles = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<RoleModel[]>(roles));
    }

    /// <summary>
    /// Get the role for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var role = _dbService.Find(id);

        if (role == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<RoleModel>(role));
    }

    /// <summary>
    /// Add a new role.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(RoleModel model)
    {
        var role = _dbService.AddAndSave(_mapper.Map<Role>(model));
        return CreatedAtAction(nameof(Get), new { id = role.Id }, _mapper.Map<RoleModel>(role));
    }

    /// <summary>
    /// Update the specified role.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(RoleModel model)
    {
        var role = _dbService.UpdateAndSave(_mapper.Map<Role>(model));
        return new JsonResult(_mapper.Map<RoleModel>(role));
    }

    /// <summary>
    /// Delete the specified role.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(RoleModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Role>(model));
        return new JsonResult(model);
    }
    #endregion
}
