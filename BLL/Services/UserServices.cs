using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;
using System.Xml.Linq;

namespace BLL.Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> CreateUser(User entity)
        {
            return await _userRepository.Create(entity);
        }

        public async Task<bool> DeleteUser(User entity)
        {
            return await _userRepository.Delete(entity);
        }

        public async Task<User> GetByEmail(string email)
        {
            var users = await _userRepository.Select();
            return users.First(x => x.Email == email);
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByName(string name)
        {
            var users = await _userRepository.Select();
            return users.First(x => x.Name == name);
        }

        public async Task<IEnumerable<User>> AllUsers()
        {
            return await _userRepository.Select();
        }

        public async Task<User> UpdateUser(User entity)
        {
            return await _userRepository.Update(entity);
        }
    }
}
