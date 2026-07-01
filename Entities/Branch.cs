namespace BankPOS.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public required string BranchCode { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}