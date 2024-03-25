using DAL_V3.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL_V3
{
    public class EntityDatabase : DbContext
    {
        //public DbSet<Category> Category { get; set; }
        //public DbSet<User> User { get; set; }
        //public DbSet<Product> Product { get; set; }
        //public DbSet<Cart> Cart { get; set; }
        //public DbSet<Word> Words { get; set; }
        //public DbSet<KeyParams> KeyLink { get; set; }
        public EntityDatabase()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TestBase2;Trusted_Connection=True;");
        }
    }
}