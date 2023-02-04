using Data.DTOs;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookrepo;
        public BooksController( BookRepository bookrepo)
        {
            _bookrepo = bookrepo;
        }

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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookDTO value)
        {
            var book = await _bookrepo.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookrepo.Update(value);

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> Add([FromBody] BookDTO value)
        {
            await _bookrepo.Create(value);
            return CreatedAtRoute("BookById",value.Id, value);

        }
    }
}