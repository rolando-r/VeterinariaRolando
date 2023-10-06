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

public class MovimientoMedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> Get()
    {
        var movimientomedicamentos = await _unitOfWork.MovimientoMedicamentos.GetAllAsync();
        return _mapper.Map<List<MovimientoMedicamentoDto>>(movimientomedicamentos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovimientoMedicamentoDto>>> Get11([FromQuery] Params movimientomedicamentoParams)
    {
        var movimientomedicamento = await _unitOfWork.MovimientoMedicamentos.GetAllAsync(movimientomedicamentoParams.PageIndex,movimientomedicamentoParams.PageSize,movimientomedicamentoParams.Search);
        var lstMovimientoMedicamentosDto = _mapper.Map<List<MovimientoMedicamentoDto>>(movimientomedicamento.registros);
        return new Pager<MovimientoMedicamentoDto>(lstMovimientoMedicamentosDto,movimientomedicamento.totalRegistros,movimientomedicamentoParams.PageIndex,movimientomedicamentoParams.PageSize,movimientomedicamentoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoMedicamentoDto>> Get(int id)
    {
        var movimientomedicamento = await _unitOfWork.MovimientoMedicamentos.GetById(id);
        if (movimientomedicamento == null){
            return NotFound();
        }
        return _mapper.Map<MovimientoMedicamentoDto>(movimientomedicamento);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamento>> Post(MovimientoMedicamentoDto movimientomedicamentoDto){
        var movimientomedicamento = _mapper.Map<MovimientoMedicamento>(movimientomedicamentoDto);
        this._unitOfWork.MovimientoMedicamentos.Add(movimientomedicamento);
        await _unitOfWork.SaveAsync();
        if (movimientomedicamento == null)
        {
            return BadRequest();
        }
        movimientomedicamentoDto.Id = movimientomedicamento.Id;
        return CreatedAtAction(nameof(Post),new {id= movimientomedicamentoDto.Id}, movimientomedicamentoDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]MovimientoMedicamentoDto MovimientoMedicamentoDto)
    {
        if(MovimientoMedicamentoDto == null) return BadRequest();
        MovimientoMedicamento MovimientoMedicamento =  await _unitOfWork.MovimientoMedicamentos.GetById(id);
        _mapper.Map(MovimientoMedicamentoDto,MovimientoMedicamento);
        _unitOfWork.MovimientoMedicamentos.Update(MovimientoMedicamento);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var movimientomedicamento = await _unitOfWork.MovimientoMedicamentos.GetById(id);
        if(movimientomedicamento == null){
            return NotFound();
        }
        _unitOfWork.MovimientoMedicamentos.Remove(movimientomedicamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}