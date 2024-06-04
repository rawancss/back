using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithJWT.Dtos
{
    public class PagedResult<T>
    {
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T>? Data { get; set; }
    }
}
