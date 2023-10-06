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

public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var medicamento = await _unitOfWork.Medicamentos.GetAllAsync();
        return _mapper.Map<List<MedicamentoDto>>(medicamento);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicamentoDto>>> Get11([FromQuery] Params medicamentoParams)
    {
        var medicamento = await _unitOfWork.Medicamentos.GetAllAsync(medicamentoParams.PageIndex,medicamentoParams.PageSize,medicamentoParams.Search);
        var lstMedicamentosDto = _mapper.Map<List<MedicamentoDto>>(medicamento.registros);
        return new Pager<MedicamentoDto>(lstMedicamentosDto,medicamento.totalRegistros,medicamentoParams.PageIndex,medicamentoParams.PageSize,medicamentoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var medicamento = await _unitOfWork.Medicamentos.GetById(id);
        if (medicamento == null){
            return NotFound();
        }
        return _mapper.Map<MedicamentoDto>(medicamento);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicamento>> Post(MedicamentoDto medicamentoDto){
        var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
        this._unitOfWork.Medicamentos.Add(medicamento);
        await _unitOfWork.SaveAsync();
        if (medicamento == null)
        {
            return BadRequest();
        }
        medicamentoDto.Id = medicamento.Id;
        return CreatedAtAction(nameof(Post),new {id= medicamentoDto.Id}, medicamentoDto);
    }
    [HttpGet("GetMedicamentosLaboratorioGenfar")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentosLaboratorioGenfar()
    {
        IEnumerable<Medicamento> Medicamentos = await _unitOfWork.Medicamentos.GetMedicamentosLaboratorioGenfar();
        IEnumerable<MedicamentoDto>  medicamentosDto = _mapper.Map<IEnumerable<MedicamentoDto>>(Medicamentos);
        return Ok(medicamentosDto);
    }
    [HttpGet("GetMedicamentos5000")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentos5000()
    {
        IEnumerable<Medicamento> Medicamentos = await _unitOfWork.Medicamentos.GetMedicamentos5000();
        IEnumerable<MedicamentoDto>  medicamentosDto = _mapper.Map<IEnumerable<MedicamentoDto>>(Medicamentos);
        return Ok(medicamentosDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]MedicamentoDto MedicamentoDto)
    {
        if(MedicamentoDto == null) return BadRequest();
        Medicamento Medicamento =  await _unitOfWork.Medicamentos.GetById(id);
        _mapper.Map(MedicamentoDto,Medicamento);
        _unitOfWork.Medicamentos.Update(Medicamento);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var medicamento = await _unitOfWork.Medicamentos.GetById(id);
        if(medicamento == null){
            return NotFound();
        }
        _unitOfWork.Medicamentos.Remove(medicamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}