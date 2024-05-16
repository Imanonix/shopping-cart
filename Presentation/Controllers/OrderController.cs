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

        [Route("/Sales/Monthly/{productId}")]
        [HttpGet]
        public async Task<IActionResult> GetMonthlySales(Guid productId)
        {
            var result = await _orderService.GetMonthlyTotalSalesByProductId(productId);
            return Ok(result);
        }


        [Route("/SalesDetail/Monthly")]
        [HttpGet]
        public async Task<IActionResult> GetMonthlySalesDetail()
        {
            var result = await _orderService.GetMonthlyOrderDetailsByProduct();
            return Ok(result);
        }
    }
}
