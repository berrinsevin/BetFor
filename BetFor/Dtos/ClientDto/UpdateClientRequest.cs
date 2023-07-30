namespace BetFor.Entities
{
    [Serializable]
    public class UpdateClientRequest
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
    }
}