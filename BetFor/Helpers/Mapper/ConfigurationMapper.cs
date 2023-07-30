using BetFor.Entities;

namespace BetFor.Helpers.ConfigurationMapper
{
    public static class ConfigurationMapper
    {
        public static Configuration ToConfigurationFromCreateConfigurationRequest(this CreateConfigurationRequest request)
        {
            return new Configuration
            {
                KeyWord = request.KeyWord,
                ValueWord = request.ValueWord
            };
        }

        public static Configuration ToConfigurationFromUpdateConfigurationRequest(this UpdateConfigurationRequest request, Configuration item)
        {
            item.ValueWord = request.ValueWord;

            return item;
        }
    }
}