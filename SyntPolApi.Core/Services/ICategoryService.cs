using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(Category category);
        Task UpdateCategory(Category categoryToBeUpdated, Category category);
        Task DeleteCategory(Category category);

        //"standard" GetAll (ShallDisplay == true)
        Task<IEnumerable<Category>> GetAsync();
        ValueTask<Category> GetByIdAsync(int id);

        //full GetAll (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Category>> GetAllAsync();
        ValueTask<Category> GetDeletedByIdAsync(int id);
    }
}
