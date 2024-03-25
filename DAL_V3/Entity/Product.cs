using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_V2.Repository;

namespace DAL_V3.Entity
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public double Cost { get; set; }
        //public string Description { get; set; }
        //public string ImageUrl { get; set; }
        //public float Promotion { get; set; }
        //public int Quantity { get; set; }
        public Category Category { get; set; }
        public List<Cart> Cart { get; set; }
        public List<KeyParamsRepository> KeyWords { get; set; }
    }
}
