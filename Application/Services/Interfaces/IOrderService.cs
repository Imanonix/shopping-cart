﻿using Application.DTOs;
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
        
    }
}