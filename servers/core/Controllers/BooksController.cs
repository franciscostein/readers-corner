using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersCorner.Core.DTOs;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var books = _service.GetAll();

            return Ok(_mapper.Map<IEnumerable<BookReadDTO>>(books));
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BookReadDTO> GetBookById(int id)
        {
            var book = _service.GetById(id);
            if (book != null)
                return Ok(_mapper.Map<BookReadDTO>(book));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<BookReadDTO>> CreateBookAsync(BookCreateDTO bookCreateDTO)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDTO);
            var book = _service.Add(bookModel);

            var bookReadDTO = _mapper.Map<BookReadDTO>(book);

            return CreatedAtRoute(nameof(GetBookById), new { bookReadDTO.Id }, bookReadDTO);
        }
    }
}