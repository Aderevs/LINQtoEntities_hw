using BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface ICategoryServices
    {
        public Task<bool> CreateCategory(Category entity);
        public Task<bool> DeleteCategory(Category entity);
        public Task<Category> UpdateCategory(Category entity);
        public Task<IEnumerable<Category>> AllCategories();
        public Task<Category> GetCategoryById(Guid id);
        public Task<Category> GetCategoryByName(string category);
        public Task<CategoryInfo> GetCategoryInfoByName(string category);
    }
}
