using BankPOS.Common;
using BankPOS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankPOS.Data
{
    public class BankPosDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankPosDbContext(
            DbContextOptions<BankPosDbContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Receipt> Receipts => Set<Receipt>();
        public DbSet<ShiftSession> ShiftSessions => Set<ShiftSession>();
        public DbSet<Till> Tills => Set<Till>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.Id))
                        .ValueGeneratedNever();
                }
            }

            modelBuilder.HasSequence<long>("account_number_seq")
                .StartsAt(1000)
                .IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfo()
        {
            var currentUser = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = currentUser;
                    entry.Entity.CreatedAt = now;
                    entry.Entity.LastModifiedBy = currentUser;
                    entry.Entity.LastModifiedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(AuditableEntity.CreatedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.CreatedAt)).IsModified = false;

                    entry.Entity.LastModifiedBy = currentUser;
                    entry.Entity.LastModifiedAt = now;
                }
            }
        }
    }
}