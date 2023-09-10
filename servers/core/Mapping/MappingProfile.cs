using AutoMapper;
using ReadersCorner.Core.DTOs;
using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookReadDTO>();
            CreateMap<Book, BookUpdateDTO>();
            CreateMap<BookCreateDTO, Book>();
            CreateMap<Author, AuthorReadDTO>();
            CreateMap<Author, AuthorUpdateDTO>();
            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}