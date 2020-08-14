using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Birras.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T response)
        {
            Response = response;
        }
        
        public T Response { get; set; }

    }
}
