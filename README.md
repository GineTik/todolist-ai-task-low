# To-Do API

A simple To-Do API built with ASP.NET Core 9.0, Entity Framework Core, and MySQL, following the principles of Clean Architecture.

## Prerequisites

- .NET SDK 9.0 or later is required.
- MySQL database instance.
- Ensure you have a valid connection string configured in the appsettings.json file.

## Setup Instructions
1. Update the Database
    
    After cloning the repository and configuring the database connection string:
    - Open the terminal in the root directory of the project.
    - Run the following commands to apply migrations and update the database:

      For VS 2022:
      ```
      Update-Database
      ```
      For console:
  
      Open the terminal in the root directory of the project.
      Run the following command to apply migrations:
      Make sure you have the dotnet-ef tool if you don't have it: https://learn.microsoft.com/en-us/ef/core/cli/dotnet.
  
      ```
      dotnet ef database update --startup-project Todolist.Presentation --project Todolist.Application
      ```

3. Start the Application

    Using IDE tools or the following command to start the application:
    ```
    dotnet run
    ```
    The API will be available at: http://localhost:5000 (or another port).

4. Open the Swagger API Page

    - Once the application is running, open a web browser.
    - Navigate to: http://localhost:5000.
    - Use the Swagger UI to explore and test the API endpoints interactively.

## Project Architecture

This project follows the Clean Architecture principles to ensure:

    Separation of Concerns: Divides the codebase into distinct layers to isolate business logic, application services, and external dependencies.
    Testability: Each layer is independent, making the codebase easier to test.
    Flexibility: The architecture allows swapping out technologies (e.g., databases or frameworks) with minimal changes.

Layers in the Project

    Domain Layer:
        Contains business logic and domain entities (e.g., Todo).
        Free of dependencies on external frameworks.

    Application Layer:
        Defines use cases and service interfaces.
        Coordinates application workflows and implements logic beyond simple CRUD operations.

    Infrastructure Layer:
        Contains interfaces of repository.

    Presentation Layer:
        Exposes endpoints via controllers.
        Handles incoming HTTP requests and translates them into application use case calls.
