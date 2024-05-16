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

        public async Task<Dictionary<string, List<OrderDetail>>> GetMonthlyOrderDetailsByProduct()
        {
            var result = await _context.OrderDetails.Include(od => od.Product).GroupBy(od => new { od.Title, od.Order.CreateDate.Month }).ToDictionaryAsync(g => $"{g.Key.Title}-{g.Key.Month}", g => g.ToList());
            return result;
        }

        public async Task<Dictionary<string, int>> GetMonthlyTotalSalesByProductId(Guid productId)
        {
            var quantity = await _context.OrderDetails.Where(od => od.ProductId == productId).GroupBy(od => new { od.Product.Title, od.Order.CreateDate.Month }).ToDictionaryAsync(g => $"{g.Key.Title}-{g.Key.Month}", g => g.Sum(c => c.Count));
            return quantity;
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

