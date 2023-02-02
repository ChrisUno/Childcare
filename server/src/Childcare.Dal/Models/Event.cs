using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Childcare.Dal.Models;

[Table("events")]
public class Event
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("time_slot")]
    public DateTime Timeslot { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("address_id")]
    public int AddressId { get; set; }
    
    [ForeignKey(nameof(AddressId))]
    public Address Address { get; set; }
}