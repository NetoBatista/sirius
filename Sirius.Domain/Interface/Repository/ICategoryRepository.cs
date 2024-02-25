using Sirius.Domain.Entity;

namespace Sirius.Domain.Interface.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task Delete(Guid id);
        Task<List<Category>> GetAll();
    }
}
