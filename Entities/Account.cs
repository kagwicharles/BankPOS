using BankPOS.Common;

namespace BankPOS.Entities
{
    public class Account : AuditableEntity
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}