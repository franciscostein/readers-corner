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

        [HttpPost]
        public async Task<ActionResult<AuthorReadDTO>> CreateAuthorAsync(AuthorCreateDTO authorDTO)
        {
            var authorModel = _mapper.Map<Author>(authorDTO);
            var author = _service.Add(authorModel);

            var authorReadDTO = _mapper.Map<AuthorReadDTO>(author);

            return CreatedAtRoute(nameof(GetAuthorById), new { authorReadDTO.Id }, authorReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int id, [FromBody] AuthorUpdateDTO authorDTO)
        {
            var authorModel = _mapper.Map<Author>(authorDTO);
            var updatedAuthor = _service.Update(id, authorModel);

            if (updatedAuthor == null)
                return NotFound();

            var author = _mapper.Map<AuthorReadDTO>(updatedAuthor);

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var deletedSuccefully = _service.Delete(id);
            if (!deletedSuccefully)
                return NotFound();

            return Ok();
        }
    }
}