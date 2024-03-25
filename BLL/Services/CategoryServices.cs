using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;
using System.Xml.Linq;

namespace BLL.Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _categoryRepository;
        IKeyParamsRepository _keyParamsRepository;
        public CategoryServices(ICategoryRepository userRepository, IKeyParamsRepository productRepository)
        {
            _categoryRepository = userRepository;
            _keyParamsRepository = productRepository;
        }
        public async Task<bool> CreateCategory(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategory(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<Category> GetCategoryByName(string category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> AllCategories()
        {
            return await _categoryRepository.Select();
        }

        public async Task<Category> UpdateCategory(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryInfo> GetCategoryInfoByName(string category)
        {
            throw new NotImplementedException();
        }
    }
}
