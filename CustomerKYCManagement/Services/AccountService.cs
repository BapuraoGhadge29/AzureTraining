using CustomerKYCManagement.DTOs;
using CustomerKYCManagement.Entities;
using CustomerKYCManagement.repositories;
namespace CustomerKYCManagement.services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountrepository;
        public AccountService(IAccountRepository accountrepository)
        {
            _accountrepository = accountrepository;
        }

        public async Task<AccountResponse> CreateAccount(AccountRequest request)
        {
            var account = new Account
            {
                AccountId = Guid.NewGuid(),
                CustomerId = Guid.Parse(request.CustomerId),
                AccountNumber = request.AccountNumber,
                AccountType = request.AccountType,
                BranchCode = request.BranchCode,
                Currency = request.Currency,
                OpeningDate = request.OpeningDate,
                RelationshipManager = request.RelationshipManager,
                Status = request.Status
            };
            var accountData = Map(account);
            await _accountrepository.CreateAccount(account);

            return accountData;
        }

        public async Task<decimal> GetBalance(string accountNumber)
        {
            return await _accountrepository.GetBalance(accountNumber);
        }
        public async Task<bool> TransferFunds(TransferRequest request)
        {
            return await _accountrepository.TransferFunds(request);
        }

        public async Task<AccountResponse> UpdateAccount(UpdateAccountRequest updateAccountRequest)
        {
            return await _accountrepository.UpdateAccount(updateAccountRequest);
        }
        private static AccountResponse Map(Account account)
        {
            return new AccountResponse
            {
                CustomerId = account.CustomerId.ToString()!,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType,
                BranchCode = account.BranchCode,
                Currency = account.Currency,
                OpeningDate = account.OpeningDate,
                RelationshipManager = account.RelationshipManager,
                Status = account.Status
            };
        }
    }
}
