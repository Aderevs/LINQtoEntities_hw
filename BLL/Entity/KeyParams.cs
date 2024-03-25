using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class KeyParams
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Word KeyWords { get; set; }
    }
}
