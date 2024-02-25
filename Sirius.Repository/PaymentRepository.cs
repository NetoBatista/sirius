using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;

namespace Sirius.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SiriusContext _context;
        public PaymentRepository(SiriusContext context)
        {
            _context = context;
        }

        public async Task<Payment> Create(Payment payment)
        {
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task Delete(Guid id)
        {
            var payment = _context.Payment.AsNoTracking()
                                          .Include(x => x.RegisterNavigation)
                                          .FirstOrDefault(x => x.Id == id);
            if (payment == null)
            {
                return;
            }
            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Exists(Payment payment)
        {
            return _context.Payment.AsNoTracking()
                                   .AnyAsync(x => x.Name.ToUpper() == payment.Name.ToUpper() &&
                                                  x.Id != payment.Id);
        }

        public Task<List<Payment>> GetAll()
        {
            return _context.Payment.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Payment> Update(Payment payment)
        {
            var entity = _context.Payment.AsNoTracking().First(x => x.Id == payment.Id);
            entity.Name = payment.Name;
            entity.Description = payment.Description;
            entity.Value = payment.Value;
            entity.CategoryId = payment.CategoryId;
            _context.Payment.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
