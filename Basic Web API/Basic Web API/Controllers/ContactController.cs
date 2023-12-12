using Basic_Web_API.Models;
using Basic_Web_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basic_Web_API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getAllContacts")]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("getContactById")]
        public ActionResult<Contact> GetContactById(int contactId)
        {
            var contact = _contactService.GetContactById(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost("createContact")]
        public ActionResult CreateContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            _contactService.CreateContact(contact);

            return CreatedAtAction(nameof(GetContactById), new { contactId = contact.ContactId }, contact);
        }

        [HttpPut("{contactId}")]
        public ActionResult UpdateContact(int contactId, [FromBody] Contact contact)
        {
            if (contact == null || contactId != contact.ContactId)
            {
                return BadRequest();
            }

            var existingContact = _contactService.GetContactById(contactId);

            if (existingContact == null)
            {
                return NotFound();
            }

            _contactService.UpdateContact(contact);

            return NoContent();
        }

        [HttpDelete("deleteContact")]
        public ActionResult DeleteContact(int contactId)
        {
            var contact = _contactService.GetContactById(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.DeleteContact(contactId);

            return NoContent();
        }

        [HttpGet("filterContacts")]
        public ActionResult<List<Contact>> FilterContacts(int? countryId, int? companyId)
        {
            var filteredContacts = _contactService.FilterContacts(countryId, companyId);

            return Ok(filteredContacts);
        }

    }
}
