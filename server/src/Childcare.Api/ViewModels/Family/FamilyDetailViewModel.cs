namespace Childcare.Api.ViewModels;

public class FamilyDetailViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public List<UserViewModel> Users { get; set; }
    
}