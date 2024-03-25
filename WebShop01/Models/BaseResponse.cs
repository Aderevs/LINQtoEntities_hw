using WebShop01.Enum;
using WebShop01.Interfaces;

namespace WebShop01.Models
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public ResponseStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public BaseResponse()
        {
            StatusCode = ResponseStatusCode.OK;
            Message = "Success";
        }
    }
}
