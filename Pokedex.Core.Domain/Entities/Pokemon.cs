using Pokedex.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Pokemon: AuditableBaseEntity
    {
        public string? PokemonName { get; set; }
        public string? PokemonDescription { get; set; }
        public string? PokemonImage { get; set; }

        //Foreign Key
        public int TypeId { get; set; }

        public int RegionId { get; set; }

        //Navegation Property

        public Region? region { get; set; }
        public Tipo? tipo { get; set; }
    }
}
