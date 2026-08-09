
using CustomerKYCManagement.Data;
using CustomerKYCManagement.DTOs;
using CustomerKYCManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerKYCManagement.repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;
        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task CreateAccount(Account accountRequest)
        {
            await _context.Accounts.AddAsync(accountRequest);
        }

        public async Task<decimal> GetBalance(string accountNumber)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
            return account?.Balance ?? 0;
        }

        public async Task<bool> TransferFunds(TransferRequest request)
        {
            using var transaction =
                await _context.Database.BeginTransactionAsync();
            try
            {
                var source = await _context.Accounts
                    .FirstOrDefaultAsync(x =>
                        x.AccountNumber == request.FromAccount);
                var destination = await _context.Accounts
                    .FirstOrDefaultAsync(x =>
                        x.AccountNumber == request.ToAccount);
                if (source == null || destination == null)
                    return false;
                if (source.Balance < request.Amount)
                    return false;
                source.Balance -= request.Amount;
                destination.Balance += request.Amount;
                _context.Transactions.Add(new Transaction
                {
                    Id = Guid.NewGuid(),
                    SourceAccount = source.AccountNumber,
                    DestinationAccount = destination.AccountNumber,
                    Amount = request.Amount,
                    TransactionDate = DateTime.UtcNow,
                    Status = "SUCCESS",
                    TransactionType = "TRANSFER"
                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public Task<AccountResponse> UpdateAccount(UpdateAccountRequest updateAccountRequest)
        {
            throw new NotImplementedException();
        }
    }
}