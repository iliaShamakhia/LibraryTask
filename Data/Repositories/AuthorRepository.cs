using Data.Context;
using Data.DTOs;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AuthorRepository : IRepositoryBase<AuthorDTO>
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Create(AuthorDTO entity)
        {
            var author = new Author
            {
                Name = entity.Name,
                Surname = entity.Surname,
                BirthYear = entity.BirthYear
            };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null) return;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();

            return authors.Select(a => new AuthorDTO
            {
                Id = a.Id,
                Name = a.Name,
                Surname = a.Surname,
                BirthYear = a.BirthYear
            });
        }

        public async Task<AuthorDTO> GetByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return null;
            };

            return new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                BirthYear = author.BirthYear
            };
        }

        public async Task Update(AuthorDTO entity)
        {
            var author = await _context.Authors.FindAsync(entity.Id);

            if(author == null)
            {
                return;
            }

            author.Name = entity.Name;
            author.Surname = entity.Surname;
            author.BirthYear = entity.BirthYear;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
