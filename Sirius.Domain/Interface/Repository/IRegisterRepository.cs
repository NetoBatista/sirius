using Sirius.Domain.Entity;

namespace Sirius.Domain.Interface.Repository
{
    public interface IRegisterRepository
    {
        Task<Register> Create(Register register);
        Task<Register> Update(Register register);
        Task Delete(Guid id);
        Task<List<Register>> GetAll(DateTime startDate, DateTime finalDate);
        Task<List<Register>> GetAll();
    }
}
