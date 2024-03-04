using System.ComponentModel.DataAnnotations.Schema;

namespace BuberBreakfast.Models;

[Table("shop")]
public class Shop
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("address")]
    public string Address { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

}