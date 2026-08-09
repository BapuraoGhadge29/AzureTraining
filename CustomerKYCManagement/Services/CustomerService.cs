using CustomerKYCManagement.DTOs;
using CustomerKYCManagement.Entities;
using CustomerKYCManagement.repositories;
namespace CustomerKYCManagement.services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse>CreateCustomerAsync(CustomerRequest request)
    {
        if (await _repository.ExistsByPanAsync(request.PANNumber))
        {
            throw new Exception("PAN already exists");
        }

        var customer = new Customer
        {
            CustomerId = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailAddress = request.EmailAddress,
            MobileNumber = request.MobileNumber,
            PANNumber = request.PANNumber,
            AadhaarNumber = request.AadhaarNumber,
            DateOfBirth = request.DateOfBirth,
            // Ge = request.Gender,
            Occupation = request.Occupation,
            //IsActive = true,
            //= "PENDING",
            //CreatedDate = DateTime.UtcNow
        };

        await _repository.AddAsync(customer);
        await _repository.SaveChangesAsync();

        return Map(customer);
    }
    public async Task<CustomerResponse> GetCustomerAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Customer not found");

        return Map(customer);
    }

    public async Task<List<CustomerResponse>> GetCustomersAsync()
    {
        var customers = await _repository.GetAllAsync();

        return customers.Select(Map).ToList();
    }

    public async Task<CustomerResponse> UpdateCustomerAsync(Guid id, UpdateCustomerRequest request)
    {
        var customer = await _repository.GetByIdAsync(id)
                       ?? throw new Exception("Customer not found");

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.MobileNumber = request.MobileNumber;

        await _repository.UpdateAsync(customer);
        await _repository.SaveChangesAsync();

        return Map(customer);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Customer not found");
        
        //customer.IsActive = false;

        await _repository.UpdateAsync(customer);
        await _repository.SaveChangesAsync();
    }

    public async Task<CustomerResponse>ActivateCustomerAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Customer not found");

        //customer.IsActive = true;

        await _repository.SaveChangesAsync();

        return Map(customer);
    }

    public async Task<CustomerResponse> DeactivateCustomerAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Customer not found");

        //customer.IsActive = false;

        await _repository.SaveChangesAsync();

        return Map(customer);
    }

    public async Task<CustomerResponse>ApproveKycAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Customer not found");

        //customer.KycStatus = "APPROVED";

        await _repository.SaveChangesAsync();

        return Map(customer);
    }

    public async Task<CustomerResponse>RejectKycAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Customer not found");

        //customer.KycStatus = "REJECTED";

        await _repository.SaveChangesAsync();

        return Map(customer);
    }

    private static CustomerResponse Map(Customer customer)
    {
        return new CustomerResponse
        {
            CustomerId = customer.CustomerId.ToString()!,
            FirstName = customer.FirstName!,
            LastName = customer.LastName!,
            Email = customer.EmailAddress!,
            MobileNumber = customer.MobileNumber!,
            PanNumber = customer.PANNumber!,
            //KycStatus = customer.KycStatus,
            //IsActive = customer.IsActive
        };
    }
}