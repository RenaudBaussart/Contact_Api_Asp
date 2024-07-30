using Contact_api_asp.net.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_api_asp.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataBaseContexteClasse _context;
        public ContactController(DataBaseContexteClasse context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Action>>> GetAllContact()
        {
            var contacte = await _context.Contacte.ToListAsync();
            return Ok(contacte);
        }
        
    }
}
