using Microsoft.EntityFrameworkCore;


namespace PlatformServiceInfrastructure.DBContext
{
    public partial class PlatformDbContext: DbContext
    {

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options): base(options)
        {
        }
        public virtual DbSet<PlatformServiceCore.Domain.Entity.Platform> Platforms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformServiceCore.Domain.Entity.Platform>(entity =>
            {
                entity.Property(e => e.Cost).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Publisher).IsRequired();
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
