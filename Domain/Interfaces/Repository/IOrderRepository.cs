using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<OrderDetail> AddOrderAsync(OrderDetail OrderDetail);
        Task<bool> SaveAsync();
    }
}
