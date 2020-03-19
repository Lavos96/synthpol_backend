using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //"standard" GetAll (ShallDisplay == true)
        //full GetAll (including those with flag ShallDisplay set to false) is located in base repository (IRepository.cs)
        Task<IEnumerable<Product>> GetAsync();
        ValueTask<Product> GetByIdAsync(int id);

        //"standard" GetAllWith (ShallDisplay == true)
        Task<IEnumerable<Product>> GetProductsWithProviderAsync();
        Task<IEnumerable<Product>> GetProductsWithCategoryAsync();
        Task<IEnumerable<Product>> GetProductsWithCategoryAndProviderAsync();

        //full GetAllWith (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Product>> GetAllProductsWithProviderAsync();
        Task<IEnumerable<Product>> GetAllProductsWithCategoryAsync();
        Task<IEnumerable<Product>> GetAllProductsWithCategoryAndProviderAsync();
    }
}
