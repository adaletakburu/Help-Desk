using HelpDesk.Common.Pagination.Filter;
using HelpDesk.Common.Pagination.Helpers;
using HelpDesk.Common.Pagination.Wrappers;
using HelpDesk.Common.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Common.Pagination.Extensions
{
    public static class PagingExtensions
    {

        public static async Task<PagedResponse<T>> GetPaged<T>(this IQueryable<T> query, int pageNumber, int pageSize, IUriService uriService, string route) where T : class
        {
            var validFilter = new PaginationFilter(pageNumber, pageSize);

            var pagedData = await query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).AsNoTracking().ToListAsync();

            var totalRecords = await query.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, uriService, route);
            return pagedReponse;
        }
    }
}
