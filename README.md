# Movie Theater Management System

## Case study


---

Booking a movie ticket in Bangladesh today usually means calling a box office, standing in a release-day queue, or hoping a third-party app has bothered to list a small-town cinema at all. Independent theaters outside the two or three big chains have almost no online presence: seats go unsold on slow weekdays while sold-out shows turn away walk-ins who had no way to check availability. Movie-goers who want to plan ahead — compare showtimes, read reviews, or grab a discounted weekday ticket — have no single place to do it. The Movie Theater Management System fixes this by acting as the digital middleman between theater owners and movie-goers, the way Pathao connects riders with drivers.

The platform has three actors. The **Customer** searches for a film, sees which theaters are screening it and when, books seats, pays online, and later checks booking history or leaves a rating. The **Admin (Theater Owner)** runs a real cinema hall, lists showtimes, tracks remaining seats, sees earnings, and runs discount offers to fill empty seats. The **Super Admin** is the platform operator: it approves new theater owners, watches for consistently poorly-rated theaters, moderates abusive reviews, and sees platform-wide revenue and commission.

A few connected entities make up this world. A **Theater** is a physical cinema owned by an Admin. A **Show** is one scheduled screening — one movie, one screen, one date/time — with its own title, genre, price and seat count, so a packed midnight release and a quiet matinee of the same film are tracked separately. A **Cart** holds shows a customer is considering; checking out creates an **Order**, and since one order can hold tickets to several shows, an **OrderItems** table records exactly how many seats and at what price were bought. A **Review** ties a rating and comment to a show, and an **Offer** is a time-boxed discount an owner attaches to a show.

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
