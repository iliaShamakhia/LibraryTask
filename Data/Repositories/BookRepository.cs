using Data.Context;
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
    public class BookRepository : IRepositoryBase<Book>
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Create(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) return;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return null;
            }

            return book;
        }

        public async Task Update(Book entity)
        {
            var book = await _context.Books.FindAsync(entity.Id);

            if(book == null)
            {
                return;
            }

            book.Title = entity.Title;
            book.Description = entity.Description;
            book.Rating = entity.Rating;
            book.ImageUrl = entity.ImageUrl;
            book.PublishDate = entity.PublishDate;
            book.IsAvailable = entity.IsAvailable;
            book.Authors = entity.Authors;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
