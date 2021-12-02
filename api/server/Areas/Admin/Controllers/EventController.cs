namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// EventController class, provides endpoints to manage events.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/events")]
[Route("[area]/events")]
public class EventController : ControllerBase
{
    #region Variables
    private readonly IEventService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an EventController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Event service object</param>
    /// <param name="mapper">Mapster object</param>
    public EventController(IEventService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the events.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var events = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<EventModel[]>(events));
    }

    /// <summary>
    /// Get the event for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var cevent = _dbService.Find(id);

        if (cevent == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<EventModel>(cevent));
    }

    /// <summary>
    /// Add a new event.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(EventModel model)
    {
        var cevent = _dbService.AddAndSave(_mapper.Map<Event>(model));
        return new JsonResult(_mapper.Map<EventModel>(cevent));
    }

    /// <summary>
    /// Update the specified event.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(EventModel model)
    {
        var cevent = _dbService.UpdateAndSave(_mapper.Map<Event>(model));
        return new JsonResult(_mapper.Map<EventModel>(cevent));
    }

    /// <summary>
    /// Delete the specified event.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(EventModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Event>(model));
        return new JsonResult(model);
    }
    #endregion
}
