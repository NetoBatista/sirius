namespace Sirius.Domain.Dto
{
    public class PaymentRequestDTO
    {
        public Guid? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? PayDay { get; set; }

        public decimal Value { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
