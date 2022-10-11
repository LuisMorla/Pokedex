using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Service;
using Pokedex.Core.Application.ViewModel;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _service;

        public RegionController(IRegionService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllViewModel());
        }

        public IActionResult SaveRegion()
        {
            return View(new saveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegion(saveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> EditRegion(int id)
        {
            return View("SaveRegion", await _service.GetByIdSave(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditRegion(saveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _service.Update(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("DeleteRegion", await _service.GetByIdSave(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _service.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
