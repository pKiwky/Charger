using Charger.Domain.Models.Response.Queries;

namespace Charger.Application.Common {

    public class PaginatedResult<T> where T : class {
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
        public int DataCount { get; set; }
        public List<T> Results { get; set; }
    }

}
