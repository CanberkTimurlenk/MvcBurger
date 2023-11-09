using Microsoft.EntityFrameworkCore;

namespace MvcBurger.Persistance.Paging
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<PagedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            int index,
            int size
            )
        {
            int count = await source.CountAsync().ConfigureAwait(false);

            List<T> items = await source.Skip(index * size).Take(size).ToListAsync().ConfigureAwait(false);

            PagedList<T> list = new()
            {
                Index = index,
                Count = count,
                Items = items,
                Size = size,
                Pages = (int)Math.Ceiling(count / (double)size)
            };
            return list;

        }
    }
}
