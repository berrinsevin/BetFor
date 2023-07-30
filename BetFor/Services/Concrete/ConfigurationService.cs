using BetFor.Helpers;
using BetFor.Entities;
using BetFor.Repositories;
using BetFor.Helpers.ConfigurationMapper;

namespace BetFor.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IBaseRepository<Configuration> configurationRepository;

        public ConfigurationService(IBaseRepository<Configuration> configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        public async Task<bool> TryCreateConfigurationAsync(CreateConfigurationRequest request)
        {
            var item = request.ToConfigurationFromCreateConfigurationRequest();
            return await configurationRepository.TryInsertItemAsync(item);
        }

        public async Task<bool> TryUpdateConfigurationAsync(UpdateConfigurationRequest request)
        {
            bool isSuccess = false;
            var item = await configurationRepository.GetItemAsync(x => x.KeyWord == request.KeyWord);

            if (item != null)
            {
                item = request.ToConfigurationFromUpdateConfigurationRequest(item);
                isSuccess = await configurationRepository.TryUpdateItemAsync(item);
            }

            return isSuccess;
        }

        public async Task<bool> TryDeleteConfigurationAsync(DeleteConfigurationRequest request)
        {
            var isSuccess = false;
            var item = await configurationRepository.GetItemAsync(x => x.KeyWord == request.KeyWord);

            if (item != null)
            {
                isSuccess = await configurationRepository.TryDeleteItemAsync(item);
            }

            return isSuccess;
        }

        public async Task<long> GetConfigurationValueAsync(GetConfigurationValueRequest request)
        {
            long result = 0;
            var item = await configurationRepository.GetItemAsync(x => x.KeyWord == request.KeyWord);

            if (item != null && item.ValueWord != null)
            {
                result = Converter.ToLongFromString(item.ValueWord);
            }

            return result;
        }
    }
}