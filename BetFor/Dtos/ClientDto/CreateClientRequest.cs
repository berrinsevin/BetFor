namespace BetFor.Entities
{
    [Serializable]
    public class CreateClientRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
    }
}