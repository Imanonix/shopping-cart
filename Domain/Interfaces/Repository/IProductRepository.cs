

using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsyc(Product productDTO);
        Task<bool> SaveAsync();
        Task<Dictionary<string, List<OrderDetail>>> GetProductById();
    }
}
