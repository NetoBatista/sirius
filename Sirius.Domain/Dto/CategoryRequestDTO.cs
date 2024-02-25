namespace Sirius.Domain.Dto
{
    public class CategoryRequestDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}
