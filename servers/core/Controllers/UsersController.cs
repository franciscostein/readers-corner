using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersCorner.Core.DTOs;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Controllers
{
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

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDTO> GetUserById(int id)
        {
            var user = _service.GetById(id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDTO>(user));

            return NotFound();
        }
    }
}