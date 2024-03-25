using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Cart
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
