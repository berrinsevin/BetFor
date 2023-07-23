namespace BetFor.Entities
{
    public class TourDto
    {
        public DateTime TourTime { get; set; }
        public bool IsWinner { get; set; }
        public long WinnerId { get; set; }
    }
}