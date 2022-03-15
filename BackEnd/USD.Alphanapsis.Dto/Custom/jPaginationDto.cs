using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class jPaginationDto<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public List<T> rows { get; set; } 
    } 
}
