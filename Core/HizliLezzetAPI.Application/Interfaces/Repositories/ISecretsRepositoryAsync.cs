namespace HizliLezzetAPI.Application.Interfaces.Repositories
{
    public interface ISecretsRepositoryAsync
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
