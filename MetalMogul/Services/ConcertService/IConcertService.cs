using MetalMogul.Dto.DtoModels;
using MetalMogul.JoinModels;

namespace MetalMogul.Services.ConcertService
{
    public interface IConcertService
    {
        Task<List<ConcertInfoDto>> GetConcerts();
    }
}
