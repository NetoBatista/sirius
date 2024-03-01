using Sirius.Domain.Dto;

namespace Sirius.Test.Util
{
    public static class DtoRandomUtil
    {
        public static RegisterRequestDTO RegisterRequestDTO(Guid? id = null)
        {
            return new RegisterRequestDTO
            {
                Id = id,
                PaidAt = DateTime.UtcNow,
                PaymentId = Guid.NewGuid(),
                Value = 100,
            };
        }

        public static PaymentRequestDTO PaymentRequestDTO(Guid? id = null)
        {
            return new PaymentRequestDTO
            {
                Id = id,
                CategoryId = Guid.NewGuid(),
                Description = $"Description_{Guid.NewGuid()}",
                Name = $"Category_{Guid.NewGuid()}",
                PayDay = 15,
                Value = 100,
            };
        }

        public static RegisterResponseDTO RegisterResponseDTO()
        {
            return new RegisterResponseDTO
            {
                Id = Guid.NewGuid(),
                PaidAt = DateTime.UtcNow,
                Payment = PaymentResponseDTO(),
                Value = 100,
            };
        }

        public static PaymentResponseDTO PaymentResponseDTO()
        {
            return new PaymentResponseDTO
            {
                Id = Guid.NewGuid(),
                Value = 100,
                CategoryId = Guid.NewGuid(),
                Name = $"Category_{Guid.NewGuid()}",
                Description = $"Description_{Guid.NewGuid()}",
                PayDay = 1,
            };
        }

    }
}
