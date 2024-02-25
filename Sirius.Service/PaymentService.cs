using Sirius.Domain.Dto;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Domain.Mapper;

namespace Sirius.Service
{
    public class PaymentService(IPaymentRepository paymentRepository) : IPaymentService
    {
        public async Task<PaymentResponseDTO> Create(PaymentRequestDTO request)
        {
            var entity = request.ToEntity();
            var created = await paymentRepository.Create(entity);
            return created.ToResponse();
        }

        public Task Delete(Guid request)
        {
            return paymentRepository.Delete(request);
        }

        public Task<bool> Exists(PaymentRequestDTO request)
        {
            var entity = request.ToEntity();
            return paymentRepository.Exists(entity);
        }

        public async Task<List<PaymentResponseDTO>> GetAll()
        {
            var response = await paymentRepository.GetAll();
            return response.Select(x => x.ToResponse()).ToList();
        }

        public async Task<PaymentResponseDTO> Update(PaymentRequestDTO request)
        {
            var entity = request.ToEntity();
            var updated = await paymentRepository.Update(entity);
            return updated.ToResponse();
        }
    }
}
