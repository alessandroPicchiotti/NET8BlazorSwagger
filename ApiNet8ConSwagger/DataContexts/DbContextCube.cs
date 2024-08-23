using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using WaCube.Models;

namespace ApiNet8ConSwagger.DataContexts
{
    public partial class DbContextCube : DbContext
    {
        public DbContextCube(DbContextOptions options) : base(options)  
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Articoli>().HasKey(a => new { a.ar_codart, a.codditt });
            modelBuilder.Entity<Articoli>().ToTable("Artico", t => t.ExcludeFromMigrations());
        }

        public virtual DbSet<Articoli> Artico { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
