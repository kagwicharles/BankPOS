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
            var typeCode = MapAccountTypeToCode(account.AccountType);
            account.AccountNumber = await GenerateAsync(account.BranchCode, typeCode);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return account;

        }

        public async Task<IEnumerable<Account>> GetCustomerAccountsAsync(Guid customerId)
        {
            var transactions = await _context.Accounts
            .Where(a => a.CustomerId == customerId).ToListAsync();
            return transactions;
        }

        public async Task<string> GenerateAsync(string branchCode, string accountTypeCode)
        {
            var sequenceValue = await _context.Database
                .SqlQuery<long>($"SELECT nextval('account_number_seq') AS \"Value\"")
                .FirstAsync();

            var sequencePart = sequenceValue.ToString().PadLeft(8, '0');
            var baseNumber = $"{branchCode}{accountTypeCode}{sequencePart}";
            var checkDigit = LuhnCheckDigit(baseNumber);

            return $"{baseNumber}{checkDigit}";
        }
        private static int LuhnCheckDigit(string number)
        {
            int sum = 0;
            bool alternate = true;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9;
                }
                sum += digit;
                alternate = !alternate;
            }

            return (10 - (sum % 10)) % 10;
        }


        private static string MapAccountTypeToCode(string accountType) => accountType switch
        {
            "Savings" => "01",
            "Current" => "02",
            "Fixed" => "03",
            _ => "00"
        };
    }
}