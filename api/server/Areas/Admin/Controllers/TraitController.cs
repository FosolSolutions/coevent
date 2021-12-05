namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// TraitController class, provides endpoints to manage traits.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/traits")]
[Route("[area]/traits")]
public class TraitController : ControllerBase
{
    #region Variables
    private readonly ITraitService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an TraitController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Trait service object</param>
    /// <param name="mapper">Mapster object</param>
    public TraitController(ITraitService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the traits.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var traits = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<TraitModel[]>(traits));
    }

    /// <summary>
    /// Get the trait for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var trait = _dbService.Find(id);

        if (trait == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<TraitModel>(trait));
    }

    /// <summary>
    /// Add a new trait.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(TraitModel model)
    {
        var trait = _dbService.AddAndSave(_mapper.Map<Trait>(model));
        return CreatedAtAction(nameof(Get), new { id = trait.Id }, _mapper.Map<TraitModel>(trait));
    }

    /// <summary>
    /// Update the specified trait.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(TraitModel model)
    {
        var trait = _dbService.UpdateAndSave(_mapper.Map<Trait>(model));
        return new JsonResult(_mapper.Map<TraitModel>(trait));
    }

    /// <summary>
    /// Delete the specified trait.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(TraitModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Trait>(model));
        return new JsonResult(model);
    }
    #endregion
}
