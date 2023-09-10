using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersCorner.Core.DTOs;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            var users = _service.GetAll();

            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(users));
        }

        [HttpGet("{id}", Name = nameof(GetUserById))]
        public ActionResult<UserReadDTO> GetUserById(int id)
        {
            var user = _service.GetById(id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDTO>(user));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> CreateUserAsync(UserCreateDTO userDTO)
        {
            var userModel = _mapper.Map<User>(userDTO);
            var user = _service.Add(userModel);

            var userReadDTO = _mapper.Map<UserReadDTO>(user);

            return CreatedAtAction(nameof(GetUserById), new { userReadDTO.Id }, userReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateDTO userDTO)
        {
            var userModel = _mapper.Map<User>(userDTO);
            var updatedUser = _service.Update(id, userModel);

            if (updatedUser == null)
                return NotFound();

            var user = _mapper.Map<UserReadDTO>(updatedUser);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var deletedSuccefully = _service.Delete(id);
            if (!deletedSuccefully)
                return NotFound();

            return Ok();
        }
    }
}