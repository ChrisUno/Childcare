using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Childcare.Dal.Models;

[Table("users")]
public class User 
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("first_name")]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    public string LastName { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("password")]
    public string Password { get; set; }

    [Column("family_id")]
    public int FamilyId { get; set; }

    [ForeignKey(nameof(FamilyId))]
    public Family Family { get; set; }

    [Column("address_id")]
    public int AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address Address { get; set; }

    [Column("active")]
    public bool Active { get; set; }
    
    [InverseProperty("Parent")]
    public virtual ICollection<UserRelationshipType> ParentRelationships { get; set; }
    
    [InverseProperty("Child")]
    public virtual ICollection<UserRelationshipType> ChildRelationships { get; set; }
}