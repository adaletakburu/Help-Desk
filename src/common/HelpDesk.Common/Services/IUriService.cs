using HelpDesk.Common.Pagination.Filter;
using System;

namespace HelpDesk.Common.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
