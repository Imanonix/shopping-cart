using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.ShoppingCartDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var result = await _context.OrderDetails.Include(od => od.Product).GroupBy(od => new { od.Title, od.Order.CreateDate.Month }).ToDictionaryAsync(g => $"{g.Key.Title}-{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)}", g => g.ToList());
            return result;
        }

        public async Task<List<YearlyData<int>>> GetYearlyOrderedProductById(Guid productId, int year)
        {
            var result = await _context.OrderDetails.Where(od => od.ProductId == productId && od.Order.CreateDate.Year == year).GroupBy(od => new { od.Order.CreateDate.Month }).Select(g => new YearlyData<int>
            {
                Year = year,
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month),
                Amount = g.Sum(g => g.Count)
            }).ToListAsync() ;
            return result;
        }

        public async Task<List<YearlyData<int>>> GetYearlyCustomersNumberAsync()
        {
            var result = await _context.Orders.GroupBy(o => new { o.CreateDate.Year, o.CreateDate.Month }).Select(g => new YearlyData<int>
            {
                Year = g.Key.Year,
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month),
                Amount = g.Select(o => o.UserId).Distinct().Count()
            }).ToListAsync();

            return result;
        }

        public async Task<List<YearlyData<int>>> GetYearlyOrdersNumberAsync()
        {
            var result = await _context.Orders.GroupBy(o => new { o.CreateDate.Year, o.CreateDate.Month }).Select(g => new YearlyData<int>
            {
                Year = g.Key.Year,
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month),
                Amount = g.Count()
            }).ToListAsync();
            return result;
        }

        public async Task<List<YearlyData<Decimal>>> GetYearlyRevenueAsync()
        {

            var result = await _context.Orders.GroupBy(o => new { o.CreateDate.Year, o.CreateDate.Month }).Select(g => new YearlyData<Decimal>
            {
                Year = g.Key.Year,
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month),
                Amount = g.Sum(o => o.OrderSum)
            }).ToListAsync();

            return result;
        }

        public Task<List<TopProducts>> GetBestSellingProductsAsync()
        {
            var products = _context.OrderDetails.GroupBy(od => new { od.ProductId, od.Title }).Select(g => new TopProducts
            {
                ProductId = g.Key.ProductId,
                Count = g.Sum(od => od.Count),
                Title = g.Key.Title
            }).ToListAsync();
            return products;
        }
        public async Task<List<Order>> GetRecentOrdersAsync()
        {
            var orders = await _context.Orders.Include(o => o.OrderDetails).OrderByDescending(o => o.CreateDate).Take(100).ToListAsync();
            return orders;
        }
        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}

