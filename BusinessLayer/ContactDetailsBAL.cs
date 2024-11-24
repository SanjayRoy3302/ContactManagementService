using ContactManagementService.DataAccessLayer;
using ContactManagementService.Model;
using ContactManagementService.ServiceLayer;

namespace ContactManagementService.BusinessLayer
{
    public class ContactDetailsBAL : IContactDetailsService
    {
        ContactDetailsDAL _DAL;
        public ContactDetailsBAL(ContactDetailsDAL DAL) { _DAL = DAL; }
        public Task<List<ContactDetails>> GetAllContactsList()
        {
            return _DAL.GetAllContactsList();
        }

        public Task<BaseResponseModel> AddContact(ContactDetails contactDetails)
        {
            return _DAL.AddContact(contactDetails);
        }

        public async Task<BaseResponseModel> UpdateContact(ContactDetails contactDetails)
        {
            BaseResponseModel result = new BaseResponseModel();

            result = await _DAL.UpdateContact(contactDetails);
            return result;
        }

        public async Task<BaseResponseModel> DeleteContact(int contactDetailId)
        {
            BaseResponseModel result = new BaseResponseModel();
            result = await _DAL.DeleteContact(contactDetailId);
            return result;
        }
    }
}
