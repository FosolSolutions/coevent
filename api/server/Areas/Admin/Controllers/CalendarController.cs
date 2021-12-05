namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// CalendarController class, provides endpoints to manage calendars.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/calendars")]
[Route("[area]/calendars")]
public class CalendarController : ControllerBase
{
    #region Variables
    private readonly ICalendarService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an CalendarController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Calendar service object</param>
    /// <param name="mapper">Mapster object</param>
    public CalendarController(ICalendarService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the calendars.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var calendars = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<CalendarModel[]>(calendars));
    }

    /// <summary>
    /// Get the calendar for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(int id)
    {
        var calendar = _dbService.Find(id);

        if (calendar == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<CalendarModel>(calendar));
    }

    /// <summary>
    /// Add a new calendar.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(CalendarModel model)
    {
        var calendar = _dbService.AddAndSave(_mapper.Map<Calendar>(model));
        return CreatedAtAction(nameof(Get), new { id = calendar.Id }, _mapper.Map<CalendarModel>(calendar));
    }

    /// <summary>
    /// Update the specified calendar.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(CalendarModel model)
    {
        var calendar = _dbService.UpdateAndSave(_mapper.Map<Calendar>(model));
        return new JsonResult(_mapper.Map<CalendarModel>(calendar));
    }

    /// <summary>
    /// Delete the specified calendar.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(CalendarModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Calendar>(model));
        return new JsonResult(model);
    }
    #endregion
}
