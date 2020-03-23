using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;

        public OrderItemRepository(SyntPolApiDbContext context) : base(context)
        {
            syntPolApiDbContext = context;
        }

    }
}
