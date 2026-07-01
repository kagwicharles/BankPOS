using BankPOS.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankPOS.Data
{
    public class BankPosDbContext : DbContext
    {
        public BankPosDbContext(DbContextOptions<BankPosDbContext> options) : base(options) { }

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Receipt> Receipts => Set<Receipt>();
        public DbSet<ShiftSession> ShiftSessions => Set<ShiftSession>();
        public DbSet<Till> Tills => Set<Till>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
    }
}