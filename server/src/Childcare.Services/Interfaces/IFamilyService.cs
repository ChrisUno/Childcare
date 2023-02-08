using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IFamilyService
    {
        IList<FamilyDTO> GetFamilies();
        FamilyDTO GetFamilyById(int id);
        bool UpdateFamily(int id, FamilyDTO family);

        bool CreateFamily( FamilyDTO family);

        bool DeleteFamily(int id);
    }
}