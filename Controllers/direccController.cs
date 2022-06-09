using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oriontek.Models;
using oriontek.Models.ViewModels;

namespace oriontek.Controllers
{
    public class direccController : Controller
    {
        private readonly oriontekContext _context;
        public direccController(oriontekContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cliente = _context.Clients.Include(m => m.Direccions);
            return View(await cliente.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DireccViewmodel direccvm,ClientViewmodel clivm)
        {
            if (ModelState.IsValid)
            {
                var direc = new Direccion()
                {
                    Direccion1 = direccvm.direccion,
                    Idcli = clivm.idcli



                };
                _context.Add(direc);
                await _context.SaveChangesAsync();
                return RedirectToAction("index", "Client");
            }

          
            return View();

        }

    }
}
