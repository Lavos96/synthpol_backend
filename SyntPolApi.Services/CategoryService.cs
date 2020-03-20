using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.CommitAsync();
            return category;
        }

        public async Task DeleteCategory(int id)
        {
            unitOfWork.Categories.Remove(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await unitOfWork.Categories.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await unitOfWork.Categories.GetAsync();
        }

        public async ValueTask<Category> GetByIdAsync(int id)
        {
            return await unitOfWork.Categories.GetByIdAsync(id);
        }

        public async ValueTask<Category> GetDeletedByIdAsync(int id)
        {
            return await unitOfWork.Categories.GetFromAllByIdAsync(id);
        }

        public async Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.CategoryId = category.CategoryId;
            categoryToBeUpdated.CategoryName = category.CategoryName;
            categoryToBeUpdated.ShallDisplay = category.ShallDisplay;

            await unitOfWork.CommitAsync();
        }
    }
}
