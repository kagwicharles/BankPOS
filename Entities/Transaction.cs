namespace BankPOS.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public required string Reference { get; set; }
        public DateTime TimeStamP { get; set; }
        public bool Status { get; set; }
    }
}