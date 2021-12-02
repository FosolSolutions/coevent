namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ParticipantService : BaseCrudRepository<Participant>, IParticipantService
{
    #region Variables
    #endregion

    #region Constructors
    public ParticipantService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<ParticipantService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
