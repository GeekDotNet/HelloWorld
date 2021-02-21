using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace EmployeeManagement.Common
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
