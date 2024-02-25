using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;

namespace Sirius.Repository
{
    public class CategoryRepository(SiriusContext context) : ICategoryRepository
    {
        public async Task<Category> Create(Category category)
        {
            category.CreateAt = DateTime.UtcNow;
            context.Category.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(Guid id)
        {
            var category = context.Category.AsNoTracking()
                                            .Include(x => x.PaymentNavigation)
                                            .ThenInclude(x => x.RegisterNavigation)
                                            .FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return;
            }
            context.Category.Remove(category);
            await context.SaveChangesAsync();
        }

        public Task<bool> Exists(Category category)
        {
            return context.Category.AsNoTracking()
                                    .AnyAsync(x => x.Name.ToUpper() == category.Name.ToUpper() &&
                                                   x.Id != category.Id);
        }

        public Task<List<Category>> GetAll()
        {
            return context.Category.AsNoTracking()
                                    .OrderByDescending(x => x.CreateAt)
                                    .ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            var entity = context.Category.AsNoTracking().First(x => x.Id == category.Id);
            entity.Name = category.Name;
            entity.Description = category.Description;
            context.Category.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
