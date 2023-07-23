namespace BetFor.Entities
{
    public class CurrentTour
    {
        public long TourNumber { get; set; }
        public DateTime TourStartTime { get; set; }
        public DateTime TourEndTime { get; set; }
        public long FirstNumber { get; set; }
        public long SecondNumber { get; set; }
    }
}