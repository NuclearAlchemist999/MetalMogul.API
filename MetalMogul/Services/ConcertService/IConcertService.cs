using MetalMogul.Dto.DtoModels;
using MetalMogul.Dto.Request;
using MetalMogul.JoinModels;
using MetalMogul.Models;

namespace MetalMogul.Services.ConcertService
{
    public interface IConcertService
    {
        Task<List<ConcertInfo>> GetConcerts();
        Task<ConcertInfo> GetConcert(Guid concertId);
        Task<OrderInfo> BookTickets(BookTicketsRequestDto request);
    }
}
