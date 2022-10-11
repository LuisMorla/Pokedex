using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Service;
using Pokedex.Core.Application.ViewModel;
using Pokedex.Infrastructure.Persistence.Context;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService  _service;
        private readonly IRegionService _rservice;
        private readonly ITipoService _tservice;

        public PokemonController(IPokemonService service, IRegionService rservice, ITipoService tservice) 
        {
            _service = service;
            _rservice = rservice;  
            _tservice = tservice;

        }
        public async Task<IActionResult> Index()
        {

            return View(await _service.GetAllViewModel());
        }

        public async Task<IActionResult> Create() 
        {
            savePokemonViewModel vm = new();
            vm.regiones = await _rservice.GetAllViewModel();
            vm.tipos = await _tservice.GetAllViewModel();
            return View("SavePokemon", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(savePokemonViewModel vm)
        {
            if (!ModelState.IsValid) 
            {
                vm.regiones = await _rservice.GetAllViewModel();
                vm.tipos = await _tservice.GetAllViewModel();
                return View("SavePokemon" ,vm);
            }
            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> EditPokemon(int id)
        {
            savePokemonViewModel vm = await _service.GetByIdSave(id);
            vm.regiones = await _rservice.GetAllViewModel();
            vm.tipos = await _tservice.GetAllViewModel();
            return View("SavePokemon", vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditPokemon(savePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.regiones = await _rservice.GetAllViewModel();
                vm.tipos = await _tservice.GetAllViewModel();
                return View("SavePokemon", vm);
            }
            await _service.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("DeletePokemon", await _service.GetByIdSave(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _service.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}
