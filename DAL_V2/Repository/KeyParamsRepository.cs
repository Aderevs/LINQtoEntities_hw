using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL_V2.Repository
{
    public class KeyParamsRepository : IKeyParamsRepository
    {
        public async Task<bool> Create(KeyParams entity)
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

        public async Task<bool> Delete(KeyParams entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                var keyLink = await db.KeyLink.FirstOrDefaultAsync(kl => kl.Id == entity.Id);
                if (keyLink != null)
                {
                    db.KeyLink.Remove(keyLink);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    // Key Params not found
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<KeyParams> GetById(Guid id)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.KeyLink.FirstOrDefaultAsync(kl => kl.Id == id);
        }

        public async Task<IEnumerable<KeyParams>> Select()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.KeyLink.ToListAsync();
        }

        public async Task<IEnumerable<KeyParams>> SelectIncludeWords()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.KeyLink
                .Include(kl => kl.KeyWords)
                .ToListAsync();
        }

        public async Task<KeyParams> Update(KeyParams entity)
        {
            using EntityDatabase db = new EntityDatabase();
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
