

using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

[Table("user")]
public class UserData
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("login")]
    public String Login { get; set; }
    
    [Column("password")]
    public String PasswordHashString { get; set; }
    
    [Column("created_date")]
    public String CreatedDate { get; set; }
    
    [Column("user_group_id")]
    public long UserGroupId { get; set; }
    
    [Column("user_state_id")]
    public long UserStateId { get; set; }
    
    [Column("is_admin")]
    public bool IsAdmin { get; set; }
}