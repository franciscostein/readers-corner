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
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<BookCreateDTO, Book>();
            CreateMap<Author, AuthorReadDTO>();
            CreateMap<AuthorUpdateDTO, Author>();
            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<User, UserReadDTO>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}