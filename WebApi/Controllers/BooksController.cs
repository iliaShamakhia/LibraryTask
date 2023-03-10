using Data.DTOs;
using Data.Repositories;
using Data.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookrepo;
        private readonly BookValidator _validator;
        public BooksController(BookRepository bookrepo, BookValidator validator)
        {
            _bookrepo = bookrepo;
            _validator = validator;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookrepo.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> Get()
        {
            var books = await _bookrepo.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id}", Name = "BookById")]
        public async Task<ActionResult<BookDTO>> GetById(int id)
        {
            var book = await _bookrepo.GetByIdAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookDTO value)
        {
            var state = _validator.Validate(value);
            if (value == null || !state.IsValid)
            {
                return BadRequest(state.Errors);
            }
            var book = await _bookrepo.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookrepo.Update(value);

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] BookDTO value)
        {
            var state = _validator.Validate(value);
            if (value == null || !state.IsValid)
            {
                return BadRequest(state.Errors);
            }
            await _bookrepo.Create(value);
            return Ok();
        }
    }
}