using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Service;
using Pokedex.Core.Application.Services;
using Pokedex.Core.Application.ViewModel.Pokemon;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _service;
        private readonly IRegionService _regionService;

        public HomeController(IPokemonService service, IRegionService regionService)
        {
            _service = service;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index(FiltroPokemonViewModel vm)
        {
            ViewBag.Region = await _regionService.GetAllViewModel();
            return View(await _service.GetAllViewModelWithFilters(vm));
        }

        public async Task<IActionResult> Buscar(FiltroPokemonViewModel vm)
        {
            ViewBag.Region = await _regionService.GetAllViewModel();

            if (string.IsNullOrEmpty(vm.NamePokemonFilter))
            {
                return RedirectToAction("Index");
            }
            var response = await _service.GetAllViewModelWithFilterSearch(vm);

            return View("Index", response);
        }


    }
}
