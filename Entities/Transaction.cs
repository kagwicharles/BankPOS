namespace BankPOS.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public required Account Account { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public required string Reference { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Status { get; set; }
    }
}