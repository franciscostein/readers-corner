using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadersCorner.Core.DTOs;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorReadDTO>> GetAuthors()
        {
            var authors = _service.GetAll();

            return Ok(_mapper.Map<IEnumerable<AuthorReadDTO>>(authors));
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public ActionResult<AuthorReadDTO> GetAuthorById(int id)
        {
            var author = _service.GetById(id);
            if (author != null)
                return Ok(_mapper.Map<AuthorReadDTO>(author));

            return NotFound();
        }
    }
}