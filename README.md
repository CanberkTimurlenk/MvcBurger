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

<br>
<hr>
<br>

![home](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/64b61916-7c9b-46b7-b11c-c820f78309f8)

<br>

![menu-pagecart-item](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/ebef3024-68f4-494a-9de5-c765e615153d)

<br>

![cart-content](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/299dd4f2-069c-4e23-88d3-942e583e4fc2)

<br>

![login](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/1745398e-f2ce-496e-86b8-f30430fa60b4)

<br>

![register](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/98626856-857e-42f4-830b-45fdbb982520)

<br>

![admin-menus](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/769843f3-853c-49c1-95f3-5e0bf55936a7)

<br>

![admin-add-update](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/be86add8-2126-4e92-97c2-3f5f59300f86)

<br>

![admin-extras](https://github.com/CanberkTimurlenk/MvcBurger/assets/18058846/959d1494-a1e4-4bc1-9bf0-7369f70a10ff)

