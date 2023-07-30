using System.ComponentModel.DataAnnotations.Schema;

namespace BetFor.Entities
{
    [Serializable]
    [Table("Tour", Schema = "dbo")]
    public class Tour : BetForBase
    {
        [Column("TOUR_NUMBER")]
        public long TourNumber { get; set; }
        [Column("START_NUMBER")]
        public long StartNumber { get; set; }
        [Column("END_NUMBER")]
        public long EndNumber { get; set; }
        [Column("START_TIME")]
        public DateTime TourStartTime { get; set; }
        [Column("END_TIME")]
        public DateTime TourEndTime { get; set; }
        [Column("IS_WINNER")]
        public bool IsWinner { get; set; }
    }
}
