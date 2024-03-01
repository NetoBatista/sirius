using Moq;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Service;
using Sirius.Test.Util;

namespace Sirius.Test.Service
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod("Should be create a category")]
        public async Task Create()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Create(It.IsAny<Category>())).ReturnsAsync(EntityRandomUtil.Category(id: Guid.NewGuid()));
            ICategoryService service = new CategoryService(mockCategory.Object);
            var request = DtoRandomUtil.CategoryRequestDTO();
            var created = await service.Create(request);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);
        }

        [TestMethod("Should be delete a category")]
        public async Task Delete()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Delete(It.IsAny<Guid>()));
            ICategoryService service = new CategoryService(mockCategory.Object);
            await service.Delete(Guid.NewGuid());
            Assert.IsTrue(true);
        }

        [TestMethod("Should not be delete a category")]
        public async Task NotDelete()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Delete(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            ICategoryService service = new CategoryService(mockCategory.Object);
            var action = () => service.Delete(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be exists a category")]
        public async Task Exists()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Exists(It.IsAny<Category>())).ReturnsAsync(true);
            ICategoryService service = new CategoryService(mockCategory.Object);
            var request = DtoRandomUtil.CategoryRequestDTO(id: Guid.NewGuid());
            var response = await service.Exists(request);
            Assert.IsTrue(response);
        }

        [TestMethod("Should not be exists a category")]
        public async Task NotExists()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Exists(It.IsAny<Category>())).ReturnsAsync(false);
            ICategoryService service = new CategoryService(mockCategory.Object);
            var request = DtoRandomUtil.CategoryRequestDTO(id: Guid.NewGuid());
            var response = await service.Exists(request);
            Assert.IsFalse(response);
        }

        [TestMethod("Should be get all categorys")]
        public async Task GetAll()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.GetAll())
                       .ReturnsAsync([
                           EntityRandomUtil.Category(id: Guid.NewGuid()),
                           EntityRandomUtil.Category(id: Guid.NewGuid()),
                        ]);
            ICategoryService service = new CategoryService(mockCategory.Object);
            var response = await service.GetAll();
            Assert.IsTrue(response.Any());
        }

        [TestMethod("Should be get emptycategorys")]
        public async Task EmptyGetAll()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.GetAll())
                       .ReturnsAsync([]);
            ICategoryService service = new CategoryService(mockCategory.Object);
            var response = await service.GetAll();
            Assert.IsFalse(response.Any());
        }

        [TestMethod("Should be update a category")]
        public async Task Update()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Update(It.IsAny<Category>())).ReturnsAsync(EntityRandomUtil.Category(id: Guid.NewGuid()));
            ICategoryService service = new CategoryService(mockCategory.Object);
            var request = DtoRandomUtil.CategoryRequestDTO();
            var updated = await service.Update(request);
            Assert.IsNotNull(updated);
            Assert.AreNotEqual(updated.Id, Guid.Empty);
        }

        [TestMethod("Should not be update a category")]
        public async Task NotUpdate()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(x => x.Update(It.IsAny<Category>())).ThrowsAsync(new InvalidOperationException());
            ICategoryService service = new CategoryService(mockCategory.Object);
            var request = DtoRandomUtil.CategoryRequestDTO();
            var action = () => service.Update(request);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }
    }
}
