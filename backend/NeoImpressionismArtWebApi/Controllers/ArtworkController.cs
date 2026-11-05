using Application.DataTransferObjects;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NeoImpressionismArtWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [HttpGet("GetPagedList")]
        public async Task<IActionResult> GetPagedList(int pageNumber, int pageSize)
        {
            try
            {
                var pagedList = await _artworkService.GetPagedList(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            try
            {
                var img = await _artworkService.GetImage(id);
                if (img is null) return NotFound();
                // streams raw bytes
                return File(img.Image, img.ContentType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _artworkService.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(IFormFile file, [FromForm] CreateOrUpdateArtworkDto dto)
        {
            try
            {
                await _artworkService.Create(file, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(IFormFile? file, [FromForm] CreateOrUpdateArtworkDto dto)
        {
            try
            {
                await _artworkService.Update(file, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _artworkService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
