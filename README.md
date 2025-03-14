# Shoe Store Backend

Welcome to the **Shoe Store** backend repository! This project is built using **ASP.NET Core** and serves as the backend for an e-commerce platform dedicated to selling shoes. It provides a RESTful API for managing products, orders, authentication, and more.

## Features

- **User Authentication & Authorization** (JWT-based authentication with Identity)
- **Product Management** (CRUD operations for shoes, sizes, and inventory)
- **Order Management** (Cart, checkout, and payment integration with Stripe)
- **Secure Payments** (Integration with Tap Payments & Stripe API)
- **Logging & Monitoring** (Using Serilog for structured logging)
- **Database Migrations** (Automatic application of migrations using Entity Framework Core)
- **Middleware for Exception Handling & Custom Request Processing**
- **CORS Support** (Allowing cross-origin requests)

## Tech Stack

- **Backend Framework:** ASP.NET Core
- **Database:** SQL Server (via Entity Framework Core)
- **Authentication:** JWT (JSON Web Tokens) with Identity
- **Logging:** Serilog (Console & File logging)
- **API Documentation:** Swagger (OpenAPI)
- **Validation:** FluentValidation
- **Object Mapping:** AutoMapper
- **Dependency Injection:** Built-in DI with modular service registration
- **Payment Integration:** Stripe & Tap Payments

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/) (Optional, for API testing)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/shoe-store-backend.git
   cd shoe-store-backend
   ```
2. Configure the `appsettings.json` file with your database connection string, JWT settings, and payment API keys.
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Apply database migrations:
   ```sh
   dotnet ef database update
   ```

### Running the Application

To start the application, run:
```sh
 dotnet run
```
The API will be available at `https://localhost:5001/` or `http://localhost:5000/`.

## API Documentation

Swagger UI is enabled for API documentation and testing. Once the application is running, access it at:
```
http://localhost:5000/swagger
```

## Deployment

To publish the project:
```sh
 dotnet publish -c Release -o ./publish
```

## Related Repositories

- **Frontend Repository:** [Shoe Store Frontend](https://github.com/your-username/shoe-store-frontend)

## Contributing

Contributions are welcome! Feel free to fork the repo, create a branch, and submit a pull request.

## License

This project is licensed under the MIT License.
