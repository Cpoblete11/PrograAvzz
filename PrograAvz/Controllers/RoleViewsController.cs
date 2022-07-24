using ASP.NETCoreIdentityCustom.Core;
using form.Models.DAL;
using form.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class RoleViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = Constants.Policies.RequireManager)]
        public IActionResult Manager()
        {
            return View();
        }

        static PersonaDAL dal = new PersonaDAL();

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Admin()
        {
            return View(dal.get());
        }
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        public IActionResult Admin(string nombre, string apellido)
        {
            Persona persona = new Persona(nombre, apellido);

            dal.agregar(persona);
            return View(dal.get());
        }
       [Authorize(Policy = "RequireAdmin")]
        [HttpGet]
        public IActionResult Admin(int id)
        {
            dal.borrar(id);
            return View(dal.get());
        }
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        public IActionResult Modificar(int id, string nombre, string apellido)
        {
            dal.modificar(id, nombre, apellido);
            return RedirectToAction("Admin", "RoleViews");
        }
       [Authorize(Policy = "RequireAdmin")]
        [HttpGet]
        public IActionResult Editar(int id, string nombre, string apellido)
        {
            ViewData["id"] = id;
            ViewData["nombre"] = nombre;
            ViewData["apellido"] = apellido;
            return View();
        }

    }
}
