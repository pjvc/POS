using POS.Infrastructura.Commons.Bases.Request;

namespace POS.Infrastructura.Helpers
{
    public static class QueyableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }
    }
}
