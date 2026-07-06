using BankPOS.Common;

namespace BankPOS.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerNationalId { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
    }
}