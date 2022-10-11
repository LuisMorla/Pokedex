using Microsoft.EntityFrameworkCore;
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
    public class TipoRepository : GenericRepository<Tipo>, ITipoRepository
    {
        private readonly ApplicationContext _dbcontext;

        public TipoRepository(ApplicationContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

    }
}
