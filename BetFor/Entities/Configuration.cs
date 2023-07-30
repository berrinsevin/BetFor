using System.ComponentModel.DataAnnotations.Schema;

namespace BetFor.Entities
{
    [Serializable]
    [Table("Configuration", Schema = "dbo")]
    public class Configuration : BetForBase
    {
        [Column("KEYWORD")]
        public string KeyWord { get; set; }
        [Column("VALUEWORD")]
        public string ValueWord { get; set; }
    }
}
