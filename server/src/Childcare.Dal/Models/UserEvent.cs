using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Childcare.Dal.Models;

[Table("users_events")]
public class UserEvent
{
    [Key] 
    [Column("id")] 
    public int Id { get; set; }

    [Column("user_id")] 
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    [Column("event_id")] 
    public int EventId { get; set; }
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }
}