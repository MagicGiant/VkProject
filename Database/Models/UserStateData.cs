using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

[Table("user_state")]
public class UserStateData
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("code")]
    public StateCode Code { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
}