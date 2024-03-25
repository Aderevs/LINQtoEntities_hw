using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;

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
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> AllProducts()
        {
            return await _productRepository.Select();
            //throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndPrice(string category, int max, int min)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndKeyWordsWithPrice(string category, string[] keywords, int max, int min)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> ProductsByWord(string word)
        {
            throw new NotImplementedException();
        }
    }
}
