namespace Childcare.Api.ViewModels;

public class UserRelationshipTypeViewModel
{
    public int Id { get; set; }
    
    public RelationshipTypeViewModel RelationshipTypeId { get; set; }
    
    public UserViewModel ParentId { get; set; }
    
    public UserViewModel ChildId { get; set; }
}