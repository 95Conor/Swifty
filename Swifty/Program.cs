using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Everything commented out may be necessary for auth via SSO with develop
// It requires installing the Product.Configuration.Provider packaage below (think this is a Tigerbay package but not sure, check Nifty).

using Product.Configuration.Provider;

namespace Swifty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(Configure)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void Configure(HostBuilderContext hostBuilderContext, IConfigurationBuilder configurationBuilder)
        {
            IConfiguration config = configurationBuilder.Build();

            var configEndpoint = config["Configuration:EndpointUrl"];
            var authorityEndpoint = config["Authentication:AuthorityUrl"];
            var applicationName = config["Authentication:ApplicationName"];
            var clientId = config["Authentication:ClientId"];
            var clientSecret = config["Authentication:ClientSecret"];

            configurationBuilder.Sources.Insert(0, new RemoteConfigurationSource(configEndpoint, authorityEndpoint, clientId, clientSecret, applicationName));
        }
    }
}
