using Application.DTOs;
using Domain.Models;


namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> AddProductAsync(ProductDTO product);
        Task<List<ProductDTO>> GetAllProductAsync();
    }
}
