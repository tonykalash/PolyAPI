using Microsoft.EntityFrameworkCore;

namespace PolyAPI.Models
{
    public partial class JiinoContext : DbContext
    {
        public JiinoContext()
        {
        }

        public JiinoContext(DbContextOptions<JiinoContext> options)
            : base(options)
        {
        }
        public virtual DbSet<users> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<users>(entity =>
            {
                entity.ToTable("users");
                ;
                entity.Property(e => e.user_login).HasMaxLength(100);
                entity.Property(e => e.user_name).HasMaxLength(100);
                entity.Property(e => e.user_password).HasMaxLength(100);

            });
            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}