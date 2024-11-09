using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_BusinessObjects
{
    public class AppResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public AppResponse(bool succeeded, string message, T data = default)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }
    }
}
