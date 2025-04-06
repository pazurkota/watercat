using SQLite;

namespace watercat.Model;

[Table("daily_intake")]
public class DailyWaterIntake
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("intake")]
    public double Intake { get; set; }
    
    [Column("date")]
    public DateTime Date { get; set; }
}