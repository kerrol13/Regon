using Regon.Application.Dtos.Customer;

namespace Regon.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> AddAsync(CustomerCreateDto createDto);
        Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
        Task<CustomerResponseDto?> GetByIdAsync(Guid id);
    }
}