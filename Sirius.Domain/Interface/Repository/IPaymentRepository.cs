using Sirius.Domain.Entity;

namespace Sirius.Domain.Interface.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> Create(Payment payment);
        Task<Payment> Update(Payment payment);
        Task Delete(Guid id);
        Task<List<Payment>> GetAll();
        Task<Payment> GetById(Guid id);
        Task<bool> Exists(Payment payment);
    }
}
