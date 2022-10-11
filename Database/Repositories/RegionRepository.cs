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
    public class RegionRepository:GenericRepository<Region>, IRegionRepository
    {
        private readonly ApplicationContext _dbcontext;

        public RegionRepository(ApplicationContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

    }

    
}
