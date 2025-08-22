using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapiMongoDB.Dto;
using webapiMongoDB.Model;
using webapiMongoDB.Service;

namespace webapiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicencaController : Controller
    {
        private readonly ILicencaService _licencaService;
        private readonly IMapper _mapper;
        public LicencaController(ILicencaService licencaService, IMapper mapper)
        {
            _licencaService = licencaService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<LicencaResponseDTO>>> GetAllLicences()
        {
            var licenca = await _licencaService.GetAllLicencasAsync();
            var response = _mapper.Map<List<LicencaResponseDTO>>(licenca);
            return Ok(response);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<LicencaResponseDTO>> GetById(string id)
        {
            var licenca = await _licencaService.GetLicencaByIdAsync(id);
            if (licenca == null)
                return NotFound();

            var response = _mapper.Map<LicencaResponseDTO>(licenca);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LicencaResponseDTO>> Update(string id, [FromBody] LicencaRequestDTO dto)
        {
            var existing = await _licencaService.GetLicencaByIdAsync(id);
            if (existing == null)
                return NotFound();

            var updatedEntity = _mapper.Map(dto, existing);
            var updatedLicenca = await _licencaService.UpdateLicencaAsync(id, updatedEntity);
            var response = _mapper.Map<LicencaResponseDTO>(updatedLicenca);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleted = await _licencaService.DeleteLicencaAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<LicencaResponseDTO>> Create([FromBody] LicencaRequestDTO dto)
        {
            var entity = _mapper.Map<Licenca>(dto);

            var created = await _licencaService.CreateLicencaAsync(entity); 

            var response = _mapper.Map<LicencaResponseDTO>(created); 

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
    }
}
