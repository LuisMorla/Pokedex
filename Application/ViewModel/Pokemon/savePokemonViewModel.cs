using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModel
{
    public class savePokemonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe Colocar El Nombre Del Pokemon")]
        public string? PokemonName { get; set; }

        public string? PokemonDescription { get; set; }

        [Required(ErrorMessage = "Debe Colocar la Imagen Del Pokemon")]
        public string? PokemonImage { get; set; }

        //Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el Tipo del pokemón")]
        public int TypeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Debe colocar la Región del pokemón")]
        public int RegionId { get; set; }

        public List<RegionViewModel>? regiones { get; set; }
        public List<TipoViewModel>? tipos { get; set; }
    }
}
