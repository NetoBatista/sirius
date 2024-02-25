using Sirius.Domain.Dto;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Domain.Mapper;

namespace Sirius.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDTO> Create(CategoryRequestDTO request)
        {
            var entity = request.ToEntity();
            var created = await _categoryRepository.Create(entity);
            return created.ToResponse();
        }

        public Task Delete(Guid request)
        {
            return _categoryRepository.Delete(request);
        }

        public async Task<List<CategoryResponseDTO>> GetAll()
        {
            var response = await _categoryRepository.GetAll();
            return response.Select(x => x.ToResponse()).ToList();
        }

        public async Task<CategoryResponseDTO> Update(CategoryRequestDTO request)
        {
            var entity = request.ToEntity();
            var updated = await _categoryRepository.Update(entity);
            return updated.ToResponse();
        }
    }
}
