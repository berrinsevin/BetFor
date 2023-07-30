using System.ComponentModel.DataAnnotations.Schema;

namespace BetFor.Entities
{
    [Serializable]
    [Table("ClientTour", Schema = "dbo")]
    public class ClientTour : BetForBase
    {
        [Column("TOUR_ID")]
        public long TourId { get; set; }
        [Column("CLIENT_ID")]
        public long ClientId { get; set; }
        [Column("BET_NUMBER")]
        public long BetNumber { get; set; }
    }
}
