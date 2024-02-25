using Sirius.Domain.Dto;
using Sirius.Domain.Entity;

namespace Sirius.Domain.Mapper
{
    public static class RegisterMapper
    {
        public static Register ToEntity(this RegisterRequestDTO request)
        {
            return new Register
            {
                Id = request.Id ?? Guid.Empty,
                Value = request.Value,
                PaymentId = request.PaymentId,
            };
        }

        public static RegisterResponseDTO ToResponse(this Register entity)
        {
            return new RegisterResponseDTO
            {
                Id = entity.Id,
                Value = entity.Value,
                Payment = entity.PaymentNavigation.ToResponse(),
                CreatedAt = entity.CreatedAt
            };
        }

        public static RegisterRequestDTO ToRequest(this RegisterResponseDTO response)
        {
            return new RegisterRequestDTO
            {
                Id = response.Id,
                Value = response.Value,
                PaymentId = response.Payment.Id
            };
        }
    }
}
