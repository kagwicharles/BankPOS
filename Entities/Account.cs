using BankPOS.Common;
using Microsoft.VisualBasic;

namespace BankPOS.Entities
{
    public class Account : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public String BranchCode { get; set; } = string.Empty;
    }
}