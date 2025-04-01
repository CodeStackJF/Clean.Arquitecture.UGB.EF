using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UGB.Application.Exceptions;
using UGB.Application.Helper;
using UGB.Application.Validations;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Domain.Primitives;

namespace UGB.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Policy = "HeaderToken")]
    [Authorize]
    public class CarrerasController:ControllerBase
    {
        private readonly IRaCarrerasRepository raCarrerasRepository;
        private readonly IValidator<ra_car_carreras> carreraValidator;
        public CarrerasController(IRaCarrerasRepository _raCarrerasRepository, IValidator<ra_car_carreras> _carreraValidator)
        {
            raCarrerasRepository = _raCarrerasRepository;
            carreraValidator = _carreraValidator;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await raCarrerasRepository.GetAll());
        }

        [HttpGet("Planes")]
        public async Task<IActionResult> GetWithPlanes()
        {
            return Ok(await raCarrerasRepository.GetAllWithPlanes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await raCarrerasRepository.Get(id);
            if(result == null)
            {
                throw new NotFoundException("Carrera no encontrada.");
            }
            return Ok(result);
        }

        [HttpGet("{id}/Planes")]
        public async Task<IActionResult> GetWithPlanes(int id)
        {
            var result = await raCarrerasRepository.GetWithPlanes(id);
            if(result == null)
            {
                throw new NotFoundException("Carrera no encontrada.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ra_car_carreras carrera)
        {
            var validation = carreraValidator.Validate(carrera);
            if(!validation.IsValid)
            {
                throw new CustomValidationException(validation.Errors);
            }

            if(await raCarrerasRepository.ExistsName(carrera.car_codigo, carrera.car_nombre))
            {
                throw new HttpRequestException($"Ya existe una carrera con este nombre ({carrera.car_nombre}).");
            }
            var response = await raCarrerasRepository.Create(carrera);
            return Created("", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!await raCarrerasRepository.Exists(id))
            {
                throw new NotFoundException("La carrera no existe.");
            }
            await raCarrerasRepository.Delete(id);
            return NoContent();
        }
    }
}