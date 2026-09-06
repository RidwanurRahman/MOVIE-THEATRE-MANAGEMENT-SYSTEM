# Movie Theater Management System

## Overview

The **Movie Theater Management System (MTMS)** is a desktop-based application developed using **C# (.NET 10, Windows Forms)** and **Microsoft SQL Server**. The system is designed to manage the primary operations of a movie theater, including movie management, show scheduling, seat management, ticket booking, customer feedback, user management, and sales reporting.

The application implements a role-based access system with three user categories:

- Super Admin
- Admin
- Customer

Each role is provided with specific functionalities according to its responsibilities within the system.

---

## Features and Functionalities



### Default User Accounts

The database script includes the following accounts for testing purposes:

| Username | Password | Role |
|---|---|---|
| `SA001` | `1234` | SuperAdmin |
| `A001` | `1234` | Admin |
| `C001` | `1234` | Customer |



## System Workflow


The Movie Theater Management System is a Windows desktop application built with C# and WinForms, backed by a SQL Server database, that automates the core operations of running a movie theater through three distinct, role-based logins. When the app launches, users are greeted with a login screen where existing accounts sign in with a username and password, while new customers can self-register directly from the same screen; based on the role stored against the account, the system then routes the user to one of three dashboards.

The **Super Admin** has the highest level of control, with access to a Manage Users module for viewing, creating, editing, and removing user accounts along with their assigned roles, and a Sales Report module that compiles ticket sales data into a report which can be generated on screen and printed for record-keeping. The **Admin** is responsible for the theater's content and scheduling: they can add, update, or remove movies from the catalog (capturing details like title, genre, duration, release date, language, age rating, and poster), create and manage show timings for those movies (assigning a date, time, hall number, ticket price, and total seat count), and configure the individual seats for each show, including seat number, seat type, and availability status.

The **Customer** side of the system focuses on the movie-going experience: customers can browse available shows, select seats, and book tickets, with the total price calculated automatically based on the seats chosen; after watching a movie, they can also leave feedback in the form of a rating and comment. Underneath all three roles, a single centralized data-access layer handles every database read and write through raw SQL queries, ensuring consistent interaction with the underlying SQL Server database, while logout functionality on each dashboard returns the user cleanly back to the login screen.
