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
        public async Task<IActionResult> GetConcerts(string orderBy)
        {
            var concerts = await _concertService.GetConcerts(orderBy);

            return Ok(concerts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcert(Guid id, string orderBy)
        {
            var concert = await _concertService.GetConcert(id, orderBy);

            return Ok(concert);
        }

        [HttpPost]
        public async Task<IActionResult> BookTickets(BookTicketsRequestDto request)
        {
            var order = await _concertService.BookTickets(request);

            return Ok(order);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBandsAndConcerts([FromQuery] string searchQuery, string orderBy)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return BadRequest("Nothing");

            var searchItems = await _concertService.SearchBandsAndConcerts(searchQuery, orderBy);

            return Ok(searchItems);
        }
    }
}
