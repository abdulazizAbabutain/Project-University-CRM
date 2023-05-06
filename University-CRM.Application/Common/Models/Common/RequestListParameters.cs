using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Application.Common.Models.Common
{
    public abstract class RequestListParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get 
            {
                return _pageSize;
            }
            set 
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
        const int MaxPageSize = 50;
        private int _pageSize = 10;

    }
}
