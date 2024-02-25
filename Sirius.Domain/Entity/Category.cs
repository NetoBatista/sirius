namespace Sirius.Domain.Entity
{
    public partial class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreateAt { get; set; }

        public virtual ICollection<Payment> PaymentNavigation { get; set; } = new List<Payment>();
    }
}
