using CustomerKYCManagement.DTOs;
namespace CustomerKYCManagement.services;
public interface ICustomerService
{
    Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request);

    Task<CustomerResponse> GetCustomerAsync(Guid id);

    Task<List<CustomerResponse>> GetCustomersAsync();

    Task<CustomerResponse> UpdateCustomerAsync(Guid id,UpdateCustomerRequest request);

    Task DeleteCustomerAsync(Guid id);

    Task<CustomerResponse> ActivateCustomerAsync(Guid id);

    Task<CustomerResponse> DeactivateCustomerAsync(Guid id);

    Task<CustomerResponse> ApproveKycAsync(Guid id);

    Task<CustomerResponse> RejectKycAsync(Guid id);
}