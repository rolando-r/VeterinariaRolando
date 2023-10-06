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

public class DetalleMovimientoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetalleMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<DetalleMovimientoDto>>> Get()
    {
        var detallemovimientos = await _unitOfWork.DetalleMovimientos.GetAll();
        return _mapper.Map<List<DetalleMovimientoDto>>(detallemovimientos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleMovimientoDto>>> Get11([FromQuery] Params detallemovimientoParams)
    {
        var detallemovimiento = await _unitOfWork.DetalleMovimientos.GetAllAsync(detallemovimientoParams.PageIndex,detallemovimientoParams.PageSize,detallemovimientoParams.Search);
        var lstDetalleMovimientosDto = _mapper.Map<List<DetalleMovimientoDto>>(detallemovimiento.registros);
        return new Pager<DetalleMovimientoDto>(lstDetalleMovimientosDto,detallemovimiento.totalRegistros,detallemovimientoParams.PageIndex,detallemovimientoParams.PageSize,detallemovimientoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Get(int id)
    {
        var detallemovimiento = await _unitOfWork.DetalleMovimientos.GetById(id);
        if (detallemovimiento == null){
            return NotFound();
        }
        return _mapper.Map<DetalleMovimientoDto>(detallemovimiento);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimiento>> Post(DetalleMovimientoDto detallemovimientoDto){
        var detallemovimiento = _mapper.Map<DetalleMovimiento>(detallemovimientoDto);
        this._unitOfWork.DetalleMovimientos.Add(detallemovimiento);
        await _unitOfWork.SaveAsync();
        if (detallemovimiento == null)
        {
            return BadRequest();
        }
        detallemovimientoDto.Id = detallemovimiento.Id;
        return CreatedAtAction(nameof(Post),new {id= detallemovimientoDto.Id}, detallemovimientoDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]DetalleMovimientoDto DetalleMovimientoDto)
    {
        if(DetalleMovimientoDto == null) return BadRequest();
        DetalleMovimiento DetalleMovimiento =  await _unitOfWork.DetalleMovimientos.GetById(id);
        _mapper.Map(DetalleMovimientoDto,DetalleMovimiento);
        _unitOfWork.DetalleMovimientos.Update(DetalleMovimiento);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var detallemovimiento = await _unitOfWork.DetalleMovimientos.GetById(id);
        if(detallemovimiento == null){
            return NotFound();
        }
        _unitOfWork.DetalleMovimientos.Remove(detallemovimiento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}