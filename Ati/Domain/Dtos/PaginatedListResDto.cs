using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PaginatedListResDto<T>
    {
        public PaginatedListResDto()
        {
            Lst = new List<T>();
        }
        public List<T> Lst { get; set; }
        public int CountAll { get; set; }
        public int PageNumber { get; set; }
    }
}
