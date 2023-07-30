using System.ComponentModel.DataAnnotations.Schema;

public class BetForBase
{
    [Column("ID")]
    public long Id { get; set; }
    [Column("ENTRY_TIME")]
    public DateTime? EntryTime { get; set; }
}