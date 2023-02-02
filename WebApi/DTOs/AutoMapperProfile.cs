using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>()
                .ForMember(authorDto => authorDto.BookTitles, author => author.MapFrom(a => a.Books.Select(b => b.Title)))
                .ReverseMap();
        }
    }
}
