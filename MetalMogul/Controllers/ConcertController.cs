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

        public async Task<IActionResult> GetConcerts()
        {
            var concerts = await _concertService.GetConcerts();

            return Ok(concerts);
        }
    }
}
