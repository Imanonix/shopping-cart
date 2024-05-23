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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            product = await _productRepository.AddProductAsyc(product);
            await _productRepository.SaveAsync();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task<List<ProductDTO>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllProductAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);
            return productsDTO;
        }
    }
}
