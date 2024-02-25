namespace Sirius.Domain.Entity
{
    public partial class Register
    {
        public Guid Id { get; set; }

        public Guid PaymentId { get; set; }

        public DateTime PaidAt { get; set; }

        public decimal Value { get; set; }

        public virtual Payment PaymentNavigation { get; set; } = default!;
    }
}
