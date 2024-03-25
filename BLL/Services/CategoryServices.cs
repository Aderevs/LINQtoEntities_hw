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
            return await _categoryRepository.Create(entity);
        }

        public async Task<bool> DeleteCategory(Category entity)
        {
            return await _categoryRepository.Delete(entity);
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }
        public async Task<Category> GetCategoryByName(string category)
        {
            var categories = await _categoryRepository.Select();
            return categories
                .FirstOrDefault(c => c.Name == category);
        }

        public async Task<IEnumerable<Category>> AllCategories()
        {
            return await _categoryRepository.Select();
        }

        public async Task<Category> UpdateCategory(Category entity)
        {
            return await _categoryRepository.Update(entity);
        }

        public async Task<CategoryInfo> GetCategoryInfoByName(string category)
        {
            var categories = await _categoryRepository.SelectIncludeProducts();
            var certainCategory = categories
                .FirstOrDefault(c => c.Name == category);
            if(certainCategory != null)
            {

                var maxPrice = certainCategory.Products
                    .Max(p => p.Price);
                var minPrice = certainCategory.Products
                    .Min(p => p.Price);
                return new CategoryInfo
                {
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    CategoryName = category
                };
            }
            else
            {
                return null;
            }
        }
    }
}
