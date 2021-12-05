namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// CriteriaController class, provides endpoints to manage criterias.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/criterias")]
[Route("[area]/criterias")]
public class CriteriaController : ControllerBase
{
    #region Variables
    private readonly ICriteriaService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an CriteriaController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Criteria service object</param>
    /// <param name="mapper">Mapster object</param>
    public CriteriaController(ICriteriaService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the criterias.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var criterias = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<CriteriaModel[]>(criterias));
    }

    /// <summary>
    /// Get the criteria for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var criteria = _dbService.Find(id);

        if (criteria == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<CriteriaModel>(criteria));
    }

    /// <summary>
    /// Add a new criteria.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(CriteriaModel model)
    {
        var criteria = _dbService.AddAndSave(_mapper.Map<Criteria>(model));
        return CreatedAtAction(nameof(Get), new { id = criteria.Id }, _mapper.Map<CriteriaModel>(criteria));
    }

    /// <summary>
    /// Update the specified criteria.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(CriteriaModel model)
    {
        var criteria = _dbService.UpdateAndSave(_mapper.Map<Criteria>(model));
        return new JsonResult(_mapper.Map<CriteriaModel>(criteria));
    }

    /// <summary>
    /// Delete the specified criteria.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(CriteriaModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Criteria>(model));
        return new JsonResult(model);
    }
    #endregion
}
