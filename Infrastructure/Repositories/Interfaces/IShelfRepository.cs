using InventopryWEB2026.Domin;

namespace InventopryWEB2026.Infrastructure.Repositories.Interfaces
{
    public interface IShelfRepository
    {
        Task<List<Shelf>> GetAllAsync();
        Task<Shelf> GetByIdAsync(int id);
        Task AddAsync(Shelf shelf);
        Task UpdateAsync(Shelf shelf);
        Task DeleteAsync(int id);
    }
}
