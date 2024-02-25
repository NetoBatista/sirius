namespace Sirius.Domain.Dto
{
    public class CategoryResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
