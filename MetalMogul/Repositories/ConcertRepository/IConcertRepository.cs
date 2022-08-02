using MetalMogul.JoinModels;

namespace MetalMogul.Repositories.ConcertRepository
{
    public interface IConcertRepository
    {
        Task<List<ConcertInfo>> GetConcerts();
    }
}
