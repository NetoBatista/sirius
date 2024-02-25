namespace Sirius.Domain.Entity
{
    public partial class Payment
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? PayDay { get; set; }

        public decimal Value { get; set; }

        public virtual ICollection<Register> RegisterNavigation { get; set; } = new List<Register>();
    }
}
