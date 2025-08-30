using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _context;

        public CategoryRepository(StoreContext context)
        {
            _context = context;
        }

        // adhere to ICategoryRepository interface
        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
           // return await _context.Categories.ToListAsync();
           return await _context
               .Categories
               .Include(c => c.Courses) // eager loading
               .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            // return await _context.Categories.FindAsync(id);
            return await _context
                .Categories
                .Include(c => c.Courses)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}