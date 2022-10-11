using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Service;
using Pokedex.Core.Application.ViewModel;
using Pokedex.Core.Application.ViewModel.Pokemon;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class PokemonService:IPokemonService
    {
        private readonly IPokemonRepository _Repository;

        public PokemonService(IPokemonRepository repository) 
        {
            _Repository = repository;
        }

        //Agregar Nuevo Pokemon
        public async Task Add(savePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.PokemonName=vm.PokemonName;
            pokemon.PokemonDescription=vm.PokemonDescription;
            pokemon.PokemonImage=vm.PokemonImage;
            pokemon.RegionId=vm.RegionId;
            pokemon.TypeId=vm.TypeId;
            await _Repository.AddAsync(pokemon);
        }

        //Editar Pokemon

        public async Task<savePokemonViewModel> GetByIdSave(int id)
        {
            var Pokemon = await _Repository.GetByIdAsync(id);
            savePokemonViewModel vm = new();
            vm.Id = Pokemon.Id;
            vm.PokemonName = Pokemon.PokemonName;
            vm.PokemonDescription = Pokemon.PokemonDescription;
            vm.PokemonImage = Pokemon.PokemonImage;
            vm.RegionId = Pokemon.RegionId;
            vm.TypeId=Pokemon.TypeId;
            return vm;
        }

        //Eliminar

        public async Task Delete(int id)
        {
            var Pokemon = await _Repository.GetByIdAsync(id);
            await _Repository.DeleteAsync(Pokemon);
        }

        //Actualizar

        public async Task Update(savePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.Id=vm.Id;
            pokemon.PokemonName = vm.PokemonName;
            pokemon.PokemonDescription = vm.PokemonDescription;
            pokemon.PokemonImage = vm.PokemonImage;
            pokemon.RegionId = vm.RegionId;
            pokemon.TypeId = vm.TypeId;
            await _Repository.UpdateAsync(pokemon);
        }



        //Retornar un listado de pokemones
        public async Task<List<PokemonViewModel>> GetAllViewModel() 
            {
            var PokemonList= await _Repository.GetAllWithIncludeAsync(new List<string> { "region", "tipo" });
            return PokemonList.Select(pokemon => new PokemonViewModel
            {
                PokemonName = pokemon.PokemonName,
                PokemonDescription = pokemon.PokemonDescription,
                Id = pokemon.Id,
                RegionId = pokemon.RegionId,
                TypeId = pokemon.TypeId,
                PokemonImage = pokemon.PokemonImage,
                RegionPokemon=pokemon.region.Name,
                TipoPokemon=pokemon.tipo.Name

            }).ToList();
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FiltroPokemonViewModel filtro)
        {
            var PokemonList = await _Repository.GetAllWithIncludeAsync(new List<string> { "region", "tipo" });

            var vmlist = PokemonList.Select(pokemon=>new PokemonViewModel
            {
                PokemonName = pokemon.PokemonName,
                PokemonDescription = pokemon.PokemonDescription,
                Id = pokemon.Id,
                RegionId = pokemon.RegionId,
                TypeId = pokemon.TypeId,
                PokemonImage = pokemon.PokemonImage,
                RegionPokemon = pokemon.region.Name,
                TipoPokemon = pokemon.tipo.Name

            }).ToList();

            if (filtro.IdRegion != null)
            {
                vmlist = vmlist.Where(p=>p.RegionId == filtro.IdRegion.Value).ToList();
            }
            return vmlist;
        }

        //-------------------------------

        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilterSearch(FiltroPokemonViewModel filtro)
        {
            var PokemonList = await _Repository.GetAllWithIncludeAsync(new List<string> { "region", "tipo" });

            var vmlist = PokemonList.Select(pokemon => new PokemonViewModel
            {
                PokemonName = pokemon.PokemonName,
                PokemonDescription = pokemon.PokemonDescription,
                Id = pokemon.Id,
                RegionId = pokemon.RegionId,
                TypeId = pokemon.TypeId,
                PokemonImage = pokemon.PokemonImage,
                RegionPokemon = pokemon.region.Name,
                TipoPokemon = pokemon.tipo.Name

            }).ToList();

            if (filtro.NamePokemonFilter != null)
            {
                vmlist = vmlist.Where(p => p.PokemonName == filtro.NamePokemonFilter).ToList();
            }
            return vmlist;
        }
    }
}
