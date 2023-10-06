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

public class TipoMovimientoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoMovimientoDto>>> Get()
    {
        var tipomovimientos = await _unitOfWork.TipoMovimientos.GetAll();
        return _mapper.Map<List<TipoMovimientoDto>>(tipomovimientos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoMovimientoDto>>> Get11([FromQuery] Params tipomovimientoParams)
    {
        var tipomovimiento = await _unitOfWork.TipoMovimientos.GetAllAsync(tipomovimientoParams.PageIndex,tipomovimientoParams.PageSize,tipomovimientoParams.Search);
        var lstTipoMovimientosDto = _mapper.Map<List<TipoMovimientoDto>>(tipomovimiento.registros);
        return new Pager<TipoMovimientoDto>(lstTipoMovimientosDto,tipomovimiento.totalRegistros,tipomovimientoParams.PageIndex,tipomovimientoParams.PageSize,tipomovimientoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoDto>> Get(int id)
    {
        var tipomovimiento = await _unitOfWork.TipoMovimientos.GetById(id);
        if (tipomovimiento == null){
            return NotFound();
        }
        return _mapper.Map<TipoMovimientoDto>(tipomovimiento);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimiento>> Post(TipoMovimientoDto tipomovimientoDto){
        var tipomovimiento = _mapper.Map<TipoMovimiento>(tipomovimientoDto);
        this._unitOfWork.TipoMovimientos.Add(tipomovimiento);
        await _unitOfWork.SaveAsync();
        if (tipomovimiento == null)
        {
            return BadRequest();
        }
        tipomovimientoDto.Id = tipomovimiento.Id;
        return CreatedAtAction(nameof(Post),new {id= tipomovimientoDto.Id}, tipomovimientoDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]TipoMovimientoDto TipoMovimientoDto)
    {
        if(TipoMovimientoDto == null) return BadRequest();
        TipoMovimiento TipoMovimiento =  await _unitOfWork.TipoMovimientos.GetById(id);
        _mapper.Map(TipoMovimientoDto,TipoMovimiento);
        _unitOfWork.TipoMovimientos.Update(TipoMovimiento);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tipomovimiento = await _unitOfWork.TipoMovimientos.GetById(id);
        if(tipomovimiento == null){
            return NotFound();
        }
        _unitOfWork.TipoMovimientos.Remove(tipomovimiento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}