using InventopryWEB2026.Domin;
using InventopryWEB2026.Infrastructure.DataBase;
using InventopryWEB2026.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventopryWEB2026.Infrastructure.Repositories.Implementations
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.Include(w => w.Shelves).ThenInclude(s => s.Products).ToListAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _context.Warehouses.Include(w => w.Shelves).ThenInclude(s => s.Products).FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task AddAsync(Warehouse warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
            }
        }
    }
}