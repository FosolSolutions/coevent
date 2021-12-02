namespace Coevent.Api.Areas.Admin.Controllers;

using System.Net.Mime;
using Coevent.Api.Areas.Admin.Models;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// AccountController class, provides endpoints to manage accounts.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion("1.0")]
[Area("admin")]
[Route("v{version:apiVersion}/[area]/accounts")]
[Route("[area]/accounts")]
public class AccountController : ControllerBase
{
    #region Variables
    private readonly IAccountService _dbService;
    private readonly IMapper _mapper;
    #endregion


    #region Constructors
    /// <summary>
    /// Creates a new instance of an AccountController object, initializes with specified parameters.
    /// </summary>
    /// <param name="dbService">Account service object</param>
    /// <param name="mapper">Mapster object</param>
    public AccountController(IAccountService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }
    #endregion

    #region Endpoints
    /// <summary>
    /// Get all the accounts.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get()
    {
        var accounts = _dbService.FindAllNoTracking();
        return new JsonResult(_mapper.Map<AccountModel[]>(accounts));
    }

    /// <summary>
    /// Get the account for the specified 'id'.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Get(long id)
    {
        var account = _dbService.Find(id);

        if (account == null)
            return BadRequest("Content not found");

        return new JsonResult(_mapper.Map<AccountModel>(account));
    }

    /// <summary>
    /// Add a new account.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Add(AccountModel model)
    {
        var account = _dbService.AddAndSave(_mapper.Map<Account>(model));
        return new JsonResult(_mapper.Map<AccountModel>(account));
    }

    /// <summary>
    /// Update the specified account.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Update(AccountModel model)
    {
        var account = _dbService.UpdateAndSave(_mapper.Map<Account>(model));
        return new JsonResult(_mapper.Map<AccountModel>(account));
    }

    /// <summary>
    /// Delete the specified account.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Remove(AccountModel model)
    {
        _dbService.DeleteAndSave(_mapper.Map<Account>(model));
        return new JsonResult(model);
    }
    #endregion
}
