using Sirius.Domain.Entity;

namespace Sirius.Test.Util
{
    public static class EntityRandomUtil
    {
        public static Category Category(Guid? id = null)
        {
            return new Category
            {
                Id = id ?? Guid.Empty,
                Name = $"Category_{Guid.NewGuid()}",
                Description = $"Description_{Guid.NewGuid()}",
                CreateAt = DateTime.UtcNow,
            };
        }

        public static Payment Payment(Guid? id = null)
        {
            return new Payment
            {
                Id = id ?? Guid.Empty,
                Name = $"Category_{Guid.NewGuid()}",
                Description = $"Description_{Guid.NewGuid()}",
                PayDay = 1,
                Value = 100
            };
        }

        public static Register Register(Guid? id = null)
        {
            return new Register
            {
                Id = id ?? Guid.Empty,
                Value = 200,
                PaidAt = DateTime.UtcNow,
            };
        }
    }
}
