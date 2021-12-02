namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// ApplicationController class, provides endpoints to manage applications.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/applications")]
[Route("[area]/applications")]
public class ApplicationController : ControllerBase
{
    #region Variables
    private readonly IApplicationService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an ApplicationController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Application service object</param>
    /// <param name="mapper">Mapster object</param>
    public ApplicationController(IApplicationService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the applications.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var applications = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<ApplicationModel[]>(applications));
    }

    /// <summary>
    /// Get the application for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var application = _dbService.Find(id);

        if (application == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<ApplicationModel>(application));
    }

    /// <summary>
    /// Add a new application.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(ApplicationModel model)
    {
        var application = _dbService.AddAndSave(_mapper.Map<Application>(model));
        return new JsonResult(_mapper.Map<ApplicationModel>(application));
    }

    /// <summary>
    /// Update the specified application.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(ApplicationModel model)
    {
        var application = _dbService.UpdateAndSave(_mapper.Map<Application>(model));
        return new JsonResult(_mapper.Map<ApplicationModel>(application));
    }

    /// <summary>
    /// Delete the specified application.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(ApplicationModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Application>(model));
        return new JsonResult(model);
    }
    #endregion
}
