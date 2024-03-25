using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V3.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public string Profile { get; set; }
        //public string About { get; set; }
        //public string LastName { get; set; }
        //public string Login { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        public List<Cart> Cart { get; set; }
    }
}
