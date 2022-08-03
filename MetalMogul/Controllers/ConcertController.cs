using MetalMogul.Dto.Request;
using MetalMogul.Services.ConcertService;
using Microsoft.AspNetCore.Mvc;

namespace MetalMogul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly IConcertService _concertService;

        public ConcertController(IConcertService concertService)
        {
            _concertService = concertService;
        }

        [HttpGet]
        public async Task<IActionResult> GetConcerts()
        {
            var concerts = await _concertService.GetConcerts();

            return Ok(concerts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcert(Guid id)
        {
            var concert = await _concertService.GetConcert(id);

            return Ok(concert);
        }

        [HttpPost]
        public async Task<IActionResult> BookTickets(BookTicketsRequestDto request)
        {
            await _concertService.BookTickets(request);

            return Ok();
        }
    }
}
