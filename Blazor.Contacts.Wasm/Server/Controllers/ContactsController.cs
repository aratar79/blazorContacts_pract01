using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Shared;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertContact([FromBody]Contact contact) 
        {
            if (contact == null) return BadRequest();
            if (string.IsNullOrEmpty(contact.FirstName)) ModelState.AddModelError("FirstName", "First name can't be empty");
            if (string.IsNullOrEmpty(contact.LastName)) ModelState.AddModelError("LastName", "Last name can't be empty");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _contactRepository.InsertContact(contact);

            return CreatedAtAction(nameof(InsertContact), new { id = contact.Id }, contact);         
        }

        [HttpPut("{id}")]    
        public async Task<IActionResult> UpdateContact(int id, [FromBody]Contact contact) 
        {
            if (contact == null) return BadRequest();
            if (string.IsNullOrEmpty(contact.FirstName)) ModelState.AddModelError("FirstName", "First name can't be empty");
            if (string.IsNullOrEmpty(contact.LastName)) ModelState.AddModelError("LastName", "Last name can't be empty");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            contact.Id = id;

            await _contactRepository.UpdateContact(contact);

            return CreatedAtAction(nameof(InsertContact), new { id = contact.Id }, contact);         
        }

        [HttpGet("{id}")]
        public async Task<Contact> getContact(int id) => await _contactRepository.GetContact(id);

        [HttpGet]
        public async Task<IEnumerable<Contact>> getAll() => await _contactRepository.GetAll();

        [HttpDelete("{id}")]
        public async Task deleteContact(int id) => await _contactRepository.DeleteContact(id);
    }
}