using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;


namespace AzureDemoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DemoDbContext>();
                   // DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                         WebHost.CreateDefaultBuilder(args)
                             .ConfigureAppConfiguration((context, builder) =>
                             {
                           // only run in "production" mode, so you don't override 
                           // config values when running locally for development
                           if (context.HostingEnvironment.IsProduction())
                                 {
                                     var config = builder.Build();

                               // get MSI token from running web app
                               var tokenProvider = new AzureServiceTokenProvider();

                               // create kv client, passing MSI token for authorization
                               var keyvaultClient = new KeyVaultClient((authority, resource, scope)
                                                 => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));

                               // add the Key Vault "provider" that scans the KV, loading secrets into configuration
                               builder.AddAzureKeyVault(config["KeyVault:BaseUrl"], keyvaultClient, new PrefixKeyVaultSecretManager());
                                 }
                             })
                             .UseStartup<Startup>();
    }
}
