using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V2.Entity
{
    public class KeyParams
    {
        public Guid Id { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public Word? KeyWords { get; set; }
        public Guid KeyWordsId { get; set; }
    }
}
