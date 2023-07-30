namespace BetFor.Entities
{
    [Serializable]
    public class GetBetResultResponse
    {
        public long TourId { get; set; }
        public long TourNumber { get; set; }
        public long BetNumber { get; set; }
        public bool IsWinner { get; set; }
    }
}