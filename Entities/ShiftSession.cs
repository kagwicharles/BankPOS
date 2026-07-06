using BankPOS.Common;

namespace BankPOS.Entities
{
    public class ShiftSession : BaseEntity
    {
        public Guid TillId { get; set; }
        public required Till Till { get; set; }
        public string TellerName { get; set; } = string.Empty;
        public string TellerStaffNumber { get; set; } = string.Empty;
        public decimal OpeningCash { get; set; }
        public decimal ClosingCash { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}