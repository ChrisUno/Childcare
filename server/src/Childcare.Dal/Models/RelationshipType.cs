using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Childcare.Dal.Models;

[Table("relationship_types")]
public class RelationshipType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("relationship")]
    public string Relationship { get; set; }
    
}