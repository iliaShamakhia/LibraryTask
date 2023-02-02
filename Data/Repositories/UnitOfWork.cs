using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private readonly IRepositoryBase<Book> _bookRepository;
        private readonly IRepositoryBase<Author> _authorRepository;
        public UnitOfWork(LibraryDbContext context) 
        {
            _context = context;
            _bookRepository = new BookRepository(_context);
            _authorRepository = new AuthorRepository(_context);
        }

        public IRepositoryBase<Book> BookRepository
        {
            get
            {
                return _bookRepository;
            }
        }

        public IRepositoryBase<Author> AuthorRepository
        {
            get
            {
                return _authorRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
