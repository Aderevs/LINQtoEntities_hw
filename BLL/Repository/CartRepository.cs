using AutoMapper;
using BLL.Entity;
using BLL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class CartRepository : ICartRepository
    {
        DAL_V2.Interfaces.ICartRepository _cartRepository;
        IMapper _mapper;
        public CartRepository(IMapper mapper,DAL_V2.Interfaces.ICartRepository serviceRepository)
        {
            _cartRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(Cart entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Cart>(entity);
            return await _cartRepository.Create(mapEntity);
        }

        public async Task<bool> Delete(Cart entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Cart>(entity);
            return await _cartRepository.Delete(mapEntity);
        }

        public async Task<Cart> GetById(Guid id)
        {
            var entity = await _cartRepository.GetById(id);
            return _mapper.Map<Cart>(entity);
        }

        public async Task<IEnumerable<Cart>> Select()
        {
            var entity = await _cartRepository.Select();
            return _mapper.Map<List<Cart>>(entity);
        }

        public async Task<Cart> Update(Cart entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Cart>(entity);
            var result = await _cartRepository.Update(mapEntity);
            return _mapper.Map<Cart>(result);
        }
    }
}
