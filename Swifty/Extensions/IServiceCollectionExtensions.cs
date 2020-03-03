using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Swifty.Data.Context;
using Swifty.Data.Contracts;
using Swifty.Data.Repositories;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Swifty.Web.Auth;
using Microsoft.AspNetCore.Authorization;
using Swifty.Data.Services;
using Swifty.Core.Entities;

namespace Swifty.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private const string AUTH_SCHEME_NAME = "Cookies";
        private const string AUTH_CHALLENGE_SCHEME_NAME = "oidc";

        public static void ConfigureDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<SwiftyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Swifty")));
        }

        public static void ConfigureRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SwiftyRepository<Admin>, AdminRepository>();
            serviceCollection.AddSingleton<SwiftyRepository<User>, UserRepository>();

            serviceCollection.AddSingleton<SwiftyRepository<SkillArea>, SkillAreaRepository>();
            serviceCollection.AddSingleton<SwiftyRepository<SkillLevel>, SkillLevelRepository>();
            serviceCollection.AddSingleton<SwiftyRepository<Skill>, SkillRepository>();
            serviceCollection.AddSingleton<SwiftyRepository<SkillSet>, SkillSetRepository>();
            serviceCollection.AddSingleton<SwiftyRepository<SkillSetSkillLink>, SkillSetSkillLinkRepository>();
            serviceCollection.AddSingleton<SwiftyRepository<SkillSnapshot>, SkillSnapshotRepository>();
        }

        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<AdminService>();
            serviceCollection.AddSingleton<UserService>();
            serviceCollection.AddSingleton<SkillAreaService>();
            serviceCollection.AddSingleton<SkillLevelService>();
            serviceCollection.AddSingleton<SkillService>();
            serviceCollection.AddSingleton<SkillSetService>();
            serviceCollection.AddSingleton<SkillSetSkillLinkService>();
            serviceCollection.AddSingleton<SkillSnapshotService>();
        }

        public static void ConfigureAuthorisation(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultScheme = AUTH_SCHEME_NAME;
                options.DefaultChallengeScheme = AUTH_CHALLENGE_SCHEME_NAME;
            })
            .AddCookie(AUTH_SCHEME_NAME)
            .AddOpenIdConnect(AUTH_CHALLENGE_SCHEME_NAME, options =>
            {
                options.Authority = configuration["Authentication:AuthorityUrl"];
                options.ClientId = configuration["Authentication:ClientId"];
                options.ClientSecret = configuration["Authentication:ClientSecret"];
                options.ResponseType = "code id_token";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
            });

            serviceCollection.AddSingleton<IAuthorizationHandler, IsAdminHandler>();

            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.Requirements.Add(new IsAdminRequirement()));
            });
        }
    }
}
