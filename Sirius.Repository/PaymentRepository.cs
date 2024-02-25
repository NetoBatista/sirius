using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;

namespace Sirius.Repository
{
    public class PaymentRepository(SiriusContext context) : IPaymentRepository
    {
        public async Task<Payment> Create(Payment payment)
        {
            context.Payment.Add(payment);
            await context.SaveChangesAsync();
            return payment;
        }

        public async Task Delete(Guid id)
        {
            var payment = context.Payment.AsNoTracking()
                                          .Include(x => x.RegisterNavigation)
                                          .FirstOrDefault(x => x.Id == id);
            if (payment == null)
            {
                return;
            }
            context.Payment.Remove(payment);
            await context.SaveChangesAsync();
        }

        public Task<bool> Exists(Payment payment)
        {
            return context.Payment.AsNoTracking()
                                   .AnyAsync(x => x.Name.ToUpper() == payment.Name.ToUpper() &&
                                                  x.Id != payment.Id);
        }

        public Task<List<Payment>> GetAll()
        {
            return context.Payment.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Payment> Update(Payment payment)
        {
            var entity = context.Payment.AsNoTracking().First(x => x.Id == payment.Id);
            entity.Name = payment.Name;
            entity.Description = payment.Description;
            entity.Value = payment.Value;
            entity.CategoryId = payment.CategoryId;
            entity.PayDay = payment.PayDay;
            context.Payment.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
