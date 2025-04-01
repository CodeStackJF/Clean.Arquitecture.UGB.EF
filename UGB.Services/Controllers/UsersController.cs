using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UGB.Application.DTO;
using UGB.Application.Exceptions;
using UGB.Application.Helper;
using UGB.Application.Validations;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;
        private readonly IValidator<UserDTO> userValidation;
        public UsersController(IUsersRepository _usersRepository, IMapper _mapper, IValidator<UserDTO> _userValidation)
        {
            usersRepository = _usersRepository;
            mapper = _mapper;
            userValidation = _userValidation;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            var validation = userValidation.Validate(userDTO);
            if(!validation.IsValid)
            {
                throw new CustomValidationException(validation.Errors);
            }
            
            if(await usersRepository.Exists(userDTO.username))
            {
                throw new HttpRequestException("Ya existe este usuario.");
            }

            users user = mapper.Map<users>(userDTO);
            HashedPassword hashedPassword = HashHelper.Hash(userDTO.password);
            user.salt = hashedPassword.Salt;
            user.password = hashedPassword.Password;
            user.active = true;
            await usersRepository.Create(user);
            return Created("/Users/" + user.id, userDTO);
        }
    }
}