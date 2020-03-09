﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Swifty.Data.Context;
using Swifty.Data.Repositories;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Swifty.Web.Auth;
using Microsoft.AspNetCore.Authorization;
using Swifty.Data.Services;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Repositories;

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
            serviceCollection.AddTransient<IBaseRepository<Admin>, AdminRepository>();
            serviceCollection.AddTransient<IBaseRepository<User>, UserRepository>();

            serviceCollection.AddTransient<IBaseRepository<SkillArea>, SkillAreaRepository>();
            serviceCollection.AddTransient<IBaseRepository<SkillLevel>, SkillLevelRepository>();
            serviceCollection.AddTransient<IBaseArchiveableRepository<Skill>, SkillRepository>();
            serviceCollection.AddTransient<IBaseRepository<SkillSet>, SkillSetRepository>();
            serviceCollection.AddTransient<IBaseRepository<SkillSetSkillLink>, SkillSetSkillLinkRepository>();
            serviceCollection.AddTransient<IBaseRepository<SkillSnapshot>, SkillSnapshotRepository>();
        }

        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AdminService>();
            serviceCollection.AddTransient<UserService>();
            serviceCollection.AddTransient<SkillAreaService>();
            serviceCollection.AddTransient<SkillLevelService>();
            serviceCollection.AddTransient<SkillService>();
            serviceCollection.AddTransient<SkillSetService>();
            serviceCollection.AddTransient<SkillSetSkillLinkService>();
            serviceCollection.AddTransient<SkillSnapshotService>();
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

            serviceCollection.AddTransient<IAuthorizationHandler, IsAdminHandler>();

            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.Requirements.Add(new IsAdminRequirement()));
            });
        }
    }
}
