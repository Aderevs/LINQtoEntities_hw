using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL_V2.Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task<bool> Create(Cart entity)
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

        public async Task<bool> Delete(Cart entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                var cart = await db.Cart.FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (cart != null)
                {
                    db.Cart.Remove(cart);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    // Cart not found
                    return false;
                }
            }
            catch (Exception)
            {
                return false ;
            }
        }

        public async Task<Cart> GetById(Guid id)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Cart.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cart>> Select()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Cart.ToListAsync();
        }

        public async Task<Cart> Update(Cart entity)
        {
            using EntityDatabase db = new EntityDatabase();
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
