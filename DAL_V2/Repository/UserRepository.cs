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
    public class UserRepository : IUserRepository
    {
        public async Task<bool> Create(User entity)
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

        public async Task<bool> Delete(User entity)
        {
            try
            {
                using EntityDatabase db = new EntityDatabase();
                var user = await db.User.FirstOrDefaultAsync(u => u.Id == entity.Id);
                if (user != null)
                {
                    db.User.Remove(user);
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

        public async Task<User> GetById(Guid id)
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> Select()
        {
            using EntityDatabase db = new EntityDatabase();
            return await db.User.ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            using EntityDatabase db = new EntityDatabase();
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
