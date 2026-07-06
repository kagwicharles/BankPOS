namespace BankPOS.Common
{
    public abstract class BaseEntity : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}