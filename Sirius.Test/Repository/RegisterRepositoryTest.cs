using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Repository;
using Sirius.Test.Util;

namespace Sirius.Test.Repository
{
    [TestClass]
    public class RegisterRepositoryTest
    {
        private static IRegisterRepository RegisterRepository
        {
            get
            {
                var siriusContext = GetContext();
                return new RegisterRepository(siriusContext);
            }
        }

        private static SiriusContext GetContext()
        {
            var options = new DbContextOptionsBuilder<SiriusContext>()
                                      .UseInMemoryDatabase(databaseName: "Sirius")
                                      .Options;
            var siriusContext = new SiriusContext(options);
            return siriusContext;
        }

        [TestMethod("Should be create a register")]
        public async Task Create()
        {
            var register = EntityRandomUtil.Register();
            register.PaymentNavigation = EntityRandomUtil.Payment();
            var created = await RegisterRepository.Create(register);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);
        }

        [TestMethod("Should be update a existing register")]
        public async Task UpdateExisting()
        {
            var register = EntityRandomUtil.Register();
            register.PaymentNavigation = EntityRandomUtil.Payment();
            var created = await RegisterRepository.Create(register);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);

            var newPaidAt = DateTime.UtcNow.AddDays(1);
            var newValue = 500;
            created.PaidAt = newPaidAt;
            created.Value = newValue;

            var updated = await RegisterRepository.Update(created);
            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Id, created.Id);
            Assert.AreEqual(updated.PaidAt, newPaidAt);
            Assert.AreEqual(updated.Value, newValue);
        }

        [TestMethod("Should not be update if the register not existing")]
        public async Task UpdateNotExisting()
        {
            var register = EntityRandomUtil.Register();
            var action = () => RegisterRepository.Update(register);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be delete a existing register")]
        public async Task DeleteExisting()
        {
            var register = EntityRandomUtil.Register();
            register.PaymentNavigation = EntityRandomUtil.Payment();
            var created = await RegisterRepository.Create(register);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);

            await RegisterRepository.Delete(created.Id);
            var currentDate = DateTime.UtcNow;
            var startDate = new DateTime(currentDate.Year, currentDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var finalDate = new DateTime(currentDate.Year, currentDate.Month, 1, 23, 59, 59, DateTimeKind.Utc).AddMonths(2).AddDays(-1);
            var registers = await RegisterRepository.GetAll(startDate, finalDate);
            Assert.IsFalse(registers.Any(x => x.Id == created.Id));
        }

        [TestMethod("Should not be delete if the register not existing")]
        public async Task DeleteNotExisting()
        {
            var action = () => RegisterRepository.Delete(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be get all register by date")]
        public async Task GetAllByDate()
        {
            var register = EntityRandomUtil.Register();
            register.PaymentNavigation = EntityRandomUtil.Payment();
            var created = await RegisterRepository.Create(register);
            var currentDate = DateTime.UtcNow;
            var startDate = new DateTime(currentDate.Year, currentDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var finalDate = new DateTime(currentDate.Year, currentDate.Month, 1, 23, 59, 59, DateTimeKind.Utc).AddMonths(2).AddDays(-1);
            var registers = await RegisterRepository.GetAll(startDate, finalDate);
            Assert.IsNotNull(registers);
            Assert.IsTrue(registers.Any(x => x.Id == created.Id));
        }

        [TestMethod("Should be get all register")]
        public async Task GetAll()
        {
            var register = EntityRandomUtil.Register();
            register.PaymentNavigation = EntityRandomUtil.Payment();
            var created = await RegisterRepository.Create(register);
            var registers = await RegisterRepository.GetAll();
            Assert.IsNotNull(registers);
            Assert.IsTrue(registers.Any(x => x.Id == created.Id));
        }
    }
}