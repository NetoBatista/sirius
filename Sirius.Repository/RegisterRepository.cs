﻿using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;

namespace Sirius.Repository
{
    public class RegisterRepository(SiriusContext context) : IRegisterRepository
    {
        public async Task<Register> Create(Register register)
        {
            context.Register.Add(register);
            await context.SaveChangesAsync();
            return register;
        }

        public async Task Delete(Guid id)
        {
            var register = context.Register.AsNoTracking()
                                           .First(x => x.Id == id);
            context.Register.Remove(register);
            await context.SaveChangesAsync();
        }

        public Task<List<Register>> GetAll(DateTime startDate, DateTime finalDate)
        {
            return context.Register.Include(x => x.PaymentNavigation)
                                   .AsNoTracking()
                                   .Where(x => x.PaidAt >= startDate && x.PaidAt <= finalDate)
                                   .OrderByDescending(x => x.PaidAt)
                                   .ToListAsync();
        }

        public Task<List<Register>> GetAll()
        {
            return context.Register.Include(x => x.PaymentNavigation)
                                   .AsNoTracking()
                                   .OrderByDescending(x => x.PaidAt)
                                   .ToListAsync();
        }

        public async Task<Register> Update(Register register)
        {
            var entity = context.Register.AsNoTracking().First(x => x.Id == register.Id);
            entity.Value = register.Value;
            entity.PaymentId = register.PaymentId;
            entity.PaidAt = register.PaidAt;
            context.Register.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
