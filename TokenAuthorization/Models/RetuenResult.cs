using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenAuthorization.Models
{
    public class RetuenResult<T>
    {
        public int code { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}
