using CustomerKYCManagement.DTOs;
using CustomerKYCManagement.Entities;

namespace CustomerKYCManagement.repositories
{
    public interface IAccountRepository
    {
        Task CreateAccount(Account accountRequest);
        Task<AccountResponse> UpdateAccount(UpdateAccountRequest updateAccountRequest);
        Task<decimal> GetBalance(string accountNumber);
        Task<bool> TransferFunds(TransferRequest request);
    }
}