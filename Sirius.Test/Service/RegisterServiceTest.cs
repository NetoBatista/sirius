using Moq;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Service;
using Sirius.Test.Util;

namespace Sirius.Test.Service
{
    [TestClass]
    public class RegisterServiceTest
    {
        [TestMethod("Should be create a register")]
        public async Task Create()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.Create(It.IsAny<Register>())).ReturnsAsync(EntityRandomUtil.Register(id: Guid.NewGuid()));
            mockPayment.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(EntityRandomUtil.Payment(id: Guid.NewGuid()));
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var request = DtoRandomUtil.RegisterRequestDTO();
            var created = await service.Create(request);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);
            Assert.AreNotEqual(created.Payment.Id, Guid.Empty);
        }

        [TestMethod("Should not be create a register without payment")]
        public async Task NotCreate()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.Create(It.IsAny<Register>())).ReturnsAsync(EntityRandomUtil.Register(id: Guid.NewGuid()));
            mockPayment.Setup(x => x.GetById(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var request = DtoRandomUtil.RegisterRequestDTO();
            var action = () => service.Create(request);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be delete a register")]
        public async Task Delete()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.Delete(It.IsAny<Guid>()));
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            await service.Delete(Guid.NewGuid());
            Assert.IsTrue(true);
        }

        [TestMethod("Should not be delete a register")]
        public async Task NotDelete()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.Delete(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var action = () => service.Delete(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be get all by date registers")]
        public async Task GetAllByDate()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            var register1 = EntityRandomUtil.Register(id: Guid.NewGuid());
            register1.PaymentNavigation = EntityRandomUtil.Payment(id: Guid.NewGuid());
            var register2 = EntityRandomUtil.Register(id: Guid.NewGuid());
            register2.PaymentNavigation = EntityRandomUtil.Payment(id: Guid.NewGuid());
            mockRegister.Setup(x => x.GetAll(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                        .ReturnsAsync([register1, register2]);
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var response = await service.GetAll(DateTime.UtcNow, DateTime.UtcNow);
            Assert.IsTrue(response.Any());
        }

        [TestMethod("Should be get all registers")]
        public async Task GetAll()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            var register1 = EntityRandomUtil.Register(id: Guid.NewGuid());
            register1.PaymentNavigation = EntityRandomUtil.Payment(id: Guid.NewGuid());
            var register2 = EntityRandomUtil.Register(id: Guid.NewGuid());
            register2.PaymentNavigation = EntityRandomUtil.Payment(id: Guid.NewGuid());
            mockRegister.Setup(x => x.GetAll())
                        .ReturnsAsync([register1, register2]);
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var response = await service.GetAll();
            Assert.IsTrue(response.Any());
        }

        [TestMethod("Should be get empty registers")]
        public async Task EmptyGetAll()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.GetAll(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                        .ReturnsAsync([]);
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var response = await service.GetAll(DateTime.UtcNow, DateTime.UtcNow);
            Assert.IsFalse(response.Any());
        }

        [TestMethod("Should be update a register")]
        public async Task Update()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.Update(It.IsAny<Register>())).ReturnsAsync(EntityRandomUtil.Register(id: Guid.NewGuid()));
            mockPayment.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(EntityRandomUtil.Payment(id: Guid.NewGuid()));
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var request = DtoRandomUtil.RegisterRequestDTO();
            var response = await service.Update(request);
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response.Id, Guid.Empty);
            Assert.AreNotEqual(response.Payment.Id, Guid.Empty);
        }

        [TestMethod("Should not be update a register without payment")]
        public async Task NotUpdateCreate()
        {
            var mockRegister = new Mock<IRegisterRepository>();
            var mockPayment = new Mock<IPaymentRepository>();
            mockRegister.Setup(x => x.Update(It.IsAny<Register>())).ReturnsAsync(EntityRandomUtil.Register(id: Guid.NewGuid()));
            mockPayment.Setup(x => x.GetById(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            IRegisterService service = new RegisterService(mockRegister.Object, mockPayment.Object);
            var request = DtoRandomUtil.RegisterRequestDTO();
            var action = () => service.Update(request);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }
    }
}
