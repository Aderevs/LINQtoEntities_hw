using BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<bool> CreateUser(User entity);
        public Task<bool> DeleteUser(User entity);
        public Task<User> UpdateUser(User entity);
        public Task<IEnumerable<User>> AllUsers();
        public Task<User> GetById(Guid id);
        public Task<User> GetByName(string name);
        public Task<User> GetByEmail(string email);

    }
}
