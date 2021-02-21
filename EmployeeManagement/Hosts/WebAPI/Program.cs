using EmployeeManagement.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              //.ConfigureAppConfiguration((context, builder) =>
              //{
              //    // only run in "production" mode, so you don't override 
              //    // config values when running locally for development
              //    if (context.HostingEnvironment.IsProduction())
              //    {
              //        var config = builder.Build();

              //        // get MSI token from running web app
              //        var tokenProvider = new AzureServiceTokenProvider();

              //        // create kv client, passing MSI token for authorization
              //        var keyvaultClient = new KeyVaultClient((authority, resource, scope)
              //                          => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));

              //        // add the Key Vault "provider" that scans the KV, loading secrets into configuration
              //        builder.AddAzureKeyVault(config["KeyVault:AzSQLServerConnection"], keyvaultClient, new PrefixKeyVaultSecretManager());
              //    }
              //})
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                });
    }
}
