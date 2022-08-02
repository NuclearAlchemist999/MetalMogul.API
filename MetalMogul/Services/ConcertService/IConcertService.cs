using MetalMogul.Dto.DtoModels;
using MetalMogul.JoinModels;
using MetalMogul.Models;

namespace MetalMogul.Services.ConcertService
{
    public interface IConcertService
    {
        Task<List<ConcertInfoDto>> GetConcerts();
        Task<ConcertInfoDto> GetConcert(Guid concertId);
    }
}
