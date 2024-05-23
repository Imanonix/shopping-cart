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
    public class ProductRepository : IProductRepository
    {
        private readonly CartDbContext _context;
        public ProductRepository(CartDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsyc(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Dictionary<string, List<OrderDetail>>> GetProductById()
        {
            var result = await _context.OrderDetails.Include(od => od.Product).GroupBy(o => new {o.Title, o.Order.CreateDate.Month }).ToDictionaryAsync(g => $"{g.Key.Title}-{g.Key.Month}", g => g.ToList()); //.Sum(e =>  e.Count)
            return result;
        }



        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
