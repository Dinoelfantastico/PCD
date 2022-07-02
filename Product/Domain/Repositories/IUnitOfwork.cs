namespace Product.Domain.Repositories
{
    public interface IUnitOfwork
    {
        Task CompleteAsync();
    }
}
