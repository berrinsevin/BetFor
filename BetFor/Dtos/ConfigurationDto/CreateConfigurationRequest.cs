namespace BetFor.Entities
{
    [Serializable]
    public class CreateConfigurationRequest
    {
        public string? KeyWord { get; set; }
        public string? ValueWord { get; set; }
    }
}