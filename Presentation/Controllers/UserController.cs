using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("/AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the model is not valid");
            }
            if (userDTO == null)
            {
                return BadRequest();
            }
            var user = await _userService.AddUserAsync(userDTO);
            return Ok(user);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var orders = await _userService.GetUserOrderAsync(id);
            return Ok(orders);
        }
    }
}
