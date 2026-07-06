using BankPOS.Common;

namespace BankPOS.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reference { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public bool Status { get; set; }
    }
}