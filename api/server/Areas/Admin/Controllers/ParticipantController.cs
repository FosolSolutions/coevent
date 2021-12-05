namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// ParticipantController class, provides endpoints to manage participants.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/participants")]
[Route("[area]/participants")]
public class ParticipantController : ControllerBase
{
    #region Variables
    private readonly IParticipantService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an ParticipantController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Participant service object</param>
    /// <param name="mapper">Mapster object</param>
    public ParticipantController(IParticipantService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the participants.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var participants = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<ParticipantModel[]>(participants));
    }

    /// <summary>
    /// Get the participant for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var participant = _dbService.Find(id);

        if (participant == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<ParticipantModel>(participant));
    }

    /// <summary>
    /// Add a new participant.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(ParticipantModel model)
    {
        var participant = _dbService.AddAndSave(_mapper.Map<Participant>(model));
        return CreatedAtAction(nameof(Get), new { id = participant.Id }, _mapper.Map<ParticipantModel>(participant));
    }

    /// <summary>
    /// Update the specified participant.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(ParticipantModel model)
    {
        var participant = _dbService.UpdateAndSave(_mapper.Map<Participant>(model));
        return new JsonResult(_mapper.Map<ParticipantModel>(participant));
    }

    /// <summary>
    /// Delete the specified participant.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(ParticipantModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Participant>(model));
        return new JsonResult(model);
    }
    #endregion
}
