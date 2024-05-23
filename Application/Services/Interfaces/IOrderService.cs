using Application.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO);
        Task<Dictionary<string, List<OrderDetail>>> GetMonthlyOrderDetailsByProduct();
        Task<Dictionary<int, List<KeyValue<int>>>> GetYearlyOrderedProductById(Guid productId, int year);
        Task<Dictionary<int, List<KeyValue<Decimal>>>> GetYearlyRevenueAsync();
        Task<Dictionary<int, List<KeyValue<int>>>> GetYearlyOrdersNumberAsync();
        Task<Dictionary<int, List<KeyValue<int>>>> GetYearlyCustomersNumberAsync();
    }
}
