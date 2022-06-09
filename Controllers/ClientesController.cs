using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using oriontek.Models;
using oriontek.Models.ViewModels;

namespace oriontek.Controllers
{
    public class ClientesController : Controller
    {
        private readonly oriontekContext _context ;
        public ClientesController(oriontekContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {


            var cliente = _context.Clients.Include(m => m.Direccions);

            var listEntity = await _context.Clients.ToListAsync();
            List<ClientViewmodel> vms = new List<ClientViewmodel>();
            listEntity.ForEach(item =>
            {
                vms.Add(new ClientViewmodel
                {
                    name = item.Name,
                    idcli = item.Idclient,
                    Direcciones = item.Direccions.ToList()
                });
            });

            var direcciones = await _context.Direccions.ToListAsync();
            ViewData["Direcciones"] = direcciones;
            return View(vms);

        }

        public async Task<IActionResult> Create()
        {

            var cliente = _context.Clients.Include(m => m.Direccions);

            var listEntity = await _context.Clients.ToListAsync();
            List<ClientViewmodel> vms = new List<ClientViewmodel>();
            listEntity.ForEach(item =>
            {
                vms.Add(new ClientViewmodel
                {
                    name = item.Name,
                    idcli = item.Idclient,
                    Direcciones = item.Direccions.ToList()
                });
            });

            var direcciones = await _context.Direccions.ToListAsync();
            ViewData["Direcciones"] = direcciones;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewmodel clientvm)
        {
            if (ModelState.IsValid) 
            {
                var cli = new Client()
                {
                   Name=clientvm.name
     
                   
                };
                _context.Add(cli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var cliente = _context.Clients.Include(m => m.Direccions);
            ViewData["Direccion"] = new SelectList(_context.Direccions, "Iddirecc", "Direccion1");
            return View();

        }


        public async Task<IActionResult> Delete(int id)
        {
            // var cli = await _context.Clients.Where(x => x.Idclient == id).ToListAsync();

            var cli = await _context.Clients.FirstAsync(x => x.Idclient == id);
          
            
            var direcciones = await _context.Direccions.Where(x=> x.Idcli== id).ToListAsync();
            if (direcciones.Count>0) {
                foreach (var item in direcciones)
                {
                    _context.Direccions.Remove(item);
                }

            }
            
            _context.Clients.Remove(cli);
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }



    }


}
