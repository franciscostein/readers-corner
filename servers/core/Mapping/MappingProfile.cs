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
        }
    }
}