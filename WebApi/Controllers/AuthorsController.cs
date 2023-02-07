using Data.DTOs;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository _authorRepo;
        public AuthorsController(AuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorRepo.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            var authors = await _authorRepo.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet("{id}", Name = "AuthorById")]
        public async Task<ActionResult<AuthorDTO>> GetById(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AuthorDTO value)
        {
            var author = await _authorRepo.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            await _authorRepo.Update(value);

            return NoContent();
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AuthorDTO value)
        {
            await _authorRepo.Create(value);
            return Ok();

        }
    }
}
