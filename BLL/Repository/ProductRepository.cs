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
    public class ProductRepository : IProductRepository
    {
        DAL_V2.Interfaces.IProductRepository _productRepository;
        IMapper _mapper;
        public ProductRepository(IMapper mapper, DAL_V2.Interfaces.IProductRepository serviceRepository)
        {
            _productRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(Product entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Product>(entity);
            return await _productRepository.Create(mapEntity);
        }

        public async Task<bool> Delete(Product entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Product>(entity);
            return await _productRepository.Delete(mapEntity);
        }

        public async Task<Product> GetById(Guid id)
        {
            var entity = await _productRepository.GetById(id);
            return _mapper.Map<Product>(entity);
        }

        public async Task<Product> GetByIdIncludWord(string name)
        {
            var entity = await _productRepository.GetByIdIncludWord(name);
            return _mapper.Map<Product>(entity);
        }

        public async Task<IEnumerable<Product>> Select()
        {
            var entity = await _productRepository.Select();
            return _mapper.Map<List<Product>>(entity);
        }

        public async Task<Product> Update(Product entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Product>(entity);
            var result = await _productRepository.Update(mapEntity);
            return _mapper.Map<Product>(result);
        }
    }
}
