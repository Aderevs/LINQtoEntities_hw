using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V3.Entity
{
    public class Word
    {
        [Key]
        public Guid Id { get; set; }
        public string KeyWord { get; set; }
        public List<KeyParamsRepository> ProductLink { get; set; }
    }
}
