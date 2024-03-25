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
    public class WordRepository : IWordRepository
    {
        public async Task<bool> Create(Word entity)
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

        public async Task<bool> Delete(Word entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                var word = await db.Word.FirstOrDefaultAsync(w => w.Id == entity.Id);
                if (word != null)
                {
                    db.Word.Remove(word);
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

        public async Task<Word> GetById(Guid id)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Word.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Word>> Select()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Word.ToListAsync();
        }

        public async Task<IEnumerable<Word>> SelectIncludeKeyParamsProducts()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.Word
                .Include(w => w.KeyWord)
                .ToListAsync();
        }

        public async Task<Word> Update(Word entity)
        {
            using EntityDatabase db = new EntityDatabase();
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
