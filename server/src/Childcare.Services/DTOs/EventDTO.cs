namespace Childcare.Services.Services.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeSlot { get; set; }
        public int AddressId { get; set; }

    }
}