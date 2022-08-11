using MetalMogul.Models;

namespace MetalMogul.Extensions
{
    public static class ConcertExtensions
    {
        public static IQueryable<Concert> Sort(this IQueryable<Concert> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(c => c.StartTime);

            query = orderBy switch
            {
                "startAsc" => query.OrderBy(c => c.StartTime),
                "startDesc" => query.OrderByDescending(c => c.StartTime),
                "priceAsc" => query.OrderBy(c => c.Price),
                "priceDesc" => query.OrderByDescending(c => c.Price),
                "venueAsc" => query.OrderBy(c => c.Venue.Name),
                "venueDesc" => query.OrderByDescending(c => c.Venue.Name),
                _ => query.OrderBy(c => c.StartTime),
            };

            return query;
        }
    }
}
