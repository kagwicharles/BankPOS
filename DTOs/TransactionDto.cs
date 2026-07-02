namespace BankPOS.DTOs
{
    public class TransactionDto
    {
        public string TransactionReference { get; set; } = string.Empty;
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty;
    }

    public class CreateTransactionDto
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}