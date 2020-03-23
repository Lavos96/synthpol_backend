using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface IProviderService
    {
        Task<Provider> CreateProvider(Provider provider);
        Task UpdateProvider(Provider providerToBeUpdated, Provider provider);
        Task DeleteProvider(int id);

        //"standard" GetAll (ShallDisplay == true)
        Task<IEnumerable<Provider>> GetAsync();
        ValueTask<Provider> GetByIdAsync(int id);

        //full GetAll (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Provider>> GetAllAsync();
        ValueTask<Provider> GetDeletedByIdAsync(int id);
    }
}
