using InventopryWEB2026.Domin;
using InventopryWEB2026.Infrastructure.DataBase;
using InventopryWEB2026.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventopryWEB2026.Infrastructure.Repositories.Implementations
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly AppDbContext _context;

        public ShelfRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Shelf>> GetAllAsync()
        {
            return await _context.Shelves.Include(s => s.Warehouse).Include(s => s.Products).ToListAsync();
        }

        public async Task<Shelf> GetByIdAsync(int id)
        {
            return await _context.Shelves.Include(s => s.Warehouse).Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            _context.Shelves.Update(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            if (shelf != null)
            {
                _context.Shelves.Remove(shelf);
                await _context.SaveChangesAsync();
            }
        }
    }
}