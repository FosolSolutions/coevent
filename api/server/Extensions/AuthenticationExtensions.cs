using System.Text;
using Coevent.Api.Authentication;
using Coevent.Api.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Coevent.Api.Extensions;

/// <summary>
/// get/set -
/// </summary>
public static class AuthenticationExtensions
{
    /// <summary>
    /// get/set -
    /// </summary>
    public static IServiceCollection AddCoeventAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthenticator, Authenticator>();
        services.Configure<CoeventAuthenticationOptions>(configuration.GetSection("Authentication"));
        var config = configuration.GetSection("Authentication").Get<CoeventAuthenticationOptions>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config.Issuer,
                    ValidAudience = config.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret ?? throw new InvalidOperationException("Cookie secret configuration is required."))),
                    ClockSkew = TimeSpan.Zero
                };
                //options.Events = new JwtBearerEvents()
                //{
                //    OnMessageReceived = context =>
                //    {
                //        context.Token = context.Request.Cookies[config.Cookie.Name];
                //        return Task.CompletedTask;
                //    }
                //};
            });

        return services;
    }
}
