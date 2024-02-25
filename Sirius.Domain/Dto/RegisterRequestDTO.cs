namespace Sirius.Domain.Dto
{
    public class RegisterRequestDTO
    {
        public Guid? Id { get; set; }

        public Guid PaymentId { get; set; }

        public decimal Value { get; set; }
    }
}
