﻿using Data.Context;
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
    public class AuthorRepository : IRepositoryBase<Author>
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Create(Author entity)
        {
            await _context.Authors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null) return;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
            //return await _context.Authors
            //     .Include(a => a.Books)
            //     .ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return null;
            };

            return author;
        }

        public async Task Update(Author entity)
        {
            var author = await _context.Authors.FindAsync(entity.Id);

            if(author == null)
            {
                throw new NullReferenceException();
            }

            author.Name = entity.Name;
            author.Surname = entity.Surname;
            author.BirthYear = entity.BirthYear;
            author.Books = entity.Books;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
