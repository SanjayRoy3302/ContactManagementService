using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagementService.Model;
using Microsoft.AspNetCore.Authorization;

namespace ContactManagementService.Controllers
{
    [Route("api/ContactDetails/")]
    [AllowAnonymous]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly ContactManagementServiceContext _context;

        public ContactDetailsController(ContactManagementServiceContext context)
        {
            _context = context;
        }

        // GET: api/ContactDetails
        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllContacts")]
        public async Task<ActionResult<IEnumerable<ContactDetails>>> GetContactDetails()
        {
            return await _context.ContactDetails.ToListAsync();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ContactDetails>> GetContactDetails(int id)
        {
            var contactDetails = await _context.ContactDetails.FindAsync(id);

            if (contactDetails == null)
            {
                return NotFound();
            }

            return contactDetails;
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetails(int id, ContactDetails contactDetails)
        {
            if (id != contactDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("SaveContact")]
        public async Task<ActionResult<ContactDetails>> PostContactDetails(ContactDetails contactDetails)
        {
            _context.ContactDetails.Add(contactDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactDetails", new { id = contactDetails.Id }, contactDetails);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactDetails(int id)
        {
            var contactDetails = await _context.ContactDetails.FindAsync(id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            _context.ContactDetails.Remove(contactDetails);
            await _context.SaveChangesAsync();

                return NoContent();
        }

        private bool ContactDetailsExists(int id)
        {
            return _context.ContactDetails.Any(e => e.Id == id);
        }
    }
}
