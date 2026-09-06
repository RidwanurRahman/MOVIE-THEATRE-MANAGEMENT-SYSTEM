# Movie Theater Management System

## Overview

The **Movie Theater Management System (MTMS)** is a desktop-based application developed using **C# (.NET 10, Windows Forms)** and **Microsoft SQL Server**. The system is designed to manage the primary operations of a movie theater, including movie management, show scheduling, seat management, ticket booking, customer feedback, user management, and sales reporting.

The application implements a role-based access system with three user categories:

- Super Admin
- Admin
- Customer

Each role is provided with specific functionalities according to its responsibilities within the system.

---

## Features

### Authentication

- User login using username and password
- Password visibility control
- Customer self-registration
- Role-based access and dashboard navigation
- Separate access privileges for Super Admin, Admin, and Customer users

### Super Admin Dashboard

The Super Admin has access to system-level management functionalities.

#### User Management

- View registered users
- Add new users
- Update existing user information
- Remove users
- Manage user roles

#### Sales Reporting

- Generate ticket sales reports
- View detailed sales information
- Print sales reports
- Access additional details for individual sales records

### Admin Dashboard

The Admin is responsible for managing movies, shows, and seats.

#### Movie Management

- Add new movies
- Update existing movie information
- Remove movies
- Manage movie title, genre, duration, release date, language, rating, poster, and status

#### Show Management

- Schedule movie shows
- Assign show dates and times
- Specify hall numbers
- Set ticket prices
- Manage total and available seats

#### Seat Management

- Configure seats for individual shows
- Assign seat numbers
- Define seat types
- Manage seat availability status

### Customer Dashboard

Customers can access the following functionalities:

#### Ticket Booking

- Browse available movie shows
- Select available seats
- Book movie tickets
- Automatically calculate ticket prices

#### Customer Feedback

- Provide movie ratings
- Submit comments and feedback for movies

---

## Technology Stack

| Component | Technology |
|---|---|
| User Interface | Windows Forms |
| Framework | .NET 10 |
| Programming Language | C# |
| Target Framework | `net10.0-windows` |
| Database | Microsoft SQL Server |
| Database Edition | SQL Server Express |
| Data Access | ADO.NET |
| SQL Library | `System.Data.SqlClient` |

---

## Project Structure

```text
Movie Theater Management System/
├── Movie Theater Management System/
│   ├── Program.cs
│   ├── DataAccess.cs
│   ├── Login.cs
│   ├── Register.cs
│   ├── SuperAdminDashboard.cs
│   ├── Admin Panel.cs
│   ├── CustomerDashboard.cs
│   ├── ManageUsers.cs
│   ├── ManageMovies.cs
│   ├── Manage Shows.cs
│   ├── Manage Seat.cs
│   ├── Booking Ticket.cs
│   ├── Feedback.cs
│   ├── SalesReport.cs
│   └── Movie Theater Management System.csproj
├── Images/
├── MTMS (1).sql
└── Movie Theater Management System.slnx
```

### Main Components

| File | Description |
|---|---|
| `Program.cs` | Application entry point |
| `DataAccess.cs` | Centralized database access layer |
| `Login.cs` | User authentication interface |
| `Register.cs` | Customer registration interface |
| `SuperAdminDashboard.cs` | Super Admin dashboard |
| `Admin Panel.cs` | Admin dashboard |
| `CustomerDashboard.cs` | Customer dashboard |
| `ManageUsers.cs` | User management functionality |
| `ManageMovies.cs` | Movie management functionality |
| `Manage Shows.cs` | Show scheduling functionality |
| `Manage Seat.cs` | Seat management functionality |
| `Booking Ticket.cs` | Ticket booking functionality |
| `Feedback.cs` | Customer feedback functionality |
| `SalesReport.cs` | Sales report generation and printing |

---

## Database

The application uses a Microsoft SQL Server database named **`MTMS`**. The database structure and initial data are provided in the `MTMS (1).sql` script.

### Database Tables

| Table | Description |
|---|---|
| `User` | Stores user credentials and assigned roles |
| `ManageMovies` | Stores movie information |
| `ManageShows` | Stores scheduled movie shows |
| `ManageSeat` | Stores seat information and availability |
| `BookingTicket` | Stores customer ticket bookings |
| `AudienceFeedback` | Stores customer ratings and comments |

### Default User Accounts

The database script includes the following accounts for testing purposes:

| Username | Password | Role |
|---|---|---|
| `SA001` | `1234` | SuperAdmin |
| `A001` | `1234` | Admin |
| `C001` | `1234` | Customer |

These credentials are intended for development and testing purposes.

---

## Installation and Setup

### Prerequisites

Before running the application, ensure that the following software is installed:

- Visual Studio 2022 or later
- .NET 10 SDK
- .NET Desktop Development workload
- Microsoft SQL Server or SQL Server Express
- SQL Server Management Studio or another compatible SQL management tool

### Step 1: Configure the Database

1. Open SQL Server Management Studio.
2. Open the `MTMS (1).sql` script included in the repository.
3. Execute the script.
4. The script will create the `MTMS` database.
5. The required database tables will be created automatically.
6. The default testing accounts will also be inserted.

### Step 2: Configure the Connection String

The application is configured to use the following connection string by default:

```csharp
Data Source=.\SQLEXPRESS;Initial Catalog=MTMS;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=30
```

The connection string is configured in `DataAccess.cs`.

If the SQL Server instance name differs from `SQLEXPRESS`, modify the connection string accordingly.

For environments using SQL Server authentication instead of Windows authentication, the connection string must also be updated with the appropriate authentication credentials.

### Step 3: Run the Application

1. Open `Movie Theater Management System.slnx` in Visual Studio.
2. Restore the required NuGet packages.
3. Verify that the SQL Server database is running and accessible.
4. Build the solution.
5. Run the application using Visual Studio.
6. Log in using one of the default testing accounts or register a new Customer account.

---

## System Workflow

The system provides different functionalities according to the user's assigned role.

### Super Admin

The Super Admin can manage system users and generate sales reports.

### Admin

The Admin can manage movies, schedule shows, and configure seats.

### Customer

The Customer can browse available shows, book tickets, and provide movie feedback.

---

## Data Access Architecture

The application uses a centralized `DataAccess` class for database operations.

The system uses raw SQL queries through ADO.NET and provides separate methods for different types of database operations:

- `ExecuteQuery` for retrieving data
- `ExecuteDML` for `INSERT`, `UPDATE`, and `DELETE` operations

This approach centralizes database communication within the application.

---


## License

No open-source license has currently been specified for this project.

If this project is intended to be distributed or made publicly available as an open-source project, an appropriate `LICENSE` file should be added to the repository.
