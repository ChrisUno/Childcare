using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IAddressService
    {
        IList<AddressDTO> GetAddresses();
        AddressDTO GetAddressById(int id);

        bool UpdateAddress(int id, AddressDTO address);

        bool DeleteAddress(int id); 

        bool CreateAddress (AddressDTO address);

    }
}