using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagementService.Model;
using Microsoft.AspNetCore.Authorization;
using ContactManagementService.ServiceLayer;
using ContactManagementService.BusinessLayer;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public async Task<ActionResult<IEnumerable<ContactDetails>>> GetContactDetails()
        {
            return await _BAL.GetAllContactsList();
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetails(int id, ContactDetails contactDetails)
        {
            BaseResponseModel result = await _BAL.UpdateContact(contactDetails);
            return Ok(result);
        }

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Route("SaveContact")]
        public async Task<ActionResult<ContactDetails>> PostContactDetails(ContactDetails contactDetails)
        {
            BaseResponseModel result = await _BAL.AddContact(contactDetails);

            return Ok(result);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactDetails(int id)
        {
            BaseResponseModel result = await _BAL.DeleteContact(id);
            return Ok(result);
        }

    }
}
