using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
   
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            Order order = new Order()
            {
                OrderSum = orderDTO.OrderSum, 
                UserId = orderDTO.UserId
            };
            order = await _orderRepository.AddOrderAsync(order);
            
            foreach (var item in orderDTO.orderDetailDTOs)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Count = item.Count,
                    ProductPrice = item.ProductPrice
                };
                await _orderRepository.AddOrderAsync(orderDetail);
            }
            await _orderRepository.SaveAsync();
            return orderDTO;
        }

        public async Task<Dictionary<string, List<OrderDetail>>> GetMonthlyOrderDetailsByProduct()
        {
            var result = await _orderRepository.GetMonthlyOrderDetailsByProduct();
            return result;
        }

        public async Task<Dictionary<string, int>> GetMonthlyTotalSalesByProductId(Guid productId)
        {
            var result = await _orderRepository.GetMonthlyTotalSalesByProductId(productId);
            return result;
        }
    }
}
