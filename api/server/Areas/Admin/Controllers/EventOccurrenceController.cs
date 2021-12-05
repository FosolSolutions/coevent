namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// EventOccurrenceController class, provides endpoints to manage events.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/events")]
[Route("[area]/events")]
public class EventOccurrenceController : ControllerBase
{
    #region Variables
    private readonly IEventService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an EventOccurrenceController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Event service object</param>
    /// <param name="mapper">Mapster object</param>
    public EventOccurrenceController(IEventService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all occurrences of the specified 'eventId' within the date range.
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="startOn"></param>
    /// <param name="endOn"></param>
    /// <returns></returns>
    [HttpGet("{eventId}/occurrences")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long eventId, DateTime startOn, DateTime endOn)
    {
        var occurrences = _dbService.GetOccurrences(eventId, startOn, endOn);
        return new JsonResult(_mapper.Map<EventOccurrenceModel[]>(occurrences));
    }

    /// <summary>
    /// Generate event occurrences for the specified 'event'.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}/occurrences")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult GenenerateOccurrences(EventModel model)
    {
        var cevent = _dbService.GenerateOccurrences(_mapper.Map<Event>(model));
        return new JsonResult(_mapper.Map<EventModel>(cevent));
    }
    #endregion
}
