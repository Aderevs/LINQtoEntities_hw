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
    public class WordRepository : IWordRepository
    {
        DAL_V2.Interfaces.IWordRepository _wordsRepository;
        IMapper _mapper;
        public WordRepository(IMapper mapper, DAL_V2.Interfaces.IWordRepository serviceRepository)
        {
            _wordsRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(Word entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Word>(entity);
            return await _wordsRepository.Create(mapEntity);
        }

        public async Task<bool> Delete(Word entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Word>(entity);
            return await _wordsRepository.Delete(mapEntity);
        }

        public async Task<Word> GetById(Guid id)
        {
            var entity = await _wordsRepository.GetById(id);
            return _mapper.Map<Word>(entity);
        }

        public async Task<IEnumerable<Word>> Select()
        {
            var entity = await _wordsRepository.Select();
            return _mapper.Map<List<Word>>(entity);
        }

        public async Task<IEnumerable<Word>> SelectIncludeKeyParamsProducts()
        {
            var entity = await _wordsRepository.SelectIncludeKeyParamsProducts();
            return _mapper.Map<List<Word>>(entity);
        }

        public async Task<Word> Update(Word entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.Word>(entity);
            var result = await _wordsRepository.Update(mapEntity);
            return _mapper.Map<Word>(result);
        }
    }
}
