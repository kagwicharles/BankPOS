using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface IAccountService
    {
        Task<string> GenerateAsync(string branchCode, string accountTypeCode);
        Task<Account> CreateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetCustomerAccountsAsync(Guid customerId);
    }
}