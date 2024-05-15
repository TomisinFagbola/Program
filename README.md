# PROGRAM API
**UPDATE: all projects in this soluction are in .NET 8. **

Clean Architecture with Repository Pattern using Azure Cosmos DB was used for this project

This solution provides a starting point to build a web API to work with Azure Cosmos DB using **.NET 8** and Azure Cosmos DB .NET V3, based on Clean Architecture and repository design pattern. 
* Partition key is also implemented through the repository pattern in order to support large scale Cosmos DB.
* A RESTful API application is created with popular architecture features (see full list below).

This project uses the newer Cosmos DB .NET SDK V3, because it adds support for stream APIs and Cosmos DB Change Feed processor APIs, as well as performance improvements.

Please provide your accountkey and accountendpoint in appsettings.json for Azure Cosmos DB

**(NEW) Endpoints Available**
* Get CustomQuestion by CustomType which is passed as a query string (GET Method)
* Create CustomQuestion (POST Method)
* Create Application in which the CreateApplicationDto contains PersonalInformationDto model and AdditionalQuestionDto model (POST Method)
* Update Question after the Application has been submitted using the UpdateAplicationDto


# Getting Started - API
1. Download the Azure CosmosDB emulator in order to run the API project locally. Here is a download link: https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator-release-notes#download.
2. Start the emulator
3. Set the API project as your Startup project in Visual Studio
4. The swagger UI page should be loaded at: https://localhost:5001/swagger/index.html
5. Running the API project will ensure Cosmos DB containers are created when the repository manager is called


# Features supported
* ASP.NET CORE 8
* Azure Cosmos DB .NET SDK V3
* Repository Design Pattern
* Horizontal Partitioning
* Lazy Initialization Pattern
* Guard Clause Pattern
* Partition Key Design
* API Versioning
* CORS
* REST API
* Swagger UI
* Serilog for structured logging
* Command Query Responsibility Segregation (CQRS) pattern using MediatR
* MediatR pipeline behaviour for exception handling 
* FluentValidation for model validation (with support for database query)
* FluentValidation to define validation rules in Swagger Schema
* AutoMapper to mapping
* Cosmos DB Database initial creation
* CRUD endpoints using Cosmos DB
* Cosmos DB point-read using partition key and ID
* Cosmos DB query with Parameterized Query
* Unit Test using xUnit and moq

