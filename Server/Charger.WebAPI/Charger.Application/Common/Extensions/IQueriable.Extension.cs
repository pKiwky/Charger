using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Application.Common.Extensions {

    public static class IQueriable {
        public static async Task<PaginatedResult<TOut>> GetPaginated<T, TOut>(this IQueryable<T> query, int pageNumber, int pageSize) where T : class where TOut : class {
            var paginatedResult = new PaginatedResult<TOut>();

            int rowCount = await query.CountAsync();
            int skip = (pageNumber - 1) * pageSize;

            paginatedResult.CurrentPage = pageNumber;
            paginatedResult.LastPage = (int)Math.Ceiling((double)rowCount / pageSize);
            paginatedResult.DataCount = pageSize;
            paginatedResult.Results = await query.Skip(skip).Take(pageSize).ProjectToType<TOut>().ToListAsync();
            
            if(paginatedResult.LastPage == 0) {
                paginatedResult.LastPage = 1;
            }

            return paginatedResult;
        }
    }

}
