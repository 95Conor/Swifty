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

namespace Swifty.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<SwiftyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Swifty")));

            serviceCollection.AddSingleton<SwiftyContext>();
        }

        public static void ConfigureRepositories(this IServiceCollection serviceCollection)
        {
            
        }
    }
}
