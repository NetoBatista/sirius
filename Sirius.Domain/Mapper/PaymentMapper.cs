using Sirius.Domain.Dto;
using Sirius.Domain.Entity;

namespace Sirius.Domain.Mapper
{
    public static class PaymentMapper
    {
        public static Payment ToEntity(this PaymentRequestDTO request)
        {
            return new Payment
            {
                Id = request.Id ?? Guid.Empty,
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                PayDay = request.PayDay,
                Value = request.Value,
            };
        }

        public static PaymentResponseDTO ToResponse(this Payment entity)
        {
            return new PaymentResponseDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CategoryId = entity.CategoryId,
                PayDay = entity.PayDay,
                Value = entity.Value,
            };
        }

        public static PaymentRequestDTO ToRequest(this PaymentResponseDTO response)
        {
            return new PaymentRequestDTO
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                CategoryId = response.CategoryId,
                PayDay = response.PayDay,
                Value = response.Value,
            };
        }
    }
}
