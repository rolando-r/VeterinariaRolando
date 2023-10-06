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

public class EspecieController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<EspecieDto>>> Get()
    {
        var especies = await _unitOfWork.Especies.GetAll();
        return _mapper.Map<List<EspecieDto>>(especies);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EspecieDto>>> Get11([FromQuery] Params especieParams)
    {
        var especie = await _unitOfWork.Especies.GetAllAsync(especieParams.PageIndex,especieParams.PageSize,especieParams.Search);
        var lstEspeciesDto = _mapper.Map<List<EspecieDto>>(especie.registros);
        return new Pager<EspecieDto>(lstEspeciesDto,especie.totalRegistros,especieParams.PageIndex,especieParams.PageSize,especieParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Get(int id)
    {
        var especie = await _unitOfWork.Especies.GetById(id);
        if (especie == null){
            return NotFound();
        }
        return _mapper.Map<EspecieDto>(especie);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especie>> Post(EspecieDto especieDto){
        var especie = _mapper.Map<Especie>(especieDto);
        this._unitOfWork.Especies.Add(especie);
        await _unitOfWork.SaveAsync();
        if (especie == null)
        {
            return BadRequest();
        }
        especieDto.Id = especie.Id;
        return CreatedAtAction(nameof(Post),new {id= especieDto.Id}, especieDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]EspecieDto EspecieDto)
    {
        if(EspecieDto == null) return BadRequest();
        Especie Especie =  await _unitOfWork.Especies.GetById(id);
        _mapper.Map(EspecieDto,Especie);
        _unitOfWork.Especies.Update(Especie);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var especie = await _unitOfWork.Especies.GetById(id);
        if(especie == null){
            return NotFound();
        }
        _unitOfWork.Especies.Remove(especie);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}