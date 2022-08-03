using MetalMogul.Dto.DtoModels;
using MetalMogul.Dto.Request;
using MetalMogul.JoinModels;
using MetalMogul.Models;

namespace MetalMogul.Services.ConcertService
{
    public interface IConcertService
    {
        Task<List<ConcertInfoDto>> GetConcerts();
        Task<ConcertInfoDto> GetConcert(Guid concertId);
        Task BookTickets(BookTicketsRequestDto request);
    }
}
