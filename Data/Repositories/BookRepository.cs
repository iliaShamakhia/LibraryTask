using Data.Context;
using Data.DTOs;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : IRepositoryBase<BookDTO>
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Create(BookDTO entity)
        {
            var book = new Book
            {
                Title = entity.Title,
                Description = entity.Description,
                PublishDate = DateTime.Now,
                ImageUrl = entity.ImageUrl,
                IsAvailable = entity.IsAvailable,
                Rating = entity.Rating,
            };

            var authors = new List<BookAuthor>();

            foreach (var item in entity.Authors)
            {
                var author = new Author
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    BirthYear = item.BirthYear
                };
                authors.Add(new BookAuthor
                {
                    Author = author,
                    Book = book
                });
            }
            book.Authors = authors;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) return;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var result = await _context.Books
                .Include(b => b.Authors)
                .ThenInclude(a => a.Author).ToListAsync();

            return result.Select(bk => new BookDTO
            {
                Id = bk.Id,
                Title = bk.Title,
                Description = bk.Description,
                PublishDate = bk.PublishDate,
                ImageUrl = bk.ImageUrl,
                IsAvailable = bk.IsAvailable,
                Rating = bk.Rating,
                Authors = bk.Authors.Select(a => new AuthorDTO
                {
                    Id = a.Author.Id,
                    Name = a.Author.Name,
                    Surname = a.Author.Surname,
                    BirthYear = a.Author.BirthYear
                }).ToList(),
            });
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Authors)
                .ThenInclude(a => a.Author)
                .SingleOrDefaultAsync(bk => bk.Id == id);

            if (book == null)
            {
                return null;
            }
            var bookDto = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                PublishDate = book.PublishDate,
                ImageUrl = book.ImageUrl,
                IsAvailable = book.IsAvailable,
                Rating = book.Rating,
                Authors = book.Authors.Select(a => new AuthorDTO
                {
                    Id = a.Author.Id,
                    Name = a.Author.Name,
                    Surname = a.Author.Surname,
                    BirthYear = a.Author.BirthYear
                }).ToList(),
            };
            return bookDto;
        }

        public async Task Update(BookDTO entity)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == entity.Id);

            if (book == null)
            {
                return;
            }

            book.Title = entity.Title;
            book.Description = entity.Description;
            book.Rating = entity.Rating;
            book.ImageUrl = entity.ImageUrl;
            book.PublishDate = entity.PublishDate;
            book.IsAvailable = entity.IsAvailable;

            var authorsIds = book.Authors.Select(a => a.Author.Id).ToList();
            var editedAuthorsIds = entity.Authors.Select(a => a.Id);

            foreach(var i in authorsIds)
            {
                if (!editedAuthorsIds.Contains(i))
                {
                    var bookAuthor = book.Authors.First(a => a.Author.Id == i);
                    book.Authors.Remove(bookAuthor);
                }
            }
            foreach (var i in entity.Authors)
            {
                if (!authorsIds.Contains(i.Id))
                {
                    var author = new Author
                    {
                        Name = i.Name,
                        Surname = i.Surname,
                        BirthYear = i.BirthYear
                    };
                    book.Authors.Add(new BookAuthor
                    {
                        Author = author,
                        Book = book
                    });
                }
            }

            foreach (var auth in entity.Authors)
            {
                foreach (var a in book.Authors)
                {
                    if (a.Author.Id == auth.Id)
                    {
                        a.Author.Name = auth.Name;
                        a.Author.Surname = auth.Surname;
                        a.Author.BirthYear = auth.BirthYear;
                    }
                }
            }

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
