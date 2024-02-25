namespace Sirius.Domain.Entity
{
    public partial class Register
    {
        public Guid Id { get; set; }

        public Guid? PaymentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Value { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category? CategoryNavigation { get; set; }

        public virtual Payment? PaymentNavigation { get; set; }
    }
}
