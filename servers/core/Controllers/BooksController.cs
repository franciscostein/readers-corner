using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadersCorner.Core.DTOs;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        public BooksController(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDTO>> GetBooks()
        {
            Console.WriteLine("--> Getting Books...");

            var books = _service.GetAll();

            return Ok(_mapper.Map<IEnumerable<BookReadDTO>>(books));
        }
    }
}