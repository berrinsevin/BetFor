namespace BetFor.Entities
{
    [Serializable]
    public class Tour : BetForBase
    {
        public long TourNumber { get; set; }
        public long EndNumber { get; set; }
        public long StartNumber { get; set; }
        public DateTime TourStartTime { get; set; }
        public DateTime TourEndTime { get; set; }
        public bool IsWinner { get; set; }
        public long WinnerId { get; set; }
    }
}
