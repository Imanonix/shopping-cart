using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepository 
    {
        Task<User> AddUserAsync(User user);
        Task<List<Order>> GetUserOrderAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
