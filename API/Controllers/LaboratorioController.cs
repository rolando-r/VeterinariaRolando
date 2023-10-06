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

public class LaboratorioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<LaboratorioDto>>> Get()
    {
        var laboratorios = await _unitOfWork.Laboratorios.GetAll();
        return _mapper.Map<List<LaboratorioDto>>(laboratorios);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratorioDto>>> Get11([FromQuery] Params laboratorioParams)
    {
        var laboratorio = await _unitOfWork.Laboratorios.GetAllAsync(laboratorioParams.PageIndex,laboratorioParams.PageSize,laboratorioParams.Search);
        var lstLaboratoriosDto = _mapper.Map<List<LaboratorioDto>>(laboratorio.registros);
        return new Pager<LaboratorioDto>(lstLaboratoriosDto,laboratorio.totalRegistros,laboratorioParams.PageIndex,laboratorioParams.PageSize,laboratorioParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LaboratorioDto>> Get(int id)
    {
        var laboratorio = await _unitOfWork.Laboratorios.GetById(id);
        if (laboratorio == null){
            return NotFound();
        }
        return _mapper.Map<LaboratorioDto>(laboratorio);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratorio>> Post(LaboratorioDto laboratorioDto){
        var laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
        this._unitOfWork.Laboratorios.Add(laboratorio);
        await _unitOfWork.SaveAsync();
        if (laboratorio == null)
        {
            return BadRequest();
        }
        laboratorioDto.Id = laboratorio.Id;
        return CreatedAtAction(nameof(Post),new {id= laboratorioDto.Id}, laboratorioDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]LaboratorioDto LaboratorioDto)
    {
        if(LaboratorioDto == null) return BadRequest();
        Laboratorio Laboratorio =  await _unitOfWork.Laboratorios.GetById(id);
        _mapper.Map(LaboratorioDto,Laboratorio);
        _unitOfWork.Laboratorios.Update(Laboratorio);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var laboratorio = await _unitOfWork.Laboratorios.GetById(id);
        if(laboratorio == null){
            return NotFound();
        }
        _unitOfWork.Laboratorios.Remove(laboratorio);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}