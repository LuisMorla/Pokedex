using Pokedex.Core.Application.ViewModel;
using Pokedex.Core.Application.ViewModel.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Service
{
    public interface IPokemonService:IGenericService<savePokemonViewModel, PokemonViewModel>
    {
        Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FiltroPokemonViewModel filtroPokemon);
        Task<List<PokemonViewModel>> GetAllViewModelWithFilterSearch(FiltroPokemonViewModel filtroPokemon);
    }
}
