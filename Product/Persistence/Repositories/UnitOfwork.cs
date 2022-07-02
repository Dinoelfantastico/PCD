using Product.Domain.Repositories;
using Product.Persistence.Contexts;

namespace Product.Persistence.Repositories
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly AppDbContext _context;

        public UnitOfwork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
