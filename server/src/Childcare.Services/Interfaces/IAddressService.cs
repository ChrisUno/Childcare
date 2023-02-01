using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IAddressService
    {
        IList<AddressDTO> GetAddresses();
        AddressDTO GetAddressById(int id);

    }
}