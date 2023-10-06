# Veterinaria 🐶 3 Layers

🚀 **Welcome to this project where we will use the following folders: `Api`, `Core`, and `Infrastructure` folders.**

## 🎯 Objective

The main objective of the software development project is the creation of an administration system for a veterinary clinic. This system will allow veterinary administrators and staff to efficiently and effectively manage all activities related to pet care and client management.

## Consultations✅

  ### Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

  endpoint: localhost:5000/api/Veterinarios/GetVeterinariosCirujanosVascular
  

  ```csharp
    //Repository..
      public Task<dynamic> GetVeterinariosCirujanosVascular()
            {
                throw new NotImplementedException();
            }
    //Controller..
      [HttpGet("GetVeterinariosCirujanosVascular")]
      //[Authorize(Roles="")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]

      public async Task<ActionResult<IEnumerable<VeterinarioDto>>> GetVeterinariosCirujanosVascular()
      {
          IEnumerable<Veterinario> Veterinarios = await _unitOfWork.Veterinarios.GetVeterinariosCirujanosVascular();
          IEnumerable<ProveedorDto>  veterinariosDto = _mapper.Map<IEnumerable<ProveedorDto>>(Veterinarios);
          return Ok(veterinariosDto);
      }
    //Interface..
        Task<dynamic> GetVeterinariosCirujanosVascular();
  ```
  ### Listar los medicamentos que pertenezcan a el laboratorio Genfar.

  endpoint: localhost:5000/api/Medicamentos/GetMedicamentosLaboratorioGenfar

  ```csharp
    //Repository..
      public Task<dynamic> GetMedicamentosLaboratorioGenfar()
        {
            throw new NotImplementedException();
        }
    //Controller..
      [HttpGet("GetMedicamentosLaboratorioGenfar")]
      //[Authorize(Roles="")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentosLaboratorioGenfar()
      {
          IEnumerable<Medicamento> Medicamentos = await _unitOfWork.Medicamentos.GetMedicamentosLaboratorioGenfar();
          IEnumerable<MedicamentoDto>  medicamentosDto = (IEnumerable<MedicamentoDto>)_mapper.Map<IEnumerable<ProveedorDto>>(Medicamentos);
          return Ok(medicamentosDto);
      }
    //Interface..
      Task<dynamic> GetMedicamentosLaboratorioGenfar();
  ```
  ### Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

  endpoint: localhost:5000/api/Mascotas/GetMascotasFelinas

  ```csharp
    //Repository..
      public Task<dynamic> GetMascotasFelinas()
        {
            throw new NotImplementedException();
        }
    //Controller..
      [HttpGet("GetMascotasFelinas")]
      //[Authorize(Roles="")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]

      public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotasFelinas()
      {
          IEnumerable<Mascota> Mascotas = await _unitOfWork.Mascotas.GetMascotasFelinas();
          IEnumerable<MascotaDto>  mascotasDto = _mapper.Map<IEnumerable<MascotaDto>>(Mascotas);
          return Ok(mascotasDto);
      }
    //Interface..
      Task<dynamic> GetMascotasFelinas();
  ```
  ### Listar los propietarios y sus mascotas.

  endpoint: localhost:5000/api/Propietarios/GetPropietariosYMascotas

  ```csharp
    //Repository..
      public Task<dynamic> GetPropietariosYMascotas()
            {
                throw new NotImplementedException();
            }
    //Controller..
      [HttpGet("GetPropietariosYMascotas")]
      //[Authorize(Roles="")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]

      public async Task<ActionResult<IEnumerable<PropietarioxMascotaDto>>> GetPropietariosYMascotas()
      {
          IEnumerable<Mascota> Propietarios = await _unitOfWork.Propietarios.GetPropietariosYMascotas();
          IEnumerable<PropietarioxMascotaDto>  mascotasDto = _mapper.Map<IEnumerable<PropietarioxMascotaDto>>(Propietarios);
          return Ok(mascotasDto);
      }
    //Interface..
        Task<dynamic> GetPropietariosYMascotas();
  ```
  ### Listar los medicamentos que tenga un precio de venta mayor a 50000

  endpoint: localhost:5000/api/Medicamentos/GetMedicamentos5000
  
  ```csharp
    //Repository..
      public Task<dynamic> GetMedicamentos5000()
        {
            throw new NotImplementedException();
        }
    //Controller..
      [HttpGet("GetMedicamentos5000")]
      //[Authorize(Roles="")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentos5000()
      {
          IEnumerable<Medicamento> Medicamentos = await _unitOfWork.Medicamentos.GetMedicamentos5000();
          IEnumerable<MedicamentoDto>  medicamentosDto = (IEnumerable<MedicamentoDto>)_mapper.Map<IEnumerable<ProveedorDto>>(Medicamentos);
          return Ok(medicamentosDto);
      }
    //Interface..
      Task<dynamic> GetMedicamentos5000();
  ```
  ### Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023

  endpoint: localhost:5000/api/Mascotas/GetMascotasVacunacionPrimerTrimestre2023

  ```csharp
    //Repository..
      public Task<dynamic> GetMascotasVacunacionPrimerTrimestre2023()
        {
            throw new NotImplementedException();
        }
    //Controller..
      [HttpGet("GetMascotasVacunacionPrimerTrimestre2023")]
      //[Authorize(Roles="")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]

      public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotasVacunacionPrimerTrimestre2023()
      {
          IEnumerable<Mascota> Mascotas = await _unitOfWork.Mascotas.GetMascotasVacunacionPrimerTrimestre2023();
          IEnumerable<MascotaDto>  mascotasDto = _mapper.Map<IEnumerable<MascotaDto>>(Mascotas);
          return Ok(mascotasDto);
      }
    //Interface..
      Task<dynamic> GetMascotasVacunacionPrimerTrimestre2023();
  ```

## Notes📝
In some controllers the authorization was commented.
  ```csharp
  [Authorize(Roles = "Administrador")]
  ```

Modified User:
  ```csharp
  public string Username { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  ```

## 📂 Folder Structure

- **Api:** This folder contains your Web API entry point, controllers, and routing configurations.

- **Core:** This folder contains the entities and interfaces.

- **Infrastructure:** In this folder you will find the persistence layer, where you will define your database contexts, repositories and migration configurations.


## 🛠 Skills

C#, .NETCore, JWT

## 📖 How to Use This Guide
1. Start by cloning this repository to your local machine.
2. Explore each of the Api, Core and Infrastructure folders to see how the files and classes are organized.
3. Follow the instructions within each folder to build and connect the necessary components in each layer.
4. Use the provided references and examples as a starting point for your own application.
5. Experiment and customize the structure according to your specific needs and requirements.

## 📚 Additional Resources

- [Official ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [Architectural Patterns for .NET Applications](https://docs.microsoft.com/dotnet/architecture/)
- [Best Practices Guide for ASP.NET Core](https://dotnet.microsoft.com/learn/web/aspnet-best-practices)
- [ASP.NET Core Web API Development Tutorial](https://docs.microsoft.com/aspnet/core/tutorials/first-web-api)

## ✍️ Authors

- [@rolando-r](https://www.github.com/rolando-r)

## 🆘 Support

For support, email roolandoor@gmail.com or join our Slack channel.

## 🔗 Links
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/rolando-rodriguez-garcia)
