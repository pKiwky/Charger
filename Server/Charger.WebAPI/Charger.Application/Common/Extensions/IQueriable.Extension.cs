using Charger.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Charger.Application.Common.Extensions {

    public static class IQueriable {
        public static async Task<PaginatedResult<TOut>> GetPaginated<T, TOut>(this IQueryable<T> query, int pageNumber, int pageSize) where T : class where TOut : class {
            var paginatedResult = new PaginatedResult<TOut>();

            int skip = (pageNumber - 1) * pageSize;

            paginatedResult.CurrentPage = pageNumber;
            paginatedResult.DataCount = pageSize;
            paginatedResult.Results = await query.Where(e => (e as Entity).Deleted == false).Skip(skip).Take(pageSize).ProjectToType<TOut>().ToListAsync();
            paginatedResult.LastPage = (int)Math.Floor((double)paginatedResult.Results.Count / pageSize);

            if (paginatedResult.LastPage == 0) {
                paginatedResult.LastPage = 1;
            }

            return paginatedResult;
        }
    }

}
