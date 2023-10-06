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

public class RazaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<RazaDto>>> Get()
    {
        var razas = await _unitOfWork.Razas.GetAll();
        return _mapper.Map<List<RazaDto>>(razas);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<RazaDto>>> Get11([FromQuery] Params razaParams)
    {
        var raza = await _unitOfWork.Razas.GetAllAsync(razaParams.PageIndex,razaParams.PageSize,razaParams.Search);
        var lstRazasDto = _mapper.Map<List<RazaDto>>(raza.registros);
        return new Pager<RazaDto>(lstRazasDto,raza.totalRegistros,razaParams.PageIndex,razaParams.PageSize,razaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RazaDto>> Get(int id)
    {
        var raza = await _unitOfWork.Razas.GetById(id);
        if (raza == null){
            return NotFound();
        }
        return _mapper.Map<RazaDto>(raza);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Raza>> Post(RazaDto razaDto){
        var raza = _mapper.Map<Raza>(razaDto);
        this._unitOfWork.Razas.Add(raza);
        await _unitOfWork.SaveAsync();
        if (raza == null)
        {
            return BadRequest();
        }
        razaDto.Id = raza.Id;
        return CreatedAtAction(nameof(Post),new {id= razaDto.Id}, razaDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]RazaDto RazaDto)
    {
        if(RazaDto == null) return BadRequest();
        Raza Raza =  await _unitOfWork.Razas.GetById(id);
        _mapper.Map(RazaDto,Raza);
        _unitOfWork.Razas.Update(Raza);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var raza = await _unitOfWork.Razas.GetById(id);
        if(raza == null){
            return NotFound();
        }
        _unitOfWork.Razas.Remove(raza);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}