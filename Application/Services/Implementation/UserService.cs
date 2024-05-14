using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveAsync();
            return userDTO; 
        }

        public async Task<List<Order>> GetUserOrderAsync(Guid id)
        {
            var user = await _userRepository.GetUserOrderAsync(id);
            return user;
        }
    }
}
