using Data.Context;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private void SeedData()
        {
            var author1 = new Author
            {
                Name = "name1",
                Surname = "surname1",
                BirthYear = new DateTime()
            };
            var author2 = new Author
            {
                Name = "name2",
                Surname = "surname2",
                BirthYear = new DateTime()
            };
            var author3 = new Author
            {
                Name = "name3",
                Surname = "surname3",
                BirthYear = new DateTime()
            };
            var author4 = new Author
            {
                Name = "name4",
                Surname = "surname4",
                BirthYear = new DateTime()
            };
            _context.Books.AddRange(
                    new Book
                    {
                        Title = "title1",
                        Description = "desription1",
                        PublishDate = new DateTime(),
                        ImageUrl = "imageurl1",
                        IsAvailable = true,
                        Rating = 4.5,
                        Authors = new List<Author> { author1, author2, }
                    },
                new Book
                {
                    Title = "title2",
                    Description = "desription2",
                    PublishDate = new DateTime(),
                    ImageUrl = "imageurl2",
                    IsAvailable = true,
                    Rating = 4.5,
                    Authors = new List<Author> { author3, author4, }
                },
                new Book
                {
                    Title = "title3",
                    Description = "desription3",
                    PublishDate = new DateTime(),
                    ImageUrl = "imageurl3",
                    IsAvailable = true,
                    Rating = 4.5,
                    Authors = new List<Author> { author1, author3, }
                },
                new Book
                {
                    Title = "title4",
                    Description = "desription4",
                    PublishDate = new DateTime(),
                    ImageUrl = "imageurl4",
                    IsAvailable = true,
                    Rating = 4.5,
                    Authors = new List<Author> { author2, author4, }
                }
                 );
                
        }
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly LibraryDbContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, LibraryDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Book> Get()
        {
            if (!_context.Books.Any())
            {
                SeedData();
            }
            return _context.Books.Include(b => b.Authors).ToList();
        }
    }
}