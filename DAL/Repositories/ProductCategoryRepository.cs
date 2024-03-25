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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
		EntityDatabase _database;

		public ProductCategoryRepository(EntityDatabase database)
        {
			_database = database;

		}
        public async Task<bool> Create(ProductCategory entity)
        {
            using (EntityDatabase database = _database)
            {
                await database.Category.AddAsync(entity);
                await database.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> Delete(ProductCategory entity)
        {
            using (EntityDatabase database = _database)
            {
                database.Category.Remove(entity);
                await database.SaveChangesAsync();
            }
            return true;
        }


        public async Task<ProductCategory> Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategory> Get(Guid id)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Category.FirstOrDefaultAsync(product => product.Id == id);
            }
            
        }

        public async Task<ProductCategory> GetByName(string name)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Category.FirstOrDefaultAsync(product => product.Name == name);
            }
        }

        public async Task<List<ProductCategory>> Select()
        {
            using (EntityDatabase database = _database)
            {
                return await database.Category.ToListAsync();
            }
        }
    }
}
