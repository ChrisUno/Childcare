namespace Childcare.Api.ViewModels;

public class AddressDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public string Zipcode { get; set; }
    
    public List<UserViewModel> Users { get; set; }
    
    public List<RelationshipTypeViewModel> Relationship { get; set; }
    
    public EventViewModel Event { get; set; }
}