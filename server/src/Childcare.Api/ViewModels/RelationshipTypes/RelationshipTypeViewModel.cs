namespace Childcare.Api.ViewModels;

public class RelationshipTypeViewModel
{
    public int Id { get; set; }
    
    public string Relationship { get; set; }
    
    public UserViewModel User { get; set; }
    
}