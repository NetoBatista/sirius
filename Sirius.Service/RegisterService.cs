using Sirius.Domain.Dto;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Domain.Mapper;

namespace Sirius.Service
{
    public class RegisterService(IRegisterRepository registerRepository, IPaymentRepository paymentRepository) : IRegisterService
    {
        public async Task<RegisterResponseDTO> Create(RegisterRequestDTO request)
        {
            var entity = request.ToEntity();
            var created = await registerRepository.Create(entity);
            created.PaymentNavigation = await paymentRepository.GetById(created.PaymentId);
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

        public async Task<List<RegisterResponseDTO>> GetAll()
        {
            var response = await registerRepository.GetAll();
            return response.Select(x => x.ToResponse()).ToList();
        }

        public async Task<RegisterResponseDTO> Update(RegisterRequestDTO request)
        {
            var entity = request.ToEntity();
            var updated = await registerRepository.Update(entity);
            updated.PaymentNavigation = await paymentRepository.GetById(updated.PaymentId);
            return updated.ToResponse();
        }
    }
}
