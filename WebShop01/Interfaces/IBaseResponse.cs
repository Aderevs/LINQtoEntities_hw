using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop01.Enum;

namespace WebShop01.Interfaces
{
    public interface IBaseResponse<T>
    {
        ResponseStatusCode StatusCode { get; }
        T Data { get; }
    }
}
