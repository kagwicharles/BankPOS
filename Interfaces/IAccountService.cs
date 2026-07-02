using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId);
    }
}