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
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        //ACCEDER A LOS DATOS DE LA BASE DE DATOS A TRAVEZ DEL CONTEXT

        private readonly ApplicationContext _dbContext;

        //CONSTRUCTOR
        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext=dbContext;
        }
        
        //Insert a la base de datos
        public async Task AddAsync(Entity entity) 
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        //Editar
        public async Task UpdateAsync(Entity entity)
        {
             _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        //Eliminar
        public async Task DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        //Metodo para obtener todos los pokemones guardados en la base de datos
        public async Task<List<Entity>> GetAllAsync() 
        { 
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<Entity>().AsQueryable();
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }

    }
}
