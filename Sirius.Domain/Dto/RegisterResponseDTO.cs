namespace Sirius.Domain.Dto
{
    public class RegisterResponseDTO
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public PaymentResponseDTO Payment { get; set; } = default!;
    }
}
