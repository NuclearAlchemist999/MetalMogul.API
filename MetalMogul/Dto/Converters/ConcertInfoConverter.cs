using MetalMogul.Dto.DtoModels;
using MetalMogul.Models;

namespace MetalMogul.Dto.Converters
{
    public static class ConcertInfoConverter
    {
        public static ConcertInfoDto ToConcertInfoDto(this Concert concert)
        {
            return new ConcertInfoDto
            {
                Venue = concert.Venue.Name,
                Bands = concert.BandConcerts.Select(b => new BandDto
                {
                    BandName = b.Band.Name,
                    Description = b.Band.Description

                }).ToList(),
                StartTime = concert.StartTime.ToString().Substring(0, 16),
                Price= (decimal)concert.Price
            };
        }

        public static List<ConcertInfoDto> ToConcertInfoDtoList(this List<Concert> concerts)
        {
            return concerts.Select(c => c.ToConcertInfoDto()).ToList();
        }
    }
}
