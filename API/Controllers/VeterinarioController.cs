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

public class VeterinarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var veterinarios = await _unitOfWork.Veterinarios.GetAll();
        return _mapper.Map<List<VeterinarioDto>>(veterinarios);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VeterinarioDto>>> Get11([FromQuery] Params veterinarioParams)
    {
        var veterinario = await _unitOfWork.Veterinarios.GetAllAsync(veterinarioParams.PageIndex,veterinarioParams.PageSize,veterinarioParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<VeterinarioDto>>(veterinario.registros);
        return new Pager<VeterinarioDto>(lstVeterinariosDto,veterinario.totalRegistros,veterinarioParams.PageIndex,veterinarioParams.PageSize,veterinarioParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Get(int id)
    {
        var veterinario = await _unitOfWork.Veterinarios.GetById(id);
        if (veterinario == null){
            return NotFound();
        }
        return _mapper.Map<VeterinarioDto>(veterinario);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Veterinario>> Post(VeterinarioDto veterinarioDto){
        var veterinario = _mapper.Map<Veterinario>(veterinarioDto);
        this._unitOfWork.Veterinarios.Add(veterinario);
        await _unitOfWork.SaveAsync();
        if (veterinario == null)
        {
            return BadRequest();
        }
        veterinarioDto.Id = veterinario.Id;
        return CreatedAtAction(nameof(Post),new {id= veterinarioDto.Id}, veterinarioDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]VeterinarioDto VeterinarioDto)
    {
        if(VeterinarioDto == null) return BadRequest();
        Veterinario Veterinario =  await _unitOfWork.Veterinarios.GetById(id);
        _mapper.Map(VeterinarioDto,Veterinario);
        _unitOfWork.Veterinarios.Update(Veterinario);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var veterinario = await _unitOfWork.Veterinarios.GetById(id);
        if(veterinario == null){
            return NotFound();
        }
        _unitOfWork.Veterinarios.Remove(veterinario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}