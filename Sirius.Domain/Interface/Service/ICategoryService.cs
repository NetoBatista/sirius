using Sirius.Domain.Dto;

namespace Sirius.Domain.Interface.Service
{
    public interface ICategoryService
    {
        Task<CategoryResponseDTO> Create(CategoryRequestDTO request);
        Task<CategoryResponseDTO> Update(CategoryRequestDTO request);
        Task Delete(Guid request);
        Task<List<CategoryResponseDTO>> GetAll();
    }
}
