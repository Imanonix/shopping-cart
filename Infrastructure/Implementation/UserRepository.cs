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
    public class UserRepository : IUserRepository
    {
        private readonly CartDbContext _context;
        public UserRepository(CartDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<List<Order>> GetUserOrderAsync(Guid id)
        {
            List<Order> orders  = await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product).Where(o => o.UserId == id).ToListAsync();
            
            return orders ?? throw new Exception("user not found");
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
