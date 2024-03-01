using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Repository;
using Sirius.Test.Util;

namespace Sirius.Test.Repository
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private static ICategoryRepository CategoryRepository
        {
            get
            {
                var siriusContext = GetContext();
                return new CategoryRepository(siriusContext);
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

        [TestMethod("Should be create a category")]
        public async Task Create()
        {
            var category = RandomUtil.Category();
            var created = await CategoryRepository.Create(category);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);
        }

        [TestMethod("Should be update a existing category")]
        public async Task UpdateExisting()
        {
            var category = RandomUtil.Category();
            var created = await CategoryRepository.Create(category);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);

            var newName = $"Category_{Guid.NewGuid()}";
            var newDescription = $"Description_{Guid.NewGuid()}";
            created.Name = newName;
            created.Description = newDescription;

            var updated = await CategoryRepository.Update(created);
            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Id, created.Id);
            Assert.AreEqual(updated.Name, newName);
            Assert.AreEqual(updated.Description, newDescription);
        }

        [TestMethod("Should not be update if the category not existing")]
        public async Task UpdateNotExisting()
        {
            var category = RandomUtil.Category();
            var action = () => CategoryRepository.Update(category);
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be delete a existing category")]
        public async Task DeleteExisting()
        {
            var category = RandomUtil.Category();
            var payment = RandomUtil.Payment();
            payment.RegisterNavigation =
            [
                RandomUtil.Register()
            ];
            category.PaymentNavigation =
            [
               payment
            ];
            var created = await CategoryRepository.Create(category);
            Assert.IsNotNull(created);
            Assert.AreNotEqual(created.Id, Guid.Empty);

            await CategoryRepository.Delete(created.Id);
            var categories = await CategoryRepository.GetAll();
            Assert.IsFalse(categories.Any(x => x.Id == created.Id));
        }

        [TestMethod("Should not be delete if the category not existing")]
        public async Task DeleteNotExisting()
        {
            var action = () => CategoryRepository.Delete(Guid.NewGuid());
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);
            Assert.IsNotNull(exception);
        }

        [TestMethod("Should be exists category")]
        public async Task ExistisCategory()
        {
            var category = RandomUtil.Category();
            var created = await CategoryRepository.Create(category);
            var newCategory = RandomUtil.Category();
            newCategory.Name = created.Name;
            var exists = await CategoryRepository.Exists(newCategory);
            Assert.IsTrue(exists);
        }

        [TestMethod("Should not be exists category")]
        public async Task NotExistisCategory()
        {
            var category = RandomUtil.Category();
            var exists = await CategoryRepository.Exists(category);
            Assert.IsFalse(exists);
        }

        [TestMethod("Should be get all category")]
        public async Task GetAll()
        {
            var category = RandomUtil.Category();
            var created = await CategoryRepository.Create(category);
            var categories = await CategoryRepository.GetAll();
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any(x => x.Id == created.Id));
        }
    }
}