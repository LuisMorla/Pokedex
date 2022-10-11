using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Service;
using Pokedex.Core.Application.ViewModel;

namespace Pokedex.Controllers
{
    public class TipoController : Controller
    {
        private readonly ITipoService _tipo;

        public TipoController(ITipoService tipo)
        {
            _tipo = tipo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipo.GetAllViewModel());
        }

        public IActionResult SaveTipo()
        {
            return View(new saveTipoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SaveTipo(saveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipo.Add(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> EditTipo(int id)
        {
            return View("SaveTipo", await _tipo.GetByIdSave(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditTipo(saveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _tipo.Update(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("DeleteTipo", await _tipo.GetByIdSave(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _tipo.Delete(id);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
    }
}
