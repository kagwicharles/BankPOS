namespace BankPOS.DTOs
{
    public class TransactionDto
    {
        public string TransactionReference { get; set; } = string.Empty;
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactonDate { get; set; }
    }

    public class CreateTransactionDto
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}