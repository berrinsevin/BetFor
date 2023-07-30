using System.ComponentModel.DataAnnotations.Schema;

namespace BetFor.Entities
{
    [Serializable]
    [Table("Client", Schema = "dbo")]
    public class Client : BetForBase
    {
        [Column("FIRST_NAME")]
        public string? FirstName { get; set; }
        [Column("LAST_NAME")]
        public string? LastName { get; set; }
        [Column("USER_NAME")]
        public string? UserName { get; set; }
    }
}