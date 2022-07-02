using Product.Domain.Models;

namespace Product.Domain.Repositories
{
    public interface IProduct_Repository
    {
        Task<IEnumerable<Product_>> ListAsync();
        Task AddAsync(Product_ product_);
        Task<Product_> FindByIdAsync(int id);
        void Update(Product_ product_);
        void Remove(Product_ product_);
    }
}
