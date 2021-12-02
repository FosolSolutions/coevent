namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// ClaimController class, provides endpoints to manage claims.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/claims")]
[Route("[area]/claims")]
public class ClaimController : ControllerBase
{
    #region Variables
    private readonly IClaimService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an ClaimController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Claim service object</param>
    /// <param name="mapper">Mapster object</param>
    public ClaimController(IClaimService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the claims.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var claims = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<ClaimModel[]>(claims));
    }

    /// <summary>
    /// Get the claim for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var claim = _dbService.Find(id);

        if (claim == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<ClaimModel>(claim));
    }

    /// <summary>
    /// Add a new claim.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(ClaimModel model)
    {
        var claim = _dbService.AddAndSave(_mapper.Map<Claim>(model));
        return new JsonResult(_mapper.Map<ClaimModel>(claim));
    }

    /// <summary>
    /// Update the specified claim.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(ClaimModel model)
    {
        var claim = _dbService.UpdateAndSave(_mapper.Map<Claim>(model));
        return new JsonResult(_mapper.Map<ClaimModel>(claim));
    }

    /// <summary>
    /// Delete the specified claim.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(ClaimModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Claim>(model));
        return new JsonResult(model);
    }
    #endregion
}
