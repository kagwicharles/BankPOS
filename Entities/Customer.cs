using BankPOS.Common;

namespace BankPOS.Entities
{
    public class Customer : AuditableEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerNationalId { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
    }
}