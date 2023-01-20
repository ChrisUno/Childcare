using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Childcare.Dal.Models;

[Table("addresses")]
public class Address
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("address_line_1")]
    public string AddressLine1 { get; set; }
    
    [Column("address_line_2")]
    public string AddressLine2 { get; set; }
    
    [Column("region")]
    public string Region { get; set; }
    
    [Column("country")]
    public string Country { get; set; }
    
    [Column("zipcode")]
    public string Zipcode { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [ForeignKey(nameof(UserId))] 
    public virtual User User { get; set; }
    
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<User> Users { get; set; }
}