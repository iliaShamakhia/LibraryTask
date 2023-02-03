using AutoMapper;
using Data.Context;
using Data.DTOs;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BookRepository _bookrepo;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, BookRepository bookrepo)
        {
            _logger = logger;
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
            return Ok();
            
        }
    }
}