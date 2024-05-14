using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.ShoppingCartDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CartDbContext _context;
        public OrderRepository(CartDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            return order;
        }

        public async Task<OrderDetail> AddOrderAsync(OrderDetail OrderDetail)
        {
            await _context.OrderDetails.AddAsync(OrderDetail);
            return OrderDetail;
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

