using Pokedex.Core.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Service
{
    public interface IGenericService<GuardarViewModel,ListViewModel> where GuardarViewModel:class where ListViewModel:class
    {
        Task Add(GuardarViewModel vm);
        Task<GuardarViewModel> GetByIdSave(int id);
        Task Delete(int id);
        Task Update(GuardarViewModel vm);
        Task<List<ListViewModel>> GetAllViewModel();
    }
}
