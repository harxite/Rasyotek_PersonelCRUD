using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelManagement.Core.Entities;
using PersonelManagement.Core.Interfaces;
using PersonelManagement.DTO.Personels;

namespace PersonelManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;
        private readonly IMapper _mapper;

        public PersonelController(IPersonelService personelService, IMapper mapper)
        {
            _personelService = personelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personelList = await _personelService.GetAllPersonelWithDebitsAsync();
            return Ok(personelList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var personel = await _personelService.GetPersonelByIdWithDebitsAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return Ok(personel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonelCreateDTO personelCreateDto)
        {
            var createdPersonelDto = await _personelService.AddPersonelAsync(personelCreateDto);
            return CreatedAtAction(nameof(Get), new { id = createdPersonelDto.Id }, createdPersonelDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonelUpdateDTO personelUpdateDto)
        {
            if (id != personelUpdateDto.Id)
            {
                return BadRequest();
            }

            await _personelService.UpdatePersonelAsync(personelUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personelService.DeletePersonelAsync(id);
            return NoContent();
        }
    }
}
