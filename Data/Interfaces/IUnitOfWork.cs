using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepositoryBase<Book> BookRepository { get; }
        public IRepositoryBase<Author> AuthorRepository { get; }

        Task SaveAsync();
    }
}
