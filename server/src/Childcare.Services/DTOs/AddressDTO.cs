namespace Childcare.Services.Services.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Region { get; set; }
        public int Country { get; set; }
        public int Zipcode { get; set; }
        public int UserId { get; set; }    
    }
}