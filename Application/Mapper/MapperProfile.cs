using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<TopProducts, TopProductsDTO>().ReverseMap();
        }
    }
}
