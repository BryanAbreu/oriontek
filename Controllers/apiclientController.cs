using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oriontek.Models;

namespace oriontek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiclientController : ControllerBase
    {

        private readonly oriontekContext _context;
        public apiclientController(oriontekContext context)
        {
           _context = context;

        }

        public async Task<List<Client>> Get()
            => await _context.Clients.ToListAsync();

    }
}
