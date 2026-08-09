using CustomerKYCManagement.Data;
using CustomerKYCManagement.Entities;
using Microsoft.EntityFrameworkCore;
namespace CustomerKYCManagement.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankingDbContext _context;

        public CustomerRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<bool> ExistsByPanAsync(string pan)
        {
            return await _context.Customers
                .AnyAsync(x => x.PANNumber == pan);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
