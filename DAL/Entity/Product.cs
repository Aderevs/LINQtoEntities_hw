using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public Guid CategoryId { get; set; }
        [NotMapped]
        public ProductCategory Category { get; set; }   
    }
}
