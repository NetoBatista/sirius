using Sirius.Domain.Dto;
using Sirius.Domain.Entity;

namespace Sirius.Domain.Mapper
{
    public static class CategoryMapper
    {
        public static Category ToEntity(this CategoryRequestDTO request)
        {
            return new Category
            {
                Id = request.Id ?? Guid.Empty,
                CreateAt = DateTime.UtcNow,
                Name = request.Name,
                Description = request.Description,
            };
        }

        public static CategoryResponseDTO ToResponse(this Category entity)
        {
            return new CategoryResponseDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                CreateAt = entity.CreateAt,
                Description = entity.Description,
            };
        }

        public static CategoryRequestDTO ToRequest(this CategoryResponseDTO response)
        {
            return new CategoryRequestDTO
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
            };
        }
    }
}
