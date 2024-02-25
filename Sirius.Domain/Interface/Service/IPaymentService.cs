using Sirius.Domain.Dto;

namespace Sirius.Domain.Interface.Service
{
    public interface IPaymentService
    {
        Task<PaymentResponseDTO> Create(PaymentRequestDTO payment);
        Task<PaymentResponseDTO> Update(PaymentRequestDTO payment);
        Task Delete(Guid id);
        Task<List<PaymentResponseDTO>> GetAll();
        Task<bool> Exists(PaymentRequestDTO category);
    }
}
