namespace Sirius.Domain.Entity
{
    public partial class Payment
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? PayDay { get; set; }

        public decimal Value { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual ICollection<Register> RegisterNavigation { get; set; } = [];
        public virtual Category? CategoryNavigation { get; set; }
    }
}
