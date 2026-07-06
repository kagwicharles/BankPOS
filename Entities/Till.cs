using BankPOS.Common;

namespace BankPOS.Entities
{
    public class Till : BaseEntity
    {
        public Guid BranchId { get; set; }
        public required Branch Branch { get; set; }
        public string TillNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}