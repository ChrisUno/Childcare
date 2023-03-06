namespace Childcare.Services.Services.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FamilyId { get; set; }
        public int Active { get; set; }
        public int AddressId { get; set; }
    }
}