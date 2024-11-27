using ContactServiceLayer;
using ContactServiceLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementService.Controllers
{
    [Route("api/ContactDetails/")]
    [AllowAnonymous]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactDetailsService _BAL;

        public ContactDetailsController(IContactDetailsService contactDetailsService)
        {
            _BAL = contactDetailsService;
        }

        // GET: api/ContactDetails
        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllContacts")]
        public ActionResult<IEnumerable<ContactDetails>> GetContactDetails()
        {
            return _BAL.GetAllContactsList();
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutContactDetails(int id, ContactDetails contactDetails)
        {
            BaseResponseModel result = _BAL.UpdateContact(contactDetails);
            return Ok(result);
        }

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Route("SaveContact")]
        public ActionResult<ContactDetails> PostContactDetails(ContactDetails contactDetails)
        {
            BaseResponseModel result = _BAL.AddContact(contactDetails);

            return Ok(result);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContactDetails(int id)
        {
            BaseResponseModel result = _BAL.DeleteContact(id);
            return Ok(result);
        }

        // GET: api/ContactDetails
        [HttpGet]
        [AllowAnonymous]
        [Route("CheckGlobalException")]
        public ActionResult<IEnumerable<ContactDetails>> CheckGlobalException()
        {
            var list = _BAL.GetAllContactsList();
            var exception = list[100].Firstname;
            return _BAL.GetAllContactsList();
        }

    }
}
