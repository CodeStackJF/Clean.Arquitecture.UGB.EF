using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UGB.Application.DTO;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Application.Helper;
using UGB.Application.Exceptions;
using FluentValidation.Results;
namespace UGB.Services.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IRaPersonasRepository raPersonasRepository;
        private readonly IValidator<ra_per_personas> validatorPersonas;
        private readonly IMapper mapper;
        public EstudiantesController(IRaPersonasRepository _raPersonasRepository, IValidator<ra_per_personas> _validatorPersonas, IMapper _mapper)
        {
            raPersonasRepository = _raPersonasRepository;
            validatorPersonas = _validatorPersonas;
            mapper = _mapper;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await raPersonasRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var estudiante = await raPersonasRepository.GetWithNestedData(id);
            EstudianteDTO estudianteDTO = mapper.Map<EstudianteDTO>(estudiante);
            return Ok(estudianteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ra_per_personas estudiante)
        {
            /*IEnumerable<ValidationFailure> failures = new List<ValidationFailure>();
            failures.Append(new ValidationFailure(){ PropertyName = nameof(estudiante.per_dui), ErrorMessage = "El DUI debe ser de al menos 10 caracteres." });
            throw new CustomValidationException(failures);*/

            if(estudiante.per_dui.Length < 10)
            {
                throw new CustomValidationException(nameof(estudiante.per_dui), "El DUI debe ser de al menos 10 caracteres.");
            }
            await raPersonasRepository.Create(estudiante);
            return Created($"/estudiantes/{estudiante.per_codigo}", estudiante);
        }
    }
}