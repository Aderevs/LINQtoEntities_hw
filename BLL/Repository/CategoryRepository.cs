using AutoMapper;
using BLL.Entity;
using BLL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        DAL_V2.Interfaces.ICategoryRepository _categoryRepository;
        IMapper _mapper;
        public CategoryRepository(IMapper mapper, DAL_V2.Interfaces.ICategoryRepository serviceRepository)
        {
            _categoryRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(Category entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Category>(entity);
            return await _categoryRepository.Create(mapEntity);
        }

        public async Task<bool> Delete(Category entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Category>(entity);
            return await _categoryRepository.Delete(mapEntity);
        }

        public async Task<Category> GetById(Guid id)
        {
            var entity = await _categoryRepository.GetById(id);
            return _mapper.Map<Category>(entity);
        }

        public async Task<IEnumerable<Category>> Select()
        {
            var entity = await _categoryRepository.Select();
            return _mapper.Map<List<Category>>(entity);
        }

        public async Task<IEnumerable<Category>> SelectIncludeProducts()
        {
            var entity = await _categoryRepository.SelectIncludeProducts();

            return _mapper.Map<List<Category>>(entity);
        }

        public async Task<Category> Update(Category entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Category>(entity);
            var result = await _categoryRepository.Update(mapEntity);
            return _mapper.Map<Category>(result);
        }
    }
}
