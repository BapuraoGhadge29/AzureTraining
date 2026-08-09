using CustomerKYCManagement.Entities;
using Microsoft.EntityFrameworkCore;
namespace CustomerKYCManagement.Data
{    
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<KycDocument> kycDocuments { get; set; }
        public DbSet<KycVerification> KycVerifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}