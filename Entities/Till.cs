namespace BankPOS.Entities
{
    public class Till
    {
        public int TillId { get; set; }
        public int BranchId { get; set; }
        public string TillNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}