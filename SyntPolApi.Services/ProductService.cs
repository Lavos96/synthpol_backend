using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.CommitAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            unitOfWork.Products.Remove(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await unitOfWork.Products.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAndProviderAsync(int catId, int provId)
        {
            return await unitOfWork.Products.GetAllProductsByCategoryAndProviderAsync(catId, provId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int catId)
        {
            return await unitOfWork.Products.GetAllProductsByCategoryAsync(catId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByProviderAsync(int provId)
        {
            return await unitOfWork.Products.GetAllProductsByProviderAsync(provId);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await unitOfWork.Products.GetAsync();
        }

        public async ValueTask<Product> GetByIdAsync(int id)
        {
            return await unitOfWork.Products.GetByIdAsync(id);
        }

        public async ValueTask<Product> GetDeletedByIdAsync(int id)
        {
            return await unitOfWork.Products.GetFromAllByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndProviderAsync(int catId, int provId)
        {
            return await unitOfWork.Products.GetProductsByCategoryAndProviderAsync(catId, provId);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int catId)
        {
            return await unitOfWork.Products.GetProductsByCategoryAsync(catId);
        }

        public async Task<IEnumerable<Product>> GetProductsByProviderAsync(int provId)
        {
            return await unitOfWork.Products.GetProductsByProviderAsync(provId);
        }

        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            productToBeUpdated.CategoryId = product.CategoryId;
            productToBeUpdated.Description = product.Description;
            productToBeUpdated.Name = product.Name;
            productToBeUpdated.NettoPrice = product.NettoPrice;
            productToBeUpdated.PhotoString = product.PhotoString;
            productToBeUpdated.ProductId = product.ProductId;
            productToBeUpdated.ProviderId = product.ProviderId;
            productToBeUpdated.ShallDisplay = product.ShallDisplay;
            productToBeUpdated.VAT = product.VAT;

            await unitOfWork.CommitAsync();
        }
    }
}
