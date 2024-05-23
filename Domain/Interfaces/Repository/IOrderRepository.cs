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
        Task<Dictionary<string, List<OrderDetail>>> GetMonthlyOrderDetailsByProduct();
        Task<List<YearlyData<int>>> GetYearlyOrderedProductById(Guid productId, int year);
        //Task<Dictionary<int, List<Order>>> GetYearlyRevenueAsync();
        Task<List<YearlyData<Decimal>>> GetYearlyRevenueAsync();
        Task<List<YearlyData<int>>> GetYearlyOrdersNumberAsync();
        Task<List<YearlyData<int>>> GetYearlyCustomersNumberAsync();
        Task<bool> SaveAsync();
    }
}
