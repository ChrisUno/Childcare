namespace Childcare.Api.ViewModels;

public class UserDetailViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    
    public string Active { get; set; }

    public FamilyViewModel Family { get; set; }
    public AddressViewModel Address { get; set; }
    public List<RelationshipTypeViewModel> Relationship { get; set; }

}