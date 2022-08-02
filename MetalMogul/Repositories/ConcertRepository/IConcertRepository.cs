using MetalMogul.JoinModels;
using MetalMogul.Models;

namespace MetalMogul.Repositories.ConcertRepository
{
    public interface IConcertRepository
    {
        Task<List<ConcertInfo>> GetConcerts();
    }
}
