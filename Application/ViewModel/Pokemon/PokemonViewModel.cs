using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModel
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string? PokemonName { get; set; }
        public string? PokemonDescription { get; set; }
        public string? PokemonImage { get; set; }

        public string? RegionPokemon { get; set; }
        public string? TipoPokemon { get; set; }

        //Foreign Key
        public int TypeId { get; set; }

        public int RegionId { get; set; }

    }
}
