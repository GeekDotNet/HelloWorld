using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDemoApi
{
    public class PrefixKeyVaultSecretManager : IKeyVaultSecretManager
    {
        public string GetKey(SecretBundle secret)
        {
            
            return secret.SecretIdentifier.Name
                .Replace("--", ConfigurationPath.KeyDelimiter);
        }

        public bool Load(SecretItem secret)
        {
            return true;
        }
    }
}
