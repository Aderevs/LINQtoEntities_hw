using BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface IProductServices
    {
        public Task<bool> CreateProduct(Product entity);
        public Task<bool> DeleteProduct(Product entity);
        public Task<Product> UpdateProduct(Product entity);
        public Task<IEnumerable<Product>> AllProducts();
        public Task<IEnumerable<Product>> ProductsByWord(string word);
        public Task<Product> GetProductById(Guid id);
        public Task<Product> GetProductByName(string name);
        public Task<IEnumerable<Product>> GetProductsByCategoryAndPrice(string category, int max, int min);
        public Task<IEnumerable<Product>> GetProductsByCategoryAndKeyWordsWithPrice(string category, string[] keywords, int max, int min);
    }
}
