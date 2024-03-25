using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class CategoryInfo
    {
        public IDictionary<string, string[]> Selections { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
