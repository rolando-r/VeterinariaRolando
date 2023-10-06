using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class MascotaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var mascotas = await _unitOfWork.Mascotas.GetAllAsync();
        return _mapper.Map<List<MascotaDto>>(mascotas);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MascotaDto>>> Get11([FromQuery] Params mascotaParams)
    {
        var mascota = await _unitOfWork.Mascotas.GetAllAsync(mascotaParams.PageIndex,mascotaParams.PageSize,mascotaParams.Search);
        var lstMascotasDto = _mapper.Map<List<MascotaDto>>(mascota.registros);
        return new Pager<MascotaDto>(lstMascotasDto,mascota.totalRegistros,mascotaParams.PageIndex,mascotaParams.PageSize,mascotaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var mascota = await _unitOfWork.Mascotas.GetById(id);
        if (mascota == null){
            return NotFound();
        }
        return _mapper.Map<MascotaDto>(mascota);
    }

    [HttpGet("GetMascotasFelinas")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotasFelinas()
    {
        IEnumerable<Mascota> Mascotas = await _unitOfWork.Mascotas.GetMascotasFelinas();
        IEnumerable<MascotaDto>  mascotasDto = _mapper.Map<IEnumerable<MascotaDto>>(Mascotas);
        return Ok(mascotasDto);
    }
    [HttpGet("GetMascotasVacunacionPrimerTrimestre2023")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotasVacunacionPrimerTrimestre2023()
    {
        IEnumerable<Mascota> Mascotas = await _unitOfWork.Mascotas.GetMascotasVacunacionPrimerTrimestre2023();
        IEnumerable<MascotaDto>  mascotasDto = _mapper.Map<IEnumerable<MascotaDto>>(Mascotas);
        return Ok(mascotasDto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Mascota>> Post(MascotaDto mascotaDto){
        var mascota = _mapper.Map<Mascota>(mascotaDto);
        this._unitOfWork.Mascotas.Add(mascota);
        await _unitOfWork.SaveAsync();
        if (mascota == null)
        {
            return BadRequest();
        }
        mascotaDto.Id = mascota.Id;
        return CreatedAtAction(nameof(Post),new {id= mascotaDto.Id}, mascotaDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]MascotaDto MascotaDto)
    {
        if(MascotaDto == null) return BadRequest();
        Mascota Mascota =  await _unitOfWork.Mascotas.GetById(id);
        _mapper.Map(MascotaDto,Mascota);
        _unitOfWork.Mascotas.Update(Mascota);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var mascota = await _unitOfWork.Mascotas.GetById(id);
        if(mascota == null){
            return NotFound();
        }
        _unitOfWork.Mascotas.Remove(mascota);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}