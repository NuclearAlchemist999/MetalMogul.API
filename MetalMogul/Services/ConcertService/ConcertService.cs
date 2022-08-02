using MetalMogul.Dto.Converters;
using MetalMogul.Dto.DtoModels;
using MetalMogul.JoinModels;
using MetalMogul.Repositories.ConcertRepository;

namespace MetalMogul.Services.ConcertService
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _concertRepo;

        public ConcertService(IConcertRepository concertRepo)
        {
            _concertRepo = concertRepo;
        }

        public async Task<List<ConcertInfoDto>> GetConcerts()
        {
            var concerts = await _concertRepo.GetConcerts();

            return concerts.ToConcertInfoDtoList();
        }
    }
}
