using InventopryWEB2026.Domin;

namespace InventopryWEB2026.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {

        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
