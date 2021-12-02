namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// SurveyController class, provides endpoints to manage surveys.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/surveys")]
[Route("[area]/surveys")]
public class SurveyController : ControllerBase
{
    #region Variables
    private readonly ISurveyService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an SurveyController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Survey service object</param>
    /// <param name="mapper">Mapster object</param>
    public SurveyController(ISurveyService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the surveys.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var surveys = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<SurveyModel[]>(surveys));
    }

    /// <summary>
    /// Get the survey for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var survey = _dbService.Find(id);

        if (survey == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<SurveyModel>(survey));
    }

    /// <summary>
    /// Add a new survey.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(SurveyModel model)
    {
        var survey = _dbService.AddAndSave(_mapper.Map<Survey>(model));
        return new JsonResult(_mapper.Map<SurveyModel>(survey));
    }

    /// <summary>
    /// Update the specified survey.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(SurveyModel model)
    {
        var survey = _dbService.UpdateAndSave(_mapper.Map<Survey>(model));
        return new JsonResult(_mapper.Map<SurveyModel>(survey));
    }

    /// <summary>
    /// Delete the specified survey.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(SurveyModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Survey>(model));
        return new JsonResult(model);
    }
    #endregion
}
