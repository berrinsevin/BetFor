namespace BetFor.Entities
{
    [Serializable]
    public class CreateBetRequest
    {
        public long ClientId { get; set; }
        public long BetNumber { get; set; }
    }
}