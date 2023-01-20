using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Childcare.Dal.Models;

[Table("users_relationship_types")]
public class UserRelationshipType
{
    [Key] 
    [Column("id")] 
    public int Id { get; set; }

    [Column("parent_id")] 
    public int ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public User Parent { get; set; }

    [Column("child_id")] 
    public int ChildId { get; set; }
    [ForeignKey(nameof(ChildId))]
    public User Child { get; set; }
    
    [Column("relationship_type_id")] 
    public int RelationshipTypeId { get; set; }
    [ForeignKey(nameof(RelationshipTypeId))]
    public RelationshipType RelationshipType { get; set; }
}