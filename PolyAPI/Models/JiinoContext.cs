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
        {

        }
    }
}
