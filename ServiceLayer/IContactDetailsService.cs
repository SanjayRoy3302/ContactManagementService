using ContactManagementService.Model;

namespace ContactManagementService.ServiceLayer
{
    public interface IContactDetailsService
    {
        Task<List<ContactDetails>> GetAllContactsList();
        Task<BaseResponseModel> AddContact(ContactDetails contactDetails);
        Task<BaseResponseModel> UpdateContact(ContactDetails contactDetails);
        Task<BaseResponseModel> DeleteContact(int contactDetailId);
    }
}
