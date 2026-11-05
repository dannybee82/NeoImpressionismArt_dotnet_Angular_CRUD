using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NeoImpressionismArtWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService) 
        {
            _artistService = artistService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {                
                return Ok(await _artistService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
