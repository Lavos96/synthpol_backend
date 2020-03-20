using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProviderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Provider> CreateProvider(Provider provider)
        {
            await unitOfWork.Providers.AddAsync(provider);
            await unitOfWork.CommitAsync();
            return provider;
        }

        public async Task DeleteProvider(int id)
        {
            unitOfWork.Providers.Remove(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await unitOfWork.Providers.GetAllAsync();
        }

        public async Task<IEnumerable<Provider>> GetAsync()
        {
            return await unitOfWork.Providers.GetAsync();
        }

        public async ValueTask<Provider> GetByIdAsync(int id)
        {
            return await unitOfWork.Providers.GetByIdAsync(id);
        }

        public async ValueTask<Provider> GetDeletedByIdAsync(int id)
        {
            return await unitOfWork.Providers.GetFromAllByIdAsync(id);
        }

        public async Task UpdateProvider(Provider providerToBeUpdated, Provider provider)
        {
            providerToBeUpdated.City = provider.City;
            providerToBeUpdated.FirstName = provider.FirstName;
            providerToBeUpdated.HomeNumber = provider.HomeNumber;
            providerToBeUpdated.LastName = provider.LastName;
            providerToBeUpdated.NIP = provider.NIP;
            providerToBeUpdated.ProviderId = provider.ProviderId;
            providerToBeUpdated.ProviderNumber = provider.ProviderNumber;
            providerToBeUpdated.ShallDisplay = provider.ShallDisplay;
            providerToBeUpdated.Street = provider.Street;
            providerToBeUpdated.ZipCode = provider.ZipCode;

            await unitOfWork.CommitAsync();
        }
    }
}
