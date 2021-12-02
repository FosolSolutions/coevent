using System.Data.SqlClient;
using Coevent.Dal.Repositories;
using Coevent.Dal.Repositories.Interfaces;
using Coevent.Dal.Services;
using Coevent.Dal.Services.Interfaces;
using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Coevent.Dal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoeventContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddDbContext<CoeventContext>(options =>
        {
            // Generate the database connection string.
            var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));
            builder.DataSource = String.IsNullOrWhiteSpace(builder.DataSource) ? configuration["DB_ADDR"] : builder.DataSource;
            builder.InitialCatalog = String.IsNullOrWhiteSpace(builder.InitialCatalog) ? configuration["DB_NAME"] : builder.InitialCatalog;
            builder.UserID = String.IsNullOrWhiteSpace(builder.UserID) ? configuration["DB_USER"] : builder.UserID;
            builder.Password = String.IsNullOrWhiteSpace(builder.Password) ? configuration["DB_PASSWORD"] : builder.Password;

            var sql = options.UseSqlServer(builder.ConnectionString, sqlOptions =>
            {
                sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
            });
            if (!environment.IsProduction())
            {
                var debugLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });
                sql.UseLoggerFactory(debugLoggerFactory);
                options.EnableSensitiveDataLogging();
            }
        });
        return services;
    }

    public static IServiceCollection AddCoeventDal(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddCoeventContext(configuration, environment);

        // Repositories
        services.AddScoped<IBaseCrudRepository<Account>, BaseCrudRepository<Account>>();
        services.AddScoped<IBaseCrudRepository<Application>, BaseCrudRepository<Application>>();
        services.AddScoped<IBaseCrudRepository<Calendar>, BaseCrudRepository<Calendar>>();
        services.AddScoped<IBaseCrudRepository<Criteria>, BaseCrudRepository<Criteria>>();
        services.AddScoped<IBaseCrudRepository<CriteriaTrait>, BaseCrudRepository<CriteriaTrait>>();
        services.AddScoped<IBaseCrudRepository<Event>, BaseCrudRepository<Event>>();
        services.AddScoped<IBaseCrudRepository<EventOccurrence>, BaseCrudRepository<EventOccurrence>>();
        services.AddScoped<IBaseCrudRepository<Opening>, BaseCrudRepository<Opening>>();
        services.AddScoped<IBaseCrudRepository<OpeningCriteria>, BaseCrudRepository<OpeningCriteria>>();
        services.AddScoped<IBaseCrudRepository<OpeningOccurrence>, BaseCrudRepository<OpeningOccurrence>>();
        services.AddScoped<IBaseCrudRepository<Participant>, BaseCrudRepository<Participant>>();
        services.AddScoped<IBaseCrudRepository<Role>, BaseCrudRepository<Role>>();
        services.AddScoped<IBaseCrudRepository<Schedule>, BaseCrudRepository<Schedule>>();
        services.AddScoped<IBaseCrudRepository<Survey>, BaseCrudRepository<Survey>>();
        services.AddScoped<IBaseCrudRepository<SurveyQuestion>, BaseCrudRepository<SurveyQuestion>>();
        services.AddScoped<IBaseCrudRepository<Trait>, BaseCrudRepository<Trait>>();
        services.AddScoped<IBaseCrudRepository<User>, BaseCrudRepository<User>>();
        services.AddScoped<IBaseCrudRepository<UserClaim>, BaseCrudRepository<UserClaim>>();

        // Services
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<ICalendarService, CalendarService>();
        services.AddScoped<ICriteriaService, CriteriaService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IOpeningService, OpeningService>();
        services.AddScoped<IParticipantService, ParticipantService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<ISurveyService, SurveyService>();
        services.AddScoped<ITraitService, TraitService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
