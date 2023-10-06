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

public class PropietarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
    {
        var propietarios = await _unitOfWork.Propietarios.GetAll();
        return _mapper.Map<List<PropietarioDto>>(propietarios);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PropietarioDto>>> Get11([FromQuery] Params propietarioParams)
    {
        var propietario = await _unitOfWork.Propietarios.GetAllAsync(propietarioParams.PageIndex,propietarioParams.PageSize,propietarioParams.Search);
        var lstPropietariosDto = _mapper.Map<List<PropietarioDto>>(propietario.registros);
        return new Pager<PropietarioDto>(lstPropietariosDto,propietario.totalRegistros,propietarioParams.PageIndex,propietarioParams.PageSize,propietarioParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Get(int id)
    {
        var propietario = await _unitOfWork.Propietarios.GetById(id);
        if (propietario == null){
            return NotFound();
        }
        return _mapper.Map<PropietarioDto>(propietario);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Propietario>> Post(PropietarioDto propietarioDto){
        var propietario = _mapper.Map<Propietario>(propietarioDto);
        this._unitOfWork.Propietarios.Add(propietario);
        await _unitOfWork.SaveAsync();
        if (propietario == null)
        {
            return BadRequest();
        }
        propietarioDto.Id = propietario.Id;
        return CreatedAtAction(nameof(Post),new {id= propietarioDto.Id}, propietarioDto);
    }
    [HttpGet("GetPropietariosYMascotas")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PropietarioxMascotaDto>>> GetPropietariosYMascotas()
    {
        IEnumerable<Mascota> Propietarios = await _unitOfWork.Propietarios.GetPropietariosYMascotas();
        IEnumerable<PropietarioxMascotaDto>  mascotasDto = _mapper.Map<IEnumerable<PropietarioxMascotaDto>>(Propietarios);
        return Ok(mascotasDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]PropietarioDto PropietarioDto)
    {
        if(PropietarioDto == null) return BadRequest();
        Propietario Propietario =  await _unitOfWork.Propietarios.GetById(id);
        _mapper.Map(PropietarioDto,Propietario);
        _unitOfWork.Propietarios.Update(Propietario);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var propietario = await _unitOfWork.Propietarios.GetById(id);
        if(propietario == null){
            return NotFound();
        }
        _unitOfWork.Propietarios.Remove(propietario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}