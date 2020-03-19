using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product productToBeUpdated, Product product);
        Task DeleteProduct(Product product);

        //"standard" GetAll (ShallDisplay == true)
        Task<IEnumerable<Product>> GetAsync();
        ValueTask<Product> GetByIdAsync(int id);

        //full GetAll (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Product>> GetAllAsync();
        ValueTask<Product> GetDeletedByIdAsync(int id);


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
