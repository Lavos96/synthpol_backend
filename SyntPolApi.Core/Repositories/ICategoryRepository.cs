using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //"standard" GetAll (ShallDisplay == true)
        //full GetAll (including those with flag ShallDisplay set to false) is located in base repository (IRepository.cs)
        Task<IEnumerable<Category>> GetAsync();
        ValueTask<Category> GetByIdAsync(int id);
    }
}
