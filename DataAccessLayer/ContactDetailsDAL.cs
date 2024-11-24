using ContactManagementService.Model;
using ContactManagementService.ServiceLayer;
using Microsoft.EntityFrameworkCore;

namespace ContactManagementService.DataAccessLayer
{
    public class ContactDetailsDAL : IContactDetailsService
    {
        private readonly ContactManagementServiceContext _context;

        public ContactDetailsDAL(ContactManagementServiceContext context)
        {
            _context = context;
        }

        public async Task<List<ContactDetails>> GetAllContactsList()
        {
            List<ContactDetails> result = await _context.ContactDetails.ToListAsync();
            return result;
        }

        public async Task<BaseResponseModel> AddContact(ContactDetails contactDetails)
        {
            BaseResponseModel result = new BaseResponseModel();
            try
            {
                _context.ContactDetails.Add(contactDetails);
                await _context.SaveChangesAsync();
                result.Id = contactDetails.Id;
                result.StatusCode = (int)StatusCode.Added;
                result.StatusMessage = StatusMessage.Added;

            }
            catch (Exception ex)
            {
                result.StatusCode = (int)StatusCode.Failed;
                result.StatusMessage = StatusMessage.Failed;
            }
            return result;
        }

        public async Task<BaseResponseModel> UpdateContact(ContactDetails contactDetails)
        {
            BaseResponseModel result = new BaseResponseModel();
            try
            {
                ContactDetails? _contactDetail = _context.ContactDetails.Where(a => a.Id == contactDetails.Id).FirstOrDefault();
                if (_contactDetail == null)
                {
                    result.StatusCode = (int)StatusCode.NotFound;
                    result.StatusMessage = StatusMessage.NotFound;
                }
                else
                {
                    _contactDetail.Firstname = contactDetails.Firstname;
                    _contactDetail.Lastname = contactDetails.Lastname;
                    _contactDetail.Email = contactDetails.Email;
                    _context.Entry(_contactDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result.Id = _contactDetail.Id;
                    result.StatusCode = (int)StatusCode.Updated;
                    result.StatusMessage = StatusMessage.Updated;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)StatusCode.Failed;
                result.StatusMessage = StatusMessage.Failed;
            }
            return result;
        }

        public async Task<BaseResponseModel> DeleteContact(int contactDetailId)
        {
            BaseResponseModel result = new BaseResponseModel();
            try
            {
                ContactDetails? contactDetail = _context.ContactDetails.Where(a=>a.Id == contactDetailId).FirstOrDefault();
                if (contactDetail == null)
                {
                    result.StatusCode = (int)StatusCode.NotFound;
                    result.StatusMessage = StatusMessage.NotFound;
                }
                else
                {
                    _context.ContactDetails.Remove(contactDetail);
                    await _context.SaveChangesAsync();
                    result.Id = contactDetail.Id;
                    result.StatusCode = (int)StatusCode.Deleted;
                    result.StatusMessage = StatusMessage.Deleted;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)StatusCode.Failed;
                result.StatusMessage = StatusMessage.Failed;
            }
            return result;
        }

    }
}
