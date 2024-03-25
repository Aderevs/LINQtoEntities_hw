using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EntityDatabase : DbContext
	{
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Category { get; set; }
        public EntityDatabase()
        {
            Database.EnsureCreated();
        }

        string _connect;
        public EntityDatabase(string connect)
        {
            _connect = connect;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=VilkaShopDatabase;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(_connect);

        }
    }
}