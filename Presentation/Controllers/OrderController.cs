using Application.DTOs;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("/Order")]
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO orderDTO)
        {
            if(orderDTO == null)
            {
                return BadRequest();
            }

            await _orderService.AddOrderAsync(orderDTO); 
            return Ok("");
        }

        [Route("/yearly-ordersId")]
        [HttpGet]
        public async Task<IActionResult> GetYearlyOrderedProductById(string productId, int year)
        {
            Guid id = new Guid(productId);
            var result = await _orderService.GetYearlyOrderedProductById(id, year);
            var resultArray = result.ToArray();
            return Ok(resultArray);
        }


        [Route("/SalesDetail/Monthly")]
        [HttpGet]
        public async Task<IActionResult> GetMonthlySalesDetail()
        {
            var result = await _orderService.GetMonthlyOrderDetailsByProduct();
            return Ok(result);
        }
        [Route("/yearly-sales")]
        [HttpGet]
        public async Task<IActionResult> GetYearlyRevenue()
        {
            var sortedResult = await _orderService.GetYearlyRevenueAsync();
              //convert dictionary to array of object
            var resultArray = sortedResult.ToArray();

            return Ok(resultArray);
        }

        [Route("/yearly-orders")]
        [HttpGet]
        public async Task<IActionResult> GetYearlyOrder()
        {
            var sortedResult = await _orderService.GetYearlyOrdersNumberAsync();
            //convert dictionary to array of object
            var resultArray = sortedResult.ToArray();

            return Ok(resultArray);
        }

        [Route("/yearly-customers")]
        [HttpGet]
        public async Task<IActionResult> GetYearlyCustomers()
        {
            var sortedResult = await _orderService.GetYearlyCustomersNumberAsync();
            //convert dictionary to array of object
            var resultArray = sortedResult.ToArray();

            return Ok(resultArray);
        }
    }
}
