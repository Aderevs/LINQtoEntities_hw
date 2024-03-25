using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DAL_V2.Entity;
using DAL_V2.Repository;

namespace BLL.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ActionPrice { get; set; }
        public string Description { get; set; }
        public string DescriptionField1 { get; set; }
        public string DescriptionField2 { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        [JsonIgnore]
        public List<Cart> Cart { get; set; }
        [JsonIgnore]
        public List<KeyParamsRepository> KeyWords { get; set; }
        public Product()
        {
            ImageUrl= string.Empty;
            Description = "123";
        }
    }
}
