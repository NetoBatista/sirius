namespace Sirius.Domain.Dto
{
    public class PaymentResponseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? PayDay { get; set; }

        public decimal Value { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
