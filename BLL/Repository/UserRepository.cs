using AutoMapper;
using BLL.Entity;
using BLL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class UserRepository : IUserRepository
    {
        DAL_V2.Interfaces.IUserRepository _userRepository;
        IMapper _mapper;
        public UserRepository(IMapper mapper, DAL_V2.Interfaces.IUserRepository serviceRepository)
        {
            _userRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(User entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.User>(entity);
            return await _userRepository.Create(mapEntity);
        }

        public async Task<bool> Delete(User entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.User>(entity);
            return await _userRepository.Delete(mapEntity);
        }

        public async Task<User> GetById(Guid id)
        {
            var entity = await _userRepository.GetById(id);
            return _mapper.Map<User>(entity);
        }

        public async Task<IEnumerable<User>> Select()
        {
            var entity = await _userRepository.Select();
            return _mapper.Map<List<User>>(entity);
        }

        public async Task<User> Update(User entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.User>(entity);
            var result = await _userRepository.Update(mapEntity);
            return _mapper.Map<User>(result);
        }
    }
}
