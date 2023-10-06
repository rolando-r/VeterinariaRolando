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

public class TratamientoMedicoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
    {
        var tratamientomedicos = await _unitOfWork.TratamientoMedicos.GetAll();
        return _mapper.Map<List<TratamientoMedicoDto>>(tratamientomedicos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TratamientoMedicoDto>>> Get11([FromQuery] Params tratamientomedicoParams)
    {
        var tratamientomedico = await _unitOfWork.TratamientoMedicos.GetAllAsync(tratamientomedicoParams.PageIndex,tratamientomedicoParams.PageSize,tratamientomedicoParams.Search);
        var lstTratamientoMedicosDto = _mapper.Map<List<TratamientoMedicoDto>>(tratamientomedico.registros);
        return new Pager<TratamientoMedicoDto>(lstTratamientoMedicosDto,tratamientomedico.totalRegistros,tratamientomedicoParams.PageIndex,tratamientomedicoParams.PageSize,tratamientomedicoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TratamientoMedicoDto>> Get(int id)
    {
        var tratamientomedico = await _unitOfWork.TratamientoMedicos.GetById(id);
        if (tratamientomedico == null){
            return NotFound();
        }
        return _mapper.Map<TratamientoMedicoDto>(tratamientomedico);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedico>> Post(TratamientoMedicoDto tratamientomedicoDto){
        var tratamientomedico = _mapper.Map<TratamientoMedico>(tratamientomedicoDto);
        this._unitOfWork.TratamientoMedicos.Add(tratamientomedico);
        await _unitOfWork.SaveAsync();
        if (tratamientomedico == null)
        {
            return BadRequest();
        }
        tratamientomedicoDto.Id = tratamientomedico.Id;
        return CreatedAtAction(nameof(Post),new {id= tratamientomedicoDto.Id}, tratamientomedicoDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]TratamientoMedicoDto TratamientoMedicoDto)
    {
        if(TratamientoMedicoDto == null) return BadRequest();
        TratamientoMedico TratamientoMedico =  await _unitOfWork.TratamientoMedicos.GetById(id);
        _mapper.Map(TratamientoMedicoDto,TratamientoMedico);
        _unitOfWork.TratamientoMedicos.Update(TratamientoMedico);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tratamientomedico = await _unitOfWork.TratamientoMedicos.GetById(id);
        if(tratamientomedico == null){
            return NotFound();
        }
        _unitOfWork.TratamientoMedicos.Remove(tratamientomedico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}