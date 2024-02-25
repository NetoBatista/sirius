using Sirius.Domain.Dto;

namespace Sirius.Domain.Interface.Service
{
    public interface IRegisterService
    {
        Task<RegisterResponseDTO> Create(RegisterRequestDTO request);
        Task<RegisterResponseDTO> Update(RegisterRequestDTO request);
        Task Delete(Guid id);
        Task<List<RegisterResponseDTO>> GetAll(DateTime startDate, DateTime finalDate);
    }
}
