using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Models;


namespace Application.Services.Implementation
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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

        public async Task<Dictionary<int, List<KeyValue<int>>>> GetYearlyOrderedProductById(Guid productId, int year)
        {
            var result = await _orderRepository.GetYearlyOrderedProductById(productId, year);
            string[] months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var years = result.Select(x => x.Year).Distinct();
            Dictionary<int, List<KeyValue<int>>> dict = new();

            foreach (var year_ in years)
            {
                List<KeyValue<int>> cl = new();
                dict.Add(year_, cl);
                foreach (var month in months)
                {
                    var valuekey = result.FirstOrDefault(o => o.Year == year_ && o.Month == month);
                    if (valuekey != null)
                    {
                        dict[year_].Add(new KeyValue<int> { Key = valuekey.Month, Value = (int)valuekey.Amount });
                    }
                    else
                    {
                        dict[year_].Add(new KeyValue<int> { Key = month, Value = 0 });
                    }
                }
            }

            return dict;
        }

        public async Task<Dictionary<int, List<KeyValue<int>>>> GetYearlyOrdersNumberAsync()
        {
            var result = await _orderRepository.GetYearlyOrdersNumberAsync();
            string[] months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var years = result.Select(x => x.Year).Distinct();
            Dictionary<int, List<KeyValue<int>>> dict = new();

            foreach (var year in years)
            {
                List<KeyValue<int>> cl = new();
                dict.Add(year, cl);
                foreach (var month in months)
                {
                    var valuekey = result.FirstOrDefault(o => o.Year == year && o.Month == month);
                    if (valuekey != null)
                    {
                        dict[year].Add(new KeyValue<int> { Key = valuekey.Month, Value = (int)valuekey.Amount });
                    }
                    else
                    {
                        dict[year].Add(new KeyValue<int> { Key = month, Value = 0 });
                    }
                }
            }

            return dict;
        }

        public async Task<Dictionary<int, List<KeyValue<int>>>> GetYearlyCustomersNumberAsync()
        {
            var result = await _orderRepository.GetYearlyCustomersNumberAsync();
            string[] months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var years = result.Select(x => x.Year).Distinct();
            Dictionary<int, List<KeyValue<int>>> dict = new();

            foreach (var year in years)
            {
                List<KeyValue<int>> cl = new();
                dict.Add(year, cl);
                foreach (var month in months)
                {
                    var valuekey = result.FirstOrDefault(o => o.Year == year && o.Month == month);
                    if (valuekey != null)
                    {
                        dict[year].Add(new KeyValue<int> { Key = valuekey.Month, Value = (int)valuekey.Amount });
                    }
                    else
                    {
                        dict[year].Add(new KeyValue<int> { Key = month, Value = 0 });
                    }
                }
            }

            return dict;
        }

        public async Task<Dictionary<int, List<KeyValue<Decimal>>>> GetYearlyRevenueAsync()
        {
            var result = await _orderRepository.GetYearlyRevenueAsync();

            string[] months = ["January" , "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var years = result.Select(x => x.Year).Distinct();
            Dictionary<int, List<KeyValue<Decimal>>> dict = new();
            
             foreach (var year in years)
             {
                List<KeyValue<Decimal>> cl = new();
                dict.Add(year, cl);
                foreach (var month in months)
                {
                    var valuekey =result.FirstOrDefault(o => o.Year == year && o.Month == month);  
                    if (valuekey != null)
                    {
                        dict[year].Add(new KeyValue<Decimal> { Key = valuekey.Month, Value = (decimal)valuekey.Amount });
                    }
                    else
                    {
                        dict[year].Add(new KeyValue<Decimal> { Key = month, Value = 0 });
                    }
                }
            }

            return dict;
        }

        public async Task<List<TopProductsDTO>> GetBestSellingProductsAsync()
        {
            var products = await _orderRepository.GetBestSellingProductsAsync();
            products = products.OrderByDescending(p => p.Count).Take(10).ToList();
            var productsDTO = _mapper.Map<List<TopProductsDTO>>(products);

            return productsDTO;
        }

        public async Task<List<Order>> GetRecentOrdersAsync()
        {
            var orders = await _orderRepository.GetRecentOrdersAsync();
            return orders;
        }
    }
}
