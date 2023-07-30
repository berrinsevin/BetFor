namespace BetFor.Entities
{
    [Serializable]
    public class CreateBetResponse
    {
        public long ClientId { get; set; }
        public long BetNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public long TourId { get; set; }
        public bool IsCreated { get; set; }
        public string? ResponseMessage { get; set; }
    }
}