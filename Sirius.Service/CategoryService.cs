using Sirius.Domain.Dto;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Domain.Mapper;

namespace Sirius.Service
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<CategoryResponseDTO> Create(CategoryRequestDTO request)
        {
            var entity = request.ToEntity();
            var created = await categoryRepository.Create(entity);
            return created.ToResponse();
        }

        public Task Delete(Guid request)
        {
            return categoryRepository.Delete(request);
        }

        public Task<bool> Exists(CategoryRequestDTO request)
        {
            var entity = request.ToEntity();
            return categoryRepository.Exists(entity);
        }

        public async Task<List<CategoryResponseDTO>> GetAll()
        {
            var response = await categoryRepository.GetAll();
            return response.Select(x => x.ToResponse()).ToList();
        }

        public async Task<CategoryResponseDTO> Update(CategoryRequestDTO request)
        {
            var entity = request.ToEntity();
            var updated = await categoryRepository.Update(entity);
            return updated.ToResponse();
        }
    }
}
