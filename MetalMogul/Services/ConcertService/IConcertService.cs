using MetalMogul.Dto.DtoModels;
using MetalMogul.Dto.Request;
using MetalMogul.Models;

namespace MetalMogul.Services.ConcertService
{
    public interface IConcertService
    {
        Task<List<ConcertInfoDto>> GetConcerts(string orderBy);
        Task<ConcertInfoDto> GetConcert(Guid concertId, string orderBy);
        Task<OrderInfoDto> BookTickets(BookTicketsRequestDto request);
        Task<List<ConcertInfoDto>> SearchBandsAndConcerts(string searchQuery, string orderBy);
    }
}
