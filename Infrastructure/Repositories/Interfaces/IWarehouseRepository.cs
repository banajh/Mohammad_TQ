using InventopryWEB2026.Domin;

namespace InventopryWEB2026.Infrastructure.Repositories.Interfaces
{
    public interface IWarehouseRepository
    {

        Task<List<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(int id);
        Task AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
    }
}
