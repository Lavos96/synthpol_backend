using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProviderRepository Providers { get; }
        ICategoryRepository Categories { get; }
        Task<int> CommitAsync();
    }
}
