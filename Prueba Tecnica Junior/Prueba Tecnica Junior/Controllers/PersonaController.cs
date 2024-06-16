using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_Junior.Data;
using Prueba_Tecnica_Junior.Models;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Junior.ViewModels;


namespace Prueba_Tecnica_Junior.Controllers
{
    public class PersonaController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public PersonaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult>Listar()
        {
            List<Persona> ListarPersonas=await _appDbContext.Personas.ToListAsync();
            return View(ListarPersonas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Persona CrearPersona)
        {
            if (ModelState.IsValid)
            {
                await _appDbContext.Personas.AddAsync(CrearPersona);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(CrearPersona);
        }

        [HttpGet]
        public async Task<IActionResult>Editar(int id)
        {
            Persona personas=await _appDbContext.Personas.FirstAsync(Traer=>Traer.IdPersona == id);
            return View(personas);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Persona EditPersona)
        {
                 _appDbContext.Personas.Update(EditPersona);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Persona personas = await _appDbContext.Personas.FirstAsync(Traer => Traer.IdPersona == id);
            _appDbContext.Personas.Remove(personas);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}
