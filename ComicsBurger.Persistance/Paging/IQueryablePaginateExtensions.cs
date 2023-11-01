using Microsoft.EntityFrameworkCore;

namespace ComicsBurger.Persistance.Paging
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<Paginate<T>> ToPaginateAsync<T>(
            this IQueryable<T> source,
            int index,
            int size,
            CancellationToken cancellationToken = default
            )
        {
            int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);

            List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

            Paginate<T> list = new()
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
