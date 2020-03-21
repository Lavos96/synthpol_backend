﻿using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
        //"standard" GetAll (ShallDisplay == true)
        //full GetAll (including those with flag ShallDisplay set to false) is located in base repository (IRepository.cs)
        Task<IEnumerable<Provider>> GetAsync();
        ValueTask<Provider> GetByIdAsync(int id);

        //remove does not actually remove (updates ShallDisplay to false instead)
        Task Remove(int id);
    }
}
