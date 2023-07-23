namespace BetFor.Entities
{
    [Serializable]
    public class Client : BetForBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
    }
}