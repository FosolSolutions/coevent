namespace Coevent.Dal;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Coevent.Entities;
using Coevent.Core.Extensions;

public class CoeventContext : DbContext
{
    #region Variables
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JsonSerializerOptions _serializerOptions;
    #endregion

    #region Properties
    public virtual DbSet<Account> Accounts { get; set; } = null!;
    public virtual DbSet<Application> Applications { get; set; } = null!;
    public virtual DbSet<Calendar> Calendars { get; set; } = null!;
    public virtual DbSet<Claim> Claims { get; set; } = null!;
    public virtual DbSet<Criteria> Criterias { get; set; } = null!;
    public virtual DbSet<CriteriaTrait> CriteriaTraits { get; set; } = null!;
    public virtual DbSet<Event> Events { get; set; } = null!;
    public virtual DbSet<EventOccurrence> EventOccurrences { get; set; } = null!;
    public virtual DbSet<Opening> Openings { get; set; } = null!;
    public virtual DbSet<OpeningCriteria> OpeningCriterias { get; set; } = null!;
    public virtual DbSet<OpeningOccurrence> OpeningOccurrences { get; set; } = null!;
    public virtual DbSet<Participant> Participants { get; set; } = null!;
    public virtual DbSet<RoleClaim> RoleClaims { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<Schedule> Schedules { get; set; } = null!;
    public virtual DbSet<Survey> Surveys { get; set; } = null!;
    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; } = null!;
    public virtual DbSet<Trait> Traits { get; set; } = null!;
    public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;
    public virtual DbSet<UserClaim> UserClaims { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
    #endregion

    #region Constructors
    private CoeventContext(DbContextOptions<CoeventContext> options) : base(options)
    {
        _httpContextAccessor = new HttpContextAccessor();
        _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }

    public CoeventContext(DbContextOptions<CoeventContext> options, IHttpContextAccessor contextAssessor, IOptions<JsonSerializerOptions>? serializerOptions = null) : base(options)
    {
        _httpContextAccessor = contextAssessor;
        _serializerOptions = serializerOptions?.Value ?? new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }
    #endregion

    #region Methods
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoeventContext).Assembly);
    }

    public override int SaveChanges()
    {
        var username = _httpContextAccessor.HttpContext.User.GetUsername() ?? "Unknown";
        var now = DateTime.UtcNow;

        foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged))
        {
            if (entry.Entity is AuditColumns entity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedBy = username;
                        entity.CreatedOn = now;
                        goto case EntityState.Modified;
                    case EntityState.Modified:
                        entity.UpdatedBy = username;
                        entity.UpdatedOn = now;
                        break;
                }
            }
        }
        return base.SaveChanges();
    }
    #endregion
}
