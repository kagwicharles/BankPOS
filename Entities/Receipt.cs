namespace BankPOS.Entities
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int TransactionId { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; }
    }
}