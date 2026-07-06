using BankPOS.Common;

namespace BankPOS.Entities
{
    public class Receipt : BaseEntity
    {
        public Guid TransactionId { get; set; }
        public required Transaction Transaction { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; }
    }
}