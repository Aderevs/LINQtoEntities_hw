using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL_V2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<bool> Create(Category entity)
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

        public async Task<bool> Delete(Category entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                var category = await db.Category.FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (category != null)
                {
                    db.Category.Remove(category);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    // Category not found
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Category> GetById(Guid id)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Category.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> Select()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Category.ToListAsync();
        }

        public async Task<IEnumerable<Category>> SelectIncludeProducts()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Category
                .Include(c => c.Products)
                .ToListAsync();
        }

        public async Task<Category> Update(Category entity)
        {
            using EntityDatabase db = new EntityDatabase();
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
