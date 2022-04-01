using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenAuthorization.Filter
{
    public class SkipAttribute : Attribute, IFilterMetadata
    {
        ///允许未通过身份验证也可以访问的特性
    }
}
