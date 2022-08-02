using MetalMogul.Dto.DtoModels;
using MetalMogul.JoinModels;

namespace MetalMogul.Dto.Converters
{
    public static class ConcertInfoConverter
    {
        public static ConcertInfoDto ToConcertInfoDto(this ConcertInfo concert)
        {
            return new ConcertInfoDto
            {
                BandName = concert.BandName,
                StartTime = concert.StartTime.ToString().Substring(0, 16),
                Price= (decimal)concert.Price
            };
        }

        public static List<ConcertInfoDto> ToConcertInfoDtoList(this List<ConcertInfo> concerts)
        {
            return concerts.Select(c => c.ToConcertInfoDto()).ToList();
        }
    }
}
