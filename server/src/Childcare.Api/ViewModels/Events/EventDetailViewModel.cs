namespace Childcare.Api.ViewModels;

public class EventDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime TimeSlot { get; set; }
    
    public AddressViewModel Address { get; set; }
}