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
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL("Server=localhost; Database=burnfeniks_mgok11; User ID=046351469_mgok11; Password = huI1lM5MP2; Trusted_Connection=False; Integrated Security=False; TrustServerCertificate=True;");
        
    }
}
