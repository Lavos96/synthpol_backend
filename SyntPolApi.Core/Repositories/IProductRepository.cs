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
        Task<IEnumerable<Product>> GetProductsByProviderAsync(int provId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int catId);
        Task<IEnumerable<Product>> GetProductsByCategoryAndProviderAsync(int catId, int provId);

        //full GetAllWith (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Product>> GetAllProductsByProviderAsync(int provId);
        Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int catId);
        Task<IEnumerable<Product>> GetAllProductsByCategoryAndProviderAsync(int catId, int provId);

        //remove does not actually remove (updates ShallDisplay to false instead)
        void Remove(int id);
    }
}
