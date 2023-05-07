using System.ComponentModel.DataAnnotations.Schema;
using Database.Entities;

namespace Database.Models;

[Table("user_group")]
public class UserGroupData
{
    [Column("id")]
    public long Id { get; set; }

    [Column("code")]
    public GroupCode Code { get; set; }

    [Column("description")]
    public string Description { get; set; }
}