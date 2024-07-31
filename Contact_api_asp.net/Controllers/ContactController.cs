using Contact_api_asp.net.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contact_api_asp.net.services;
namespace Contact_api_asp.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataBaseContexteClasse _context;
        private readonly ContactRepository _contactRepository;
        public ContactController(DataBaseContexteClasse context)
        {
            _context = context;
            _contactRepository = new ContactRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Action>>> GetAllContact()
        {
            return Ok(await _contactRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Action>> GetContackId(int id)
        {
            Contact contact = await _contactRepository.GetById(id);
            if (contact == null) { return NotFound("contact not found"); };
            return Ok(contact);
        }
        [HttpPut]
        public async Task<ActionResult<Action>> UpdateContact(Contact updateContact)
        {
            if (await _contactRepository.GetById(updateContact.id_contact) != null)
            {
                _contactRepository.Update(updateContact, updateContact.id_contact);
                return Ok(await GetAllContact());
            }
            return BadRequest("contact not updated");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Action>> DeleteContact(int id)
        {
            if (await _contactRepository.GetById(id) != null)
            {
                _contactRepository.Delete(id);
                return Ok(await _contactRepository.GetAll());
            }
            else
            {
                return NotFound("contact not found");
            }            
        }
        [HttpPost]
        public async Task<ActionResult<Action>> AddContact([FromBody]Contact contact)
        {
            if (await _contactRepository.GetById(contact.id_contact) != null)
            {
                _contactRepository.Add(contact);
                return Ok(await GetAllContact());
            }
            else
            {
                return BadRequest("contact not found");
            }
            
        }

    }
}
