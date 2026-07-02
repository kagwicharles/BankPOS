using BankPOS.Data;
using BankPOS.Entities;
using BankPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankPOS.Services
{
    public class AccountService : IAccountService
    {

        private readonly BankPosDbContext _context;

        public AccountService(BankPosDbContext context)
        {
            _context = context;
        }
        public async Task<Account> CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;

        }

        public async Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId)
        {
            var transactions = await _context.Accounts
            .Where(a => a.CustomerId == customerId).ToListAsync();
            return transactions;
        }
    }
}