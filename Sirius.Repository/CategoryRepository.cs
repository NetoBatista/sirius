using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;

namespace Sirius.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SiriusContext _context;
        public CategoryRepository(SiriusContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            category.CreateAt = DateTime.UtcNow;
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(Guid id)
        {
            var category = _context.Category.AsNoTracking()
                                            .Include(x => x.PaymentNavigation)
                                            .ThenInclude(x => x.RegisterNavigation)
                                            .FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return;
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Exists(Category category)
        {
            return _context.Category.AsNoTracking()
                                    .AnyAsync(x => x.Name.ToUpper() == category.Name.ToUpper() &&
                                                   x.Id != category.Id);
        }

        public Task<List<Category>> GetAll()
        {
            return _context.Category.AsNoTracking()
                                    .OrderByDescending(x => x.CreateAt)
                                    .ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            var entity = _context.Category.AsNoTracking().First(x => x.Id == category.Id);
            entity.Name = category.Name;
            entity.Description = category.Description;
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
