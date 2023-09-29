using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using HizliLezzetAPI.Application.Interfaces.Repositories;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class AzureKeyVaultRepository : ISecretsRepositoryAsync
    {
        public async Task<string> GetSecretAsync(string secretName)
        {
            try
            {
                var client = new SecretClient(new Uri("https://hizlilezzetwebapivault.vault.azure.net/"), new DefaultAzureCredential());

                KeyVaultSecret secret = await client.GetSecretAsync(secretName);

                return secret.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve confidential information from Azure Key Vault. Error: {ex.Message}");
            }
        }
    }
}
