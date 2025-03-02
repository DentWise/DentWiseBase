using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace DotNetBase.EFCore.DBContext
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri ve kısıtlamaları burada tanımlayabilirsiniz (Fluent API).
            // Örnek:
            modelBuilder.Entity<User>()
                 .HasOne(p => p.Role)
                 .WithMany(c => c.Users)
                 .HasForeignKey(p => p.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(GetSoftDeleteFilter(entityType.ClrType));
                }
            }

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(cancellationToken);
        }
        
        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is BaseEntity addedEntity)
                        {
                            addedEntity.CreatedAt = DateTime.UtcNow;
                        }
                        break;

                    case EntityState.Deleted:
                        if (entry.Entity is ISoftDeletable deletableEntity)
                        {
                            entry.State = EntityState.Modified;
                            deletableEntity.DeletedAt = DateTime.UtcNow;
                            deletableEntity.IsDeleted = true;
                        }
                        break;
                    case EntityState.Modified:
                        if (entry.Entity is BaseEntity modifiedEntity)
                        {
                            modifiedEntity.UpdatedAt = DateTime.UtcNow;
                        }
                        
                        break;
                    default:
                        break;
                }
            }
        }
        private LambdaExpression GetSoftDeleteFilter(Type type)
        {
            var param = Expression.Parameter(type, "e");
            var body = Expression.Equal(Expression.Property(param, nameof(ISoftDeletable.IsDeleted)), Expression.Constant(false));
            return Expression.Lambda(body, param);
        }
    }
}
