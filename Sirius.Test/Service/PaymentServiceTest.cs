using Moq;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Service;
using Sirius.Test.Util;

namespace Sirius.Test.Service
{
    [TestClass]
    public class PaymentServiceTest
    {
        [TestMethod("Should be create a payment")]
        public async Task Create()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Create(It.IsAny<Payment>())).ReturnsAsync(EntityRandomUtil.Payment(id: Guid.NewGuid()));
            IPaymentService service = new PaymentService(mockPayment.Object);
            var request = DtoRandomUtil.PaymentRequestDTO();
            var created = await service.Create(request);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);
        }

        [TestMethod("Should be delete a payment")]
        public async Task Delete()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Delete(It.IsAny<Guid>()));
            IPaymentService service = new PaymentService(mockPayment.Object);
            await service.Delete(Guid.NewGuid());
            Assert.IsTrue(true);
        }

        [TestMethod("Should not be delete a payment")]
        public async Task NotDelete()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Delete(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            IPaymentService service = new PaymentService(mockPayment.Object);
            var action = () => service.Delete(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be exists a payment")]
        public async Task Exists()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Exists(It.IsAny<Payment>())).ReturnsAsync(true);
            IPaymentService service = new PaymentService(mockPayment.Object);
            var request = DtoRandomUtil.PaymentRequestDTO(id: Guid.NewGuid());
            var response = await service.Exists(request);
            Assert.IsTrue(response);
        }

        [TestMethod("Should not be exists a payment")]
        public async Task NotExists()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Exists(It.IsAny<Payment>())).ReturnsAsync(false);
            IPaymentService service = new PaymentService(mockPayment.Object);
            var request = DtoRandomUtil.PaymentRequestDTO(id: Guid.NewGuid());
            var response = await service.Exists(request);
            Assert.IsFalse(response);
        }

        [TestMethod("Should be get all payments")]
        public async Task GetAll()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.GetAll())
                       .ReturnsAsync([
                           EntityRandomUtil.Payment(id: Guid.NewGuid()),
                           EntityRandomUtil.Payment(id: Guid.NewGuid()),
                        ]);
            IPaymentService service = new PaymentService(mockPayment.Object);
            var response = await service.GetAll();
            Assert.IsTrue(response.Any());
        }

        [TestMethod("Should be get emptypayments")]
        public async Task EmptyGetAll()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.GetAll())
                       .ReturnsAsync([]);
            IPaymentService service = new PaymentService(mockPayment.Object);
            var response = await service.GetAll();
            Assert.IsFalse(response.Any());
        }

        [TestMethod("Should be update a payment")]
        public async Task Update()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Update(It.IsAny<Payment>())).ReturnsAsync(EntityRandomUtil.Payment(id: Guid.NewGuid()));
            IPaymentService service = new PaymentService(mockPayment.Object);
            var request = DtoRandomUtil.PaymentRequestDTO();
            var updated = await service.Update(request);
            Assert.IsNotNull(updated);
            Assert.AreNotEqual(updated.Id, Guid.Empty);
        }

        [TestMethod("Should not be update a payment")]
        public async Task NotUpdate()
        {
            var mockPayment = new Mock<IPaymentRepository>();
            mockPayment.Setup(x => x.Update(It.IsAny<Payment>())).ThrowsAsync(new InvalidOperationException());
            IPaymentService service = new PaymentService(mockPayment.Object);
            var request = DtoRandomUtil.PaymentRequestDTO();
            var action = () => service.Update(request);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }
    }
}
