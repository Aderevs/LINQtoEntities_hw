using AutoMapper;
using BLL.Entity;
using BLL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class KeyParamsRepository : IKeyParamsRepository
    {
        DAL_V2.Interfaces.IKeyParamsRepository _keyParamsRepository;
        IMapper _mapper;
        public KeyParamsRepository(IMapper mapper, DAL_V2.Interfaces.IKeyParamsRepository serviceRepository)
        {
            _keyParamsRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(KeyParams entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.KeyParams>(entity);
            return await _keyParamsRepository.Create(mapEntity);
        }

        public async Task<bool> Delete(KeyParams entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.KeyParams>(entity);
            return await _keyParamsRepository.Delete(mapEntity);
        }

        public async Task<KeyParams> GetById(Guid id)
        {
            var entity = await _keyParamsRepository.GetById(id);
            return _mapper.Map<KeyParams>(entity);
        }

        public async Task<IEnumerable<KeyParams>> Select()
        {
            var entity = await _keyParamsRepository.Select();
            return _mapper.Map<List<KeyParams>>(entity);
        }

        public async Task<IEnumerable<KeyParams>> SelectIncludeWords()
        {
            var entity = await _keyParamsRepository.SelectIncludeWords();
            return _mapper.Map<List<KeyParams>>(entity);
        }

        public async Task<KeyParams> Update(KeyParams entity)
        {
            var mapEntity = _mapper.Map<DAL_V2.Entity.KeyParams>(entity);
            var result = await _keyParamsRepository.Update(mapEntity);
            return _mapper.Map<KeyParams>(result);
        }
    }
}
