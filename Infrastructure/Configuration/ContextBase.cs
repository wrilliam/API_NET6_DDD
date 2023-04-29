using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        #region Attributes

        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        #endregion

        #region Constructor

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        #endregion

        #region Behaviors

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string GetConnectionString()
        {
            string dataSource = "localhost\\SQLEXPRESS";
            string initialCatalog = "API_DDD_2022";
            string integratedSecurity = "False";
            string userId = "sa";
            string password = "1234";
            int connectTimeout = 15;

            return "Data Source=" + dataSource + ";Initial Catalog=" + initialCatalog + ";Integrated Security=" + integratedSecurity
                + ";User Id=" + userId + ";Password=" + password + ";Connect Timeout=" + connectTimeout + ";";
        }

        #endregion
    }
}
