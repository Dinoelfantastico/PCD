using Microsoft.EntityFrameworkCore;
using Product.Domain.Models;
using Product.Domain.Repositories;
using Product.Persistence.Contexts;

namespace Product.Persistence.Repositories
{
    public class Product_Repository : BaseRepository, IProduct_Repository
    {
        public Product_Repository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product_>> ListAsync()
        {
            return await _context.Product_s.ToListAsync();
        }

        public async Task AddAsync(Product_ product_)
        {
            await _context.Product_s.AddAsync(product_);
        }

        public async Task<Product_> FindByIdAsync(int id)
        {
            return await _context.Product_s.FindAsync(id);
        }

        public void Update(Product_ product_)
        {
            _context.Product_s.Update(product_);
        }


        public void Remove(Product_ product_)
        {
            _context.Product_s.Remove(product_);
        }

       
    }
}
