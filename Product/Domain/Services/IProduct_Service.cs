using Product.Domain.Models;
using Product.Domain.Services.Comunication;

namespace Product.Domain.Services
{
    public interface IProduct_Service
    {
        Task<IEnumerable<Product_>> ListAsync();
        Task<Product_Response> SaveAsync(Product_ product_);
        Task<Product_Response> UpdateAsync(int id, Product_ product_);
        Task<Product_Response> DeleteAsync(int id);
    }
}
