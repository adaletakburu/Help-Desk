using HelpDesk.Common.Pagination.Filter;
using HelpDesk.Common.Pagination.Wrappers;
using HelpDesk.Common.Services;
using System;
using System.Collections.Generic;

namespace HelpDesk.Common.Pagination.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<T> CreatePagedReponse<T>(IList<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
        {
            var respose = new PagedResponse<T>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = totalRecords / (double)validFilter.PageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            respose.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
