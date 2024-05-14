using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.ShoppingCartDbContext;
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

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
