namespace BetFor.Entities
{
    [Serializable]
    public class Tour : BetForBase
    {
        public DateTime TourTime { get; set; }
        public bool IsWinner { get; set; }
        public long WinnerId { get; set; }
    }
}
