using Application.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> AddUserAsync(UserDTO userDTO);
        Task<List<Order>> GetUserOrderAsync(Guid id);
    }
}
