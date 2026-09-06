# Movie Theater Management System

## Case study

Booking a movie ticket in Bangladesh today usually means calling a theater's box office, standing in a long 
queue on release day, or hoping a third-party app has bothered to list a small-town cinema at all. Independent 
multiplexes and single-screen theaters outside the two or three big national chains have almost no online 
presence: they cannot afford their own booking website, so seats go unsold on slow weekdays while sold-out 
shows turn away walk-in customers who had no way of checking availability in advance. Meanwhile, movie
goers who do want to plan ahead — compare showtimes across theaters, read reviews before choosing a film, or 
grab a discounted weekday ticket — have no single place to do it. The Movie Theater Management System 
solves this by acting as the digital middleman between the people who own theaters and the people who want to 
watch movies in them, the same way Pathao connects riders with drivers or Daraz connects shoppers with 
sellers.
The platform has three actors. The Customer is the movie-goer who wants to search for a film, see which 
theaters are screening it and when, book a specific number of seats, pay online, and later look back at their 
booking history or leave a rating. The Admin, functioning as a Theater Owner, is the business partner: they run 
a real cinema hall or multiplex screen and use the platform to list their showtimes, track how many seats remain 
for each show, see how much they have earned, and run limited-time discount offers to fill empty seats on 
weekdays. The Super Admin is the platform's own operating company — the party that built and owns the 
software. They approve new theater owners before those owners can start selling tickets, keep an eye on theaters 
that are earning consistently poor ratings, moderate reviews that are abusive or fake, and see, across the entire 
platform, how much revenue and commission has been generated.
The world these three actors share is made of a small number of connected entities. A Theater is a physical 
cinema business, identified by its name, location, address and the Admin account that owns it. A Show is a 
single scheduled screening — one movie, on one screen, at one date and time, sold by exactly one theater; every 
show carries its own title, genre, language, ticket price, total seat count and how many seats remain, so a hugely 
popular midnight release and a quiet Tuesday matinee of the same film are tracked as two completely separate 
records. A Cart holds the shows a customer is thinking about booking before they commit to paying, an Order is 
created the moment they check out, and because one order can contain tickets to more than one show (and a 
single show is bought by many different orders), an OrderItems table sits between them recording exactly how 
many seats and at what price were bought in that transaction. A Review ties a customer's star rating and 
comment to the specific show they watched, and an Offer is a time-boxed percentage discount a theater owner 
attaches to one of their shows.
Money flows in one direction and splits in two. When a customer pays for tickets at checkout, the full ticket 
price is charged to their card or mobile wallet. The Movie Theater Management System, as the platform 
operator, retains a commission percentage from that transaction — the same way a delivery app keeps a cut of 
every food order — before crediting the remaining balance to the theater owner's earnings, which they can see 
summarized on their own sales report. The Super Admin's platform-wide dashboard simply aggregates this 
commission across every theater and every order to show the company how the whole business is performing

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
