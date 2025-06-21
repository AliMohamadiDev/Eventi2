# Eventi

Eventi is an event management web application built with **ASP.NET Core Razor Pages (.NET 6)** using **Onion Architecture**. It allows users to create, browse, register for, and manage both virtual and in-person events. The project emphasizes clean layering, separation of concerns, and maintainable architecture without modularization.

## Overview

- CRUD operations for events, categories, tags, and comments  
- Ticket pricing and discount management  
- User registration, authentication, and profile management  
- Administrative UI for event management and participant overview  
- Built as a single cohesive application using Onion Architecture

## Architecture

- **Onion Architecture** with these layers:
  - `Eventi.Domain` – domain entities, value objects, domain services  
  - `Eventi.Application` – use case handlers, DTOs, FluentValidation, AutoMapper  
  - `Eventi.Infrastructure` – EF Core DbContext, repository implementations, migrations  
  - `Eventi.Presentation` – Razor Pages UI, pages for users and admin panel

- Clean dependency injection and SOLID-based, maintainable code

## Technologies

- ASP.NET Core Razor Pages (.NET 6)  
- Entity Framework Core (Code-First)  
- SQL Server  
- FluentValidation  
- AutoMapper  
- Onion Architecture  
- Razor Pages

## Getting Started

1. Clone repository:
   ```bash
   git clone https://github.com/AliMohamadiDev/Eventi2.git
   ```

2. Navigate to solution and restore packages:
    ```
    dotnet restore
    ```

3. Apply migrations and create database:
    ```
    dotnet ef database update --project Eventi.Infrastructure
    ```

4. Run the app:
    ```
    dotnet run --project Eventi.Presentation
    ```

5. Explore in browser via displayed localhost URL
