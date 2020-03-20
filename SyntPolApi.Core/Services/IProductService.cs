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
        Task DeleteProduct(int id);

        //"standard" GetAll (ShallDisplay == true)
        Task<IEnumerable<Product>> GetAsync();
        ValueTask<Product> GetByIdAsync(int id);

        //full GetAll (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Product>> GetAllAsync();
        ValueTask<Product> GetDeletedByIdAsync(int id);


        //"standard" GetAllWith (ShallDisplay == true)
        Task<IEnumerable<Product>> GetProductsByProviderAsync(int provId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int catId);
        Task<IEnumerable<Product>> GetProductsByCategoryAndProviderAsync(int catId, int provId);

        //full GetAllWith (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Product>> GetAllProductsByProviderAsync(int provId);
        Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int catId);
        Task<IEnumerable<Product>> GetAllProductsByCategoryAndProviderAsync(int catId, int provId);
    }
}
