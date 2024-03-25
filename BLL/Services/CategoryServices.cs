using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;
using System.Linq;
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
            if (certainCategory != null)
            {

                var maxPrice = certainCategory.Products
                    .Max(p => p.Price);
                var minPrice = certainCategory.Products
                    .Min(p => p.Price);
                Dictionary<string, List<string>> selectionsComfortable = new();
                foreach(var product in certainCategory.Products)
                {
                    foreach(var word in product.KeyWords)
                    {
                        if (!selectionsComfortable.ContainsKey(word.KeyWords.Header))
                        {
                            selectionsComfortable.Add(word.KeyWords.Header, new());
                        }
                        else
                        {
                            selectionsComfortable[word.KeyWords.Header].Add(word.KeyWords.KeyWord);
                        }
                    }
                }
                    Dictionary<string, string[]> selections = new();
                    foreach (var selection in selectionsComfortable)
                    {
                        string[] words = new string[selection.Value.Count];
                        for (int i = 0; i < selection.Value.Count; i++)
                        {
                            words[i] = selection.Value[i];
                        }
                        selections.Add(selection.Key, words);
                    }
                return new CategoryInfo
                {
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    CategoryName = category,
                    Selections = selections
                };
            }
            else
            {
                return null;
            }
        }
    }
}
