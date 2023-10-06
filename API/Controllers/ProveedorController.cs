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

public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var provedoors = await _unitOfWork.Proveedors.GetAllAsync();
        return _mapper.Map<List<ProveedorDto>>(provedoors);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProveedorDto>>> Get11([FromQuery] Params proveedorParams)
    {
        var proveedor = await _unitOfWork.Proveedors.GetAllAsync(proveedorParams.PageIndex,proveedorParams.PageSize,proveedorParams.Search);
        var lstProveedorsDto = _mapper.Map<List<ProveedorDto>>(proveedor.registros);
        return new Pager<ProveedorDto>(lstProveedorsDto,proveedor.totalRegistros,proveedorParams.PageIndex,proveedorParams.PageSize,proveedorParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var proveedor = await _unitOfWork.Proveedors.GetById(id);
        if (proveedor == null){
            return NotFound();
        }
        return _mapper.Map<ProveedorDto>(proveedor);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Proveedor>> Post(ProveedorDto proveedorDto){
        var proveedor = _mapper.Map<Proveedor>(proveedorDto);
        this._unitOfWork.Proveedors.Add(proveedor);
        await _unitOfWork.SaveAsync();
        if (proveedor == null)
        {
            return BadRequest();
        }
        proveedorDto.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post),new {id= proveedorDto.Id}, proveedorDto);
    }
    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]ProveedorDto ProveedorDto)
    {
        if(ProveedorDto == null) return BadRequest();
        Proveedor Proveedor =  await _unitOfWork.Proveedors.GetById(id);
        _mapper.Map(ProveedorDto,Proveedor);
        _unitOfWork.Proveedors.Update(Proveedor);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var proveedor = await _unitOfWork.Proveedors.GetById(id);
        if(proveedor == null){
            return NotFound();
        }
        _unitOfWork.Proveedors.Remove(proveedor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}