using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepositoryDAL
    {
		EntityDatabase _database;

		public ProductRepository()
        {
            _database = new EntityDatabase();

		}
        public async Task<bool> Create(Product entity)
        {
            using (EntityDatabase database = _database)
            {
                await database.Products.AddAsync(entity);
                await database.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            using (EntityDatabase database = _database)
            {
                database.Products.Remove(entity);
                await database.SaveChangesAsync();
            }
            return true;
        }


        public async Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(Guid id)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Products.FirstOrDefaultAsync(product => product.Id == id);
            }
            
        }

        public async Task<Product> GetByName(string name)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Products.FirstOrDefaultAsync(product => product.Name == name);
            }
        }

        public async Task<List<Product>> Select()
        {
            using (EntityDatabase database = _database)
            {
                var products = await database.Products.ToListAsync();
                return products;
            }
        }
    }
}
