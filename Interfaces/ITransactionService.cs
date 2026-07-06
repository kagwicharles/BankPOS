
using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(Guid accountId);
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
    }
}