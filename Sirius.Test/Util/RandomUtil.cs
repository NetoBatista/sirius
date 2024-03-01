using Sirius.Domain.Entity;

namespace Sirius.Test.Util
{
    public static class RandomUtil
    {
        public static Category Category()
        {
            return new Category
            {
                Name = $"Category_{Guid.NewGuid()}",
                Description = $"Description_{Guid.NewGuid()}",
                CreateAt = DateTime.UtcNow,
            };
        }

        public static Payment Payment()
        {
            return new Payment
            {
                Name = $"Category_{Guid.NewGuid()}",
                Description = $"Description_{Guid.NewGuid()}",
                PayDay = 1,
                Value = 100
            };
        }

        public static Register Register()
        {
            return new Register
            {
                Value = 200,
                PaidAt = DateTime.UtcNow,
            };
        }
    }
}
