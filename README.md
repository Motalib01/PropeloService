#PropeloService
PropeloService is a backend project built using ASP.NET Core Web API, Entity Framework, and SQL Server. This application is designed to handle real estate data, managing properties, apartments, promoters, and related entities. It follows the repository pattern for data management and separation of concerns.

#Features
ASP.NET Core Web API: The backend framework for creating RESTful services.
Entity Framework Core: ORM (Object-Relational Mapping) to interact with the SQL Server database.
Repository Pattern: Applied to abstract data access, making the application easier to maintain and extend.
SQL Server: Used as the primary relational database.
Domain Structure: Includes Promoters, Properties, Apartments, Pictures, Documents, and more.
Architecture Overview
This project uses the repository pattern to keep the data access layer separate from the business logic. Below is an overview of the domain structure based on the class diagram:

#Key Entities
User: Stores information for login credentials (Username, Password).
Promoter: Represents a real estate promoter with details such as name, contact information, and a profile picture.
Property: Stores information about properties like geographical location, construction dates, and the number of apartments.
Apartment: Defines individual apartments under properties, including rooms, surface area, and descriptions.
Areas: Contains information on apartment areas like surface size and room details.
Document: Manages the documents related to apartments or properties, with references to files.
Picture: Stores pictures associated with Promoters, Properties, and Apartments.
Settings: Holds application-wide settings such as the name and logo of the system.
Relationships
Promoter and User: One-to-one relationship.
Property and Promoter: One-to-one relationship.
Property and Apartment: One-to-many relationship.
Apartment and Picture: One-to-many relationship.
Apartment and Document: One-to-many relationship.
#Project Structure
Controllers: Handle HTTP requests and route them to the services or repositories.
Services: Business logic and orchestration of different operations.
Repositories: Data access layer, using Entity Framework to interact with the database.
Models: Entity models that represent the database tables.
DTOs: Data Transfer Objects used to encapsulate the data transferred between the client and the server.
#Database Schema
The following are the main tables created in the SQL Server database:

Users
Promoters
Properties
Apartments
Areas
Pictures
Documents
Settings
Technologies
ASP.NET Core Web API
Entity Framework Core
SQL Server
Repository Pattern
AutoMapper (for mapping DTOs and models)
Dependency Injection (for services and repositories)
# propelo class diagram
![propelo_class diagram](https://github.com/user-attachments/assets/eebc42aa-9ac6-49cf-9df9-c854a14cd9b4)
