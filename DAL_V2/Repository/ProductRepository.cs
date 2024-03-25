using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V2.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<bool> Create(Product entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                db.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Product entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                var product = await db.Product.FirstOrDefaultAsync(p => p.Id == entity.Id);
                if (product != null)
                {
                    db.Product.Remove(product);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    // Product not found
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Product> GetById(Guid id)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetByIdIncludWord(string name)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Product.FirstOrDefaultAsync(p => p.Name.Contains(name));
        }

        public async Task<IEnumerable<Product>> Select()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Product.ToListAsync();
        }
        public async Task<IEnumerable<Product>> SelectIncludeCategory()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Product
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            using EntityDatabase db = new EntityDatabase();
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
