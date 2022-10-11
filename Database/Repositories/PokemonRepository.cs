using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class PokemonRepository:GenericRepository<Pokemon>, IPokemonRepository
    {

        private readonly ApplicationContext _dbcontext;
        public PokemonRepository(ApplicationContext dbcontext):base(dbcontext) 
        {
            _dbcontext=dbcontext;
        }
    }
}
