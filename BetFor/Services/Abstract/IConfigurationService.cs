using BetFor.Entities;

namespace BetFor.Services
{
    public interface IConfigurationService
    {
        Task<bool> TryCreateConfigurationAsync(CreateConfigurationRequest request);
        Task<bool> TryUpdateConfigurationAsync(UpdateConfigurationRequest request);
        Task<bool> TryDeleteConfigurationAsync(DeleteConfigurationRequest request);
        Task<long> GetConfigurationValueAsync(GetConfigurationValueRequest request);
    }
}