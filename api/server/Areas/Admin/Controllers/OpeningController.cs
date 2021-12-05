namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// OpeningController class, provides endpoints to manage openings.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/openings")]
[Route("[area]/openings")]
public class OpeningController : ControllerBase
{
    #region Variables
    private readonly IOpeningService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an OpeningController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Opening service object</param>
    /// <param name="mapper">Mapster object</param>
    public OpeningController(IOpeningService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the openings.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var openings = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<OpeningModel[]>(openings));
    }

    /// <summary>
    /// Get the opening for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var opening = _dbService.Find(id);

        if (opening == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<OpeningModel>(opening));
    }

    /// <summary>
    /// Add a new opening.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(OpeningModel model)
    {
        var opening = _dbService.AddAndSave(_mapper.Map<Opening>(model));
        return CreatedAtAction(nameof(Get), new { id = opening.Id }, _mapper.Map<OpeningModel>(opening));
    }

    /// <summary>
    /// Update the specified opening.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(OpeningModel model)
    {
        var opening = _dbService.UpdateAndSave(_mapper.Map<Opening>(model));
        return new JsonResult(_mapper.Map<OpeningModel>(opening));
    }

    /// <summary>
    /// Delete the specified opening.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(OpeningModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Opening>(model));
        return new JsonResult(model);
    }
    #endregion
}
