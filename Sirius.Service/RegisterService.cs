using Sirius.Domain.Dto;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Domain.Mapper;

namespace Sirius.Service
{
    public class RegisterService(IRegisterRepository registerRepository) : IRegisterService
    {
        public async Task<RegisterResponseDTO> Create(RegisterRequestDTO request)
        {
            var entity = request.ToEntity();
            var created = await registerRepository.Create(entity);
            return created.ToResponse();
        }

        public Task Delete(Guid request)
        {
            return registerRepository.Delete(request);
        }

        public async Task<List<RegisterResponseDTO>> GetAll(DateTime startDate, DateTime finalDate)
        {
            var response = await registerRepository.GetAll(startDate, finalDate);
            return response.Select(x => x.ToResponse()).ToList();
        }

        public async Task<RegisterResponseDTO> Update(RegisterRequestDTO request)
        {
            var entity = request.ToEntity();
            var updated = await registerRepository.Update(entity);
            return updated.ToResponse();
        }
    }
}
