using BankPOS.Data;
using BankPOS.Entities;
using BankPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankPOS.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BankPosDbContext _context;

        public TransactionService(BankPosDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .ToListAsync();
        }
    }
}