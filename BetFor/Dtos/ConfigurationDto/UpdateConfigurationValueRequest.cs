namespace BetFor.Entities
{
    [Serializable]
    public class UpdateConfigurationRequest
    {
        public string? KeyWord { get; set; }
        public string? ValueWord { get; set; }
    }
}