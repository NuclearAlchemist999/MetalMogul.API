using MetalMogul.Data;
using MetalMogul.JoinModels;
using Microsoft.EntityFrameworkCore;

namespace MetalMogul.Repositories.ConcertRepository
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly MetalDbContext _metalDbContext;
        public ConcertRepository(MetalDbContext metalDbContext)
        {
            _metalDbContext = metalDbContext;
        }

        public async Task<List<ConcertInfo>> GetConcerts()
        {
            var concerts = await (from v in _metalDbContext.Venues
                                  join c in _metalDbContext.Concerts on v.Id equals c.VenueId
                                  join bc in _metalDbContext.Bands_Concerts on c.Id equals bc.ConcertId
                                  join b in _metalDbContext.Bands on bc.BandId equals b.Id
                                  select new ConcertInfo
                                  {
                                      BandName = b.Name,
                                      StartTime = c.StartTime,
                                      Venue = v.Name,
                                      Price = c.Price

                                  }).ToListAsync();

            return concerts;
        }
    }
}
