# Veterinaria 🐶 3 Layers

🚀 **Welcome to this project where we will use the following folders: `Api`, `Core`, and `Infrastructure` folders.**

## 🎯 Objective

The main objective of the software development project is the creation of an administration system for a veterinary clinic. This system will allow veterinary administrators and staff to efficiently and effectively manage all activities related to pet care and client management.

## Consultations✅

  ### Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

  ```csharp
  [HttpGet("Reporte")]
  ```
  ### Listar los medicamentos que pertenezcan a el laboratorio Genfar.

  ```csharp
  string Path = "d:/User/Downloads/report.pdf";
  ```
  ### Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

  ```csharp
  using var writer = new PdfWriter(Path);
  ```
  ### Listar los propietarios y sus mascotas.

  ```csharp
  using var pdf = new PdfDocument(writer);
  ```
  ### Listar los medicamentos que tenga un precio de venta mayor a 50000
  ```csharp
  var document = new Document(pdf);
  ```
  ### Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023

  ```csharp
  document.Add(new Paragraph("People Report").SetFontSize(14));
  ```

## Notes📝
In some controllers the authorization was commented.
  ```csharp
  [Authorize(Roles = "Administrador")]
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
