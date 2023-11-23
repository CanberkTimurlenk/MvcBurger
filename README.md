# MvcBurger: Burger Shop Project with ASP.NET Core MVC

MvcBurger is an ASP.NET Core MVC-based Burger Shop project that incorporates user registration, login, cart management, and order creation with customizable add-ons. Add-ons and menus created by the Admin via provided Admin panel. The application includes an admin role, and user roles and management was integrated using ASP.NET Core Identity.

<br>

- **C#:** The project is developed using the C# programming language.

- **ASP.NET Core MVC:** MvcBurger utilizes ASP.NET Core MVC for web development, providing a robust and scalable framework.

- **CLEAN Code Techniques and SOLID Principles:** The development process adheres to CLEAN Code Techniques and SOLID Principles, promoting maintainability and readability.

<br>

## Software Design

### Onion Architecture

In contrast to a three or more layered architecture, onion architecture places the data and domain in the center rather than persistence and data access. Additionally, Each layer has its own service registrations, preventing a potential dependency tangle that could occur by the end of the day.

### Mediator Pattern & MediatR

The Mediator Pattern was integrated, promoting loose coupling between objects by providing a mediator for communication. MediatR, a .NET package, facilitates clean implementation through requests, responses, and handlers.

### CQRS Pattern

CQRS stands for the Command Query Responsibility Segregation Principle. In this architectural pattern, "commands" refer to operations that modify data, while "queries" refer to operations that retrieve data. Notably, this approach allows for the use of multiple databases. Each database can be tailored specifically to optimize relevant operations, whether they are commands or queries. It's important to emphasize that having multiple databases is not mandatory for implementing the CQRS pattern.

### Unit Of Work Pattern

The Unit of Work Pattern is utilized to group one or more operations into a single transaction, adhering to the principle of "do everything or do nothing."

### Serilog & SEQ

Serilog, a logging library, is combined with SEQ to achieve structured logging. Serilog provides diagnostic logging to various media, while SEQ offers an interface for visualizing, searching, and alerting for structured log data.

## Database

The project employs Microsoft SQL Server as the database, with Entity Framework Core serving as the Object-Relational Mapping (ORM) tool.

This comprehensive software design ensures a scalable, maintainable, and efficient Burger Shop project with a focus on clean code and robust architecture.

## Developers
Canberk TİMURLENK <br>
Batuhan Bora Alaftar
