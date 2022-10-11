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
    public class TipoService:ITipoService
    {
        private readonly ITipoRepository _Repository;

        public TipoService(ITipoRepository repository)
        {
            _Repository = repository;
        }

        public async Task Add(saveTipoViewModel vm)
        {
            Tipo tipo = new();
            tipo.Name = vm.Name;
            tipo.Description = vm.Description;
            await _Repository.AddAsync(tipo);

        }

        //Editar Pokemon

        public async Task<saveTipoViewModel> GetByIdSave(int id)
        {
            var Tipo = await _Repository.GetByIdAsync(id);
            saveTipoViewModel vm = new();
            vm.Id = Tipo.Id;
            vm.Name = Tipo.Name;
            vm.Description = Tipo.Description;
            return vm;
        }

        //Eliminar

        public async Task Delete(int id)
        {
            var Tipo = await _Repository.GetByIdAsync(id);
            await _Repository.DeleteAsync(Tipo);
        }

        //Actualizar

        public async Task Update(saveTipoViewModel vm)
        {
            Tipo tipo = new();
            tipo.Id = vm.Id;
            tipo.Name = vm.Name;
            tipo.Description = vm.Description;
            await _Repository.UpdateAsync(tipo);
        }

        //Retornar un listado de pokemones
        public async Task<List<TipoViewModel>> GetAllViewModel()
        {
            var TipoList = await _Repository.GetAllAsync();
            return TipoList.Select(tipo => new TipoViewModel
            {
                Name = tipo.Name,
                Description = tipo.Description,
                Id = tipo.Id,

            }).ToList();

        }
    }
}
