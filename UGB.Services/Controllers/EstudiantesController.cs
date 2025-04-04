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
using UGB.Domain.Wrapper;
using UGB.Services.Interfaces;
namespace UGB.Services.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IRaPersonasRepository raPersonasRepository;
        private readonly IValidator<ra_per_personas> validatorPersonas;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        public EstudiantesController(IRaPersonasRepository _raPersonasRepository, IValidator<ra_per_personas> _validatorPersonas, IMapper _mapper, IEmailService _emailService)
        {
            raPersonasRepository = _raPersonasRepository;
            validatorPersonas = _validatorPersonas;
            mapper = _mapper;
            emailService = _emailService;
        }

        public async Task<IActionResult> Get(int? currentPage, string searchTerm = "")
        {
            var response = await raPersonasRepository.GetAllPaged(currentPage ?? 1, searchTerm);
            PagedResult<EstudianteDTO> paged = mapper.Map<PagedResult<EstudianteDTO>>(response);
            return Ok(paged);
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
            if(estudiante.per_dui.Length < 10)
            {
                throw new CustomValidationException(nameof(estudiante.per_dui), "El DUI debe ser de al menos 10 caracteres.");
            }

            if(await raPersonasRepository.ExistsCarnet(estudiante.per_codigo, estudiante.per_carnet))
            {
                throw new HttpRequestException("Ya existe un estudiante con este carnet.");
            }

            await raPersonasRepository.Create(estudiante);           
            return Created($"/estudiantes/{estudiante.per_codigo}", estudiante);
        }
    }
}