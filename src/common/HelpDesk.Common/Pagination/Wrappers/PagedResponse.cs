﻿using System;
using System.Collections.Generic;

namespace HelpDesk.Common.Pagination.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
       
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri FirstPage { get; set; }
        public Uri PreviousPage { get; set; } 
        public Uri NextPage { get; set; }
        public Uri LastPage { get; set; }
        public PagedResponse(IList<T> data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
        }


    }

}
