namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// ScheduleController class, provides endpoints to manage schedules.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/schedules")]
[Route("[area]/schedules")]
public class ScheduleController : ControllerBase
{
    #region Variables
    private readonly IScheduleService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an ScheduleController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Schedule service object</param>
    /// <param name="mapper">Mapster object</param>
    public ScheduleController(IScheduleService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the schedules.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var schedules = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<ScheduleModel[]>(schedules));
    }

    /// <summary>
    /// Get the schedule for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var schedule = _dbService.Find(id);

        if (schedule == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<ScheduleModel>(schedule));
    }

    /// <summary>
    /// Add a new schedule.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(ScheduleModel model)
    {
        var schedule = _dbService.AddAndSave(_mapper.Map<Schedule>(model));
        return CreatedAtAction(nameof(Get), new { id = schedule.Id }, _mapper.Map<ScheduleModel>(schedule));
    }

    /// <summary>
    /// Update the specified schedule.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(ScheduleModel model)
    {
        var schedule = _dbService.UpdateAndSave(_mapper.Map<Schedule>(model));
        return new JsonResult(_mapper.Map<ScheduleModel>(schedule));
    }

    /// <summary>
    /// Delete the specified schedule.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(ScheduleModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Schedule>(model));
        return new JsonResult(model);
    }
    #endregion
}
