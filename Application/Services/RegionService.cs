using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Service;
using Pokedex.Core.Application.ViewModel;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class RegionService:IRegionService
    {

        private readonly IRegionRepository _Repository;

        public RegionService(IRegionRepository repository)
        {
            _Repository = repository;
        }

        //Agregar Nuevo Pokemon
        public async Task Add(saveRegionViewModel vm)
        {
            Region region = new();
            region.Name = vm.Name;
            region.Description = vm.Description;
            await _Repository.AddAsync(region);

        }

        //Editar Pokemon

        public async Task<saveRegionViewModel> GetByIdSave(int id)
        {
            var Region = await _Repository.GetByIdAsync(id);
            saveRegionViewModel vm = new();
            vm.Id = Region.Id;
            vm.Name = Region.Name;
            vm.Description = Region.Description;
            return vm;
        }

        //Eliminar

        public async Task Delete(int id)
        {
            var Region = await _Repository.GetByIdAsync(id);
            await _Repository.DeleteAsync(Region);
        }

        //Actualizar

        public async Task Update(saveRegionViewModel vm)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;
            region.Description = vm.Description;
            await _Repository.UpdateAsync(region);
        }

        //Retornar un listado de pokemones
        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var RegionList = await _Repository.GetAllWithIncludeAsync(new List<string> { "Pokemons" });
            return RegionList.Select(region => new RegionViewModel
            {
                Name = region.Name,
                Description = region.Description,
                Id = region.Id,
                PokemonQuantity=region.Pokemons.Count()
            }).ToList();

        }
    }
}
