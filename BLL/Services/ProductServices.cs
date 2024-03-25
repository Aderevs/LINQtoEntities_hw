using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;
using System.Linq;

namespace BLL.Services
{
    public class ProductServices : IProductServices
    {
        IProductRepository _productRepository;
        IKeyParamsRepository _keyParams;
        public ProductServices(IProductRepository userRepository, IKeyParamsRepository keyParams)
        {
            _productRepository = userRepository;
            _keyParams = keyParams;
        }
        public async Task<bool> CreateProduct(Product entity)
        {
            return await _productRepository.Create(entity);
        }

        public async Task<bool> DeleteProduct(Product entity)
        {
            return await _productRepository.Delete(entity);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IEnumerable<Product>> AllProducts()
        {
            return await _productRepository.Select();
        }

        public async Task<Product> UpdateProduct(Product entity)
        {
            return await (_productRepository.Update(entity));
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndPrice(string category, int max, int min)
        {
            var products = await _productRepository.SelectIncludeCategory();

            return products
                .Where(p => p.Category.Name == category)
                .Where(p => p.Price <= max && p.Price >= min);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndKeyWordsWithPrice(string category, string[] keywords, int max, int min)
        {
            var products = await _productRepository.SelectIncludeCategory();

            return products
                .Where(p => p.Category.Name == category)
                .Where(p =>
                {
                    var prodsKeywords = p.KeyWords.Select(kw => kw.KeyWords.KeyWord);
                    foreach (var word in keywords)
                    {
                        if (prodsKeywords.Contains(word))
                            return true;
                    }
                    return false;
                })
                .Where(p => p.Price <= max && p.Price >= min);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _productRepository.GetByIdIncludWord(name);
        }

        public async Task<IEnumerable<Product>> ProductsByWord(string word)
        {
            var products = await _productRepository.Select();
            var prod = products.Where(p =>
                {
                    var prodsKeywords = p.KeyWords.Select(kw => kw.KeyWords.KeyWord);
                    if (prodsKeywords.Contains(word))
                        return true;
                    return p.Name.Contains(word);
                }).ToList();
            return prod;
        }
    }
}
