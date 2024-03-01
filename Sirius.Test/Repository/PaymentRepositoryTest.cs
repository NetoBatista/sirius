using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Repository;
using Sirius.Test.Util;

namespace Sirius.Test.Repository
{
    [TestClass]
    public class PaymentRepositoryTest
    {
        private static IPaymentRepository PaymentRepository
        {
            get
            {
                var siriusContext = GetContext();
                return new PaymentRepository(siriusContext);
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

        [TestMethod("Should be create a payment")]
        public async Task Create()
        {
            var payment = EntityRandomUtil.Payment();
            var created = await PaymentRepository.Create(payment);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);
        }

        [TestMethod("Should be update a existing payment")]
        public async Task UpdateExisting()
        {
            var payment = EntityRandomUtil.Payment();
            var created = await PaymentRepository.Create(payment);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);

            var newName = $"Payment_{Guid.NewGuid()}";
            var newDescription = $"Description_{Guid.NewGuid()}";
            var newValue = 300;
            var newPayday = 20;
            created.Name = newName;
            created.Description = newDescription;
            created.Value = newValue;
            created.PayDay = newPayday;

            var updated = await PaymentRepository.Update(created);
            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Id, created.Id);
            Assert.AreEqual(updated.Name, newName);
            Assert.AreEqual(updated.Description, newDescription);
            Assert.AreEqual(updated.Value, newValue);
            Assert.AreEqual(updated.PayDay, newPayday);
        }

        [TestMethod("Should not be update if the payment not existing")]
        public async Task UpdateNotExisting()
        {
            var payment = EntityRandomUtil.Payment();
            var action = () => PaymentRepository.Update(payment);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be delete a existing payment")]
        public async Task DeleteExisting()
        {
            var payment = EntityRandomUtil.Payment();
            payment.RegisterNavigation =
            [
                EntityRandomUtil.Register()
            ];
            var created = await PaymentRepository.Create(payment);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);

            await PaymentRepository.Delete(created.Id);
            var payments = await PaymentRepository.GetAll();
            Assert.IsFalse(payments.Any(x => x.Id == created.Id));
        }

        [TestMethod("Should not be delete if the payment not existing")]
        public async Task DeleteNotExisting()
        {
            var action = () => PaymentRepository.Delete(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be exists payment")]
        public async Task ExistisPayment()
        {
            var payment = EntityRandomUtil.Payment();
            var created = await PaymentRepository.Create(payment);
            var newPayment = EntityRandomUtil.Payment();
            newPayment.Name = created.Name;
            var exists = await PaymentRepository.Exists(newPayment);
            Assert.IsTrue(exists);
        }

        [TestMethod("Should not be exists payment")]
        public async Task NotExistisPayment()
        {
            var payment = EntityRandomUtil.Payment();
            var exists = await PaymentRepository.Exists(payment);
            Assert.IsFalse(exists);
        }

        [TestMethod("Should be get all payment")]
        public async Task GetAll()
        {
            var payment = EntityRandomUtil.Payment();
            var created = await PaymentRepository.Create(payment);
            var payments = await PaymentRepository.GetAll();
            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Any(x => x.Id == created.Id));
        }

        [TestMethod("Should be get by id")]
        public async Task GetById()
        {
            var payment = EntityRandomUtil.Payment();
            var created = await PaymentRepository.Create(payment);
            var payments = await PaymentRepository.GetById(created.Id);
            Assert.IsNotNull(payments);
        }

        [TestMethod("Should not be get by id")]
        public async Task NotGetById()
        {
            var action = () => PaymentRepository.GetById(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }
    }
}