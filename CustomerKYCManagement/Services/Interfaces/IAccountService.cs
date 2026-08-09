using CustomerKYCManagement.DTOs;

namespace CustomerKYCManagement.services;

public interface IAccountService
{
    Task<AccountResponse> CreateAccount(AccountRequest accountRequest);
    Task<AccountResponse> UpdateAccount(UpdateAccountRequest updateAccountRequest);
    Task<decimal> GetBalance(string accountNumber);
    Task<bool> TransferFunds(TransferRequest transferRequest);
}
