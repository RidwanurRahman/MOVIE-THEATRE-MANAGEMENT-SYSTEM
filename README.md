### AMERICAN INTERNATIONAL UNIVERSITY–BANGLADESH (AIUB)

## Faculty of Science and Technology · Department of Computer Science

CSC 2210 — Object Oriented Programming 2

Project Assignment 01 — System Design & Report

# PROJECT REPORT

## MOVIE THEATER MANAGEMENT SYSTEM

| Field | Details |
| --- | --- |
| Semester | Summer 2025–2026 |
| Section | AA |
| Group No. | NONE |
| Domain | Movie Theater / Cinema Ticket Booking |
| Supervisor | DR. MD IFTEKHARUL MOBIN |

---
___

| # | Name | ID |
| --- | --- | --- |
| 1 | MUHAMMAD RIDWANUR RAHMAN | 23-55300-3 |

___
___

## Table of Contents

##  — Introduction & Case Study

Booking a movie ticket in Bangladesh today usually means calling a theater's box office, standing in a long queue on release day, or hoping a third-party app has bothered to list a small-town cinema at all. Independent multiplexes and single-screen theaters outside the two or three big national chains have almost no online presence: they cannot afford their own booking website, so seats go unsold on slow weekdays while sold-out shows turn away walk-in customers who had no way of checking availability in advance. Meanwhile, movie-goers who do want to plan ahead — compare showtimes across theaters, read reviews before choosing a film, or grab a discounted weekday ticket — have no single place to do it. The Movie Theater Management System solves this by acting as the digital middleman between the people who own theaters and the people who want to watch movies in them, the same way Pathao connects riders with drivers or Daraz connects shoppers with sellers.

The platform has three actors. The Customer is the movie-goer who wants to search for a film, see which theaters are screening it and when, book a specific number of seats, pay online, and later look back at their booking history or leave a rating. The Admin, functioning as a Theater Owner, is the business partner: they run a real cinema hall or multiplex screen and use the platform to list their showtimes, track how many seats remain for each show, see how much they have earned, and run limited-time discount offers to fill empty seats on weekdays. The Super Admin is the platform's own operating company — the party that built and owns the software. They approve new theater owners before those owners can start selling tickets, keep an eye on theaters that are earning consistently poor ratings, moderate reviews that are abusive or fake, and see, across the entire platform, how much revenue and commission has been generated.

The world these three actors share is made of a small number of connected entities. A Theater is a physical cinema business, identified by its name, location, address and the Admin account that owns it. A Show is a single scheduled screening — one movie, on one screen, at one date and time, sold by exactly one theater; every show carries its own title, genre, language, ticket price, total seat count and how many seats remain, so a hugely popular midnight release and a quiet Tuesday matinee of the same film are tracked as two completely separate records. A Cart holds the shows a customer is thinking about booking before they commit to paying, an Order is created the moment they check out, and because one order can contain tickets to more than one show (and a single show is bought by many different orders), an OrderItems table sits between them recording exactly how many seats and at what price were bought in that transaction. A Review ties a customer's star rating and comment to the specific show they watched, and an Offer is a time-boxed percentage discount a theater owner attaches to one of their shows.

Money flows in one direction and splits in two. When a customer pays for tickets at checkout, the full ticket price is charged to their card or mobile wallet. The Movie Theater Management System, as the platform operator, retains a commission percentage from that transaction — the same way a delivery app keeps a cut of every food order — before crediting the remaining balance to the theater owner's earnings, which they can see summarized on their own sales report. The Super Admin's platform-wide dashboard simply aggregates this commission across every theater and every order to show the company how the whole business is performing.

## Functional Requirements & User Stories

### Functional Requirements

### Super Admin

Approve or reject new theater owner registrations — new Admin sign-ups sit in "Pending" status until approved.

Suspend or permanently delete a theater owner, particularly one with poor customer ratings.

View the full list of Admins and Customers, with search and filter by status/role.

View a platform-wide sales dashboard showing total bookings, total revenue and commission earned per theater.

View a low-rated theaters report listing theaters whose average rating falls below a defined threshold (e.g. < 2.5).

Add, edit and delete entries in the master movie-genre/category list.

Moderate reviews by deleting abusive or fake reviews.

### Admin (Theater Owner)

Register a new theater and manage its profile (name, location, address, contact, logo).

Perform full CRUD on their own shows/screenings through a DataGridView (add, view, update, delete).

View a seat-inventory dashboard showing seats sold, seats remaining, and a low-seat alert when availability drops below a minimum threshold.

View an earnings/sales report showing who booked what, on what date and time, at what unit price, and total earnings.

Create discount offers/packages with a percentage discount, a start date and an end date.

View (read-only) reviews and ratings left on their shows — cannot delete a customer review.

Update their own password and profile information.

### Customer

Sign up for a new account / sign in to an existing account.

Browse shows/movies listed by all theaters on the platform.

Search for a show by movie name or keyword.

Filter shows using dropdowns for at least three criteria: price range, genre, location, language, or date.

View full show details and read existing reviews before booking.

Add a show to the cart, update the seat quantity, or remove it from the cart.

Check out and pay for the cart, generating a bill/invoice.

View booking history and reprint a past e-ticket/invoice.

Give a 1-5 star rating and write a review for a show they have watched.

View special packages and discount offers currently running.

Update their own profile information and password.

### User Stories

### Super Admin User Stories

As a Super Admin, I can approve or reject new theater owner registrations, so that only legitimate businesses can sell tickets on the platform.

Details: New Admin sign-ups appear in a "Pending Theater Owners" grid. The Super Admin selects a row and clicks Approve or Reject. Approving sets the owner's Status to Active in the Users table and unlocks their dashboard; rejecting sets Status to Rejected and blocks login.

As a Super Admin, I can suspend or delete a theater owner, so that theaters with a poor track record can no longer operate on the platform.

Details: From the Manage Theater Owners grid, the Super Admin clicks Suspend/Delete on a selected owner after a confirmation dialog. Suspending sets Status to Suspended (login blocked, data kept); deleting removes the row after checking for unresolved orders.

As a Super Admin, I can view all users on the platform, so that I can monitor and search the full customer and admin base.

Details: A DataGridView lists every user with name, email, role and status columns. A search box filters by name/email and a dropdown filters by UserType or Status.

As a Super Admin, I can view a platform-wide sales dashboard, so that I can track total orders, total revenue and commission earned per theater.

Details: Summary cards show total bookings, revenue and commission; a bar chart and a per-theater table are computed by joining Orders, OrderItems, Shows and Theaters, filterable by date range.

As a Super Admin, I can view a low-rated shop report, so that I can identify theaters whose service quality is falling below an acceptable standard.

Details: A GROUP BY/HAVING query averages each theater's review ratings and lists theaters with an average below 2.5, alongside review count.

As a Super Admin, I can manage the master list of movie genres, so that theater owners choose from a consistent, clean category list when creating shows.

Details: A CRUD form lets the Super Admin add, rename or delete a genre; deleting a genre still in use by a show is blocked with a validation message.

As a Super Admin, I can moderate reviews, so that abusive or fake reviews do not stay visible on the platform.

Details: A DataGridView lists all reviews; selecting one and clicking Delete Review removes it permanently. Theater owners cannot perform this action.

### Admin (Theater Owner) User Stories

As a Theater Owner, I can register my theater and manage its profile, so that customers can find and recognize my business on the platform.

Details: A form collects theater name, location, address, contact and a logo upload. Name and address cannot be empty; on Save a row is inserted into or updated in Theaters linked to the logged-in owner.

As a Theater Owner, I can add a new show, so that customers can discover and book tickets for it.

Details: Clicking Add Show opens a form for movie title, genre (dropdown), language, date, time, screen, price, total seats and a poster. Price and seats must be positive and title cannot be empty, otherwise a red error label appears and Save stays disabled. On Save, a row is inserted into Shows with the logged-in owner's TheaterId.

As a Theater Owner, I can update or delete my own shows, so that I can correct mistakes or remove screenings that are no longer running.

Details: Selecting a row in the show grid and clicking Update reopens the Add Show form pre-filled for editing; Delete asks for confirmation and is blocked if the show already has confirmed bookings.

As a Theater Owner, I can view a seat-inventory dashboard, so that I always know how many seats are sold and how many remain for each show.

Details: A grid lists every show with TotalSeats, seats sold and SeatsAvailable computed live; rows below MinSeatAlert are highlighted red with a warning banner.

As a Theater Owner, I can view an earnings and sales report, so that I know exactly how much revenue each show has generated.

Details: A date-filterable report lists each booking with customer, show, date/time, quantity, unit price and line total, with a SUM-based total at the top.

As a Theater Owner, I can create discount offers on my shows, so that I can fill empty seats on slow days.

Details: A form lets the owner pick a show, a discount percentage, a start date and an end date, validated so StartDate < EndDate and 0-100%, before inserting into Offers.

As a Theater Owner, I can view reviews and ratings left on my shows, so that I can understand customer feedback, but I cannot delete them.

Details: A read-only DataGridView lists reviewer name, rating and comment per show; no delete/edit control is present, since moderation is reserved for the Super Admin.

As a Theater Owner, I can update my own password and profile, so that I can keep my account information current and secure.

Details: A form pre-fills profile fields; changing the password requires entering it twice with a minimum-length check before the Users row is updated.

### Customer User Stories

As a Customer, I can sign up and sign in, so that I can access the platform and start booking tickets.

Details: Sign Up validates a unique email and a 6+ character password before inserting a new Users row with UserType Customer. Login checks credentials and routes to Customer Home.

As a Customer, I can browse shows from all theaters, so that I can see everything available to watch nearby.

Details: The Home screen loads all upcoming shows across every theater, pulling MovieTitle, theater name, date/time and price for each entry.

As a Customer, I can search for a show by keyword, so that I can quickly find a specific movie I already have in mind.

Details: A search box filters the show list using a LIKE query on MovieTitle as the customer types or on pressing Search.

As a Customer, I can filter shows using dropdowns, so that I can narrow results down by genre, location and price range at minimum.

Details: Three or more ComboBox dropdowns combine with AND logic in the WHERE clause; selecting All in a dropdown removes that filter.

As a Customer, I can view a show's details and read its reviews, so that I can decide whether it is worth booking before paying.

Details: The details page shows poster, theater, date/time, price and a grid of existing reviews with reviewer name and star rating.

As a Customer, I can add a show to my cart and update the seat quantity, so that I can book more than one ticket at a time.

Details: Add to Cart with a Quantity selector inserts or updates a Cart row; quantity must be positive and cannot exceed SeatsAvailable.

As a Customer, I can check out and pay for my cart, so that I receive confirmed tickets.

Details: Checkout shows cart items, total and a payment method dropdown. On Confirm Payment, one Orders row and one OrderItems row per line are inserted inside a transaction, SeatsAvailable is decremented, and a printable invoice/e-ticket is shown.

As a Customer, I can view my booking/order history, so that I can look back at what I have booked and reprint an invoice if needed.

Details: A grid lists past Orders with date, items and total; selecting a row reopens the invoice layout with a Print button.

As a Customer, I can give a rating and write a review for a show I have watched, so that I can share feedback with other movie-goers.

Details: A 1-5 star selector plus comment box is available from booking history or show details; Submit inserts a Reviews row validated by a CHECK(Rating 1-5) constraint.

As a Customer, I can view special packages and discount offers, so that I can find cheaper tickets during promotional periods.

Details: An Offers screen lists shows with an active Offer (today between StartDate and EndDate) alongside original price, discount percent and calculated discounted price.

As a Customer, I can update my own profile and password, so that I can keep my contact details accurate and my account secure.

Details: A profile form pre-fills name, phone and address; changing password requires the current password plus a new password entered twice.

##  — UI Navigation Diagram
___
**Figure 1 — UI Navigation Diagram**

![image alt](https://github.com/RidwanurRahman/MOVIE-THEATRE-MANAGEMENT-SYSTEM/blob/ebc8446f73b6d5f9616948f4f97ac793c52ef770/ui.png
)
## Database Design
___
**Figure 2 - Schema sql Diagram**
![image alt](https://github.com/RidwanurRahman/MOVIE-THEATRE-MANAGEMENT-SYSTEM/blob/ebc8446f73b6d5f9616948f4f97ac793c52ef770/schemaPPP.png)

**Figure 3 - ER Diagram**
___
![image alt](https://github.com/RidwanurRahman/MOVIE-THEATRE-MANAGEMENT-SYSTEM/blob/e3b5fddc511ea16b881caf1fc77c6f37e923eaf8/er.png)

## SQL Queries

The full script — CREATE TABLE statements, sample INSERTs, and all twelve feature queries — is committed at database/schema.sql. Each query is explained below, feature by feature.

1. LOGIN

Verifies the entered email and password against Users and returns the UserType so the Login form can route to the correct dashboard.

2-3. FILTER

Filters the show list by price range, and separately by genre plus seat availability, backing the Customer's dropdown filters.

SEARCH

Uses a LIKE pattern on MovieTitle to support keyword search from the Browse Shows screen.

CART

Adds a row to Cart, deletes a row from Cart, and computes each cart line's subtotal (Quantity x Price) for the Cart screen.

CHECKOUT

Wraps the booking in a transaction: inserts one Orders row, one OrderItems row, and decrements SeatsAvailable, so partial failures cannot leave inconsistent seat counts.

THEATER EARNINGS

Joins OrderItems, Shows and Theaters and uses SUM with GROUP BY to total revenue per theater, powering both the Admin earnings report and the Super Admin platform dashboard.

LOW SEAT ALERT

Compares SeatsAvailable against MinSeatAlert to drive the red warning banner on the Admin inventory dashboard.

REVIEWS

Joins Reviews with Users to display the reviewer's name alongside their rating and comment on the Show Details screen.

LOW-RATED THEATERS

Uses AVG with GROUP BY and HAVING to find theaters whose average rating across all their shows falls below 2.5.

SUSPEND/DELETE OWNER

Updates a theater owner's Status to Suspended (or deletes the row) from the Super Admin's Manage Theater Owners screen.

OFFERS

Joins Offers with Shows and calculates the discounted price for any offer whose date range includes today, for the Customer's Offers screen.

### Full Script Excerpt (CREATE TABLE — Shows)
___
___
### Table 1

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| UserId | INT | PK, IDENTITY | Unique user identifier |
| FullName | VARCHAR(100) | NOT NULL | User's full name |
| Email | VARCHAR(100) | NOT NULL, UNIQUE | Login email |
| Password | VARCHAR(255) | NOT NULL | Hashed password |
| Phone | VARCHAR(20) | NOT NULL | Contact number |
| Address | VARCHAR(200) |  | Mailing/city address |
| UserType | VARCHAR(20) | NOT NULL, CHECK | SuperAdmin / Admin / Customer |
| Status | VARCHAR(20) | NOT NULL, CHECK | Pending / Active / Suspended |
| CreatedAt | DATETIME | NOT NULL | Registration timestamp |

### Table 2

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| GenreId | INT | PK, IDENTITY | Unique genre identifier |
| GenreName | VARCHAR(50) | NOT NULL, UNIQUE | e.g. Action, Drama |
| Description | VARCHAR(200) |  | Short description |

### Table 3

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| TheaterId | INT | PK, IDENTITY | Unique theater identifier |
| OwnerId | INT | FK -> Users(UserId) | Owning Admin account |
| TheaterName | VARCHAR(100) | NOT NULL | Business name |
| Location | VARCHAR(100) | NOT NULL | Area/city |
| Address | VARCHAR(200) | NOT NULL | Full street address |
| Contact | VARCHAR(20) |  | Box-office phone number |
| Status | VARCHAR(20) | NOT NULL, CHECK | Pending / Active / Suspended |

### Table 4

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| ShowId | INT | PK, IDENTITY | Unique show identifier |
| TheaterId | INT | FK -> Theaters | Owning theater |
| GenreId | INT | FK -> Genres | Movie genre |
| MovieTitle | VARCHAR(150) | NOT NULL | Movie name |
| Language | VARCHAR(30) | NOT NULL | Audio language |
| ShowDate | DATE | NOT NULL | Screening date |
| ShowTime | TIME | NOT NULL | Screening time |
| ScreenNo | VARCHAR(10) | NOT NULL | Hall/screen number |
| Price | DECIMAL(10,2) | NOT NULL, CHECK>0 | Ticket price |
| TotalSeats | INT | NOT NULL, CHECK>0 | Total hall capacity |
| SeatsAvailable | INT | NOT NULL | Seats currently unsold |
| MinSeatAlert | INT | NOT NULL | Low-seat alert threshold |
| Description | VARCHAR(300) |  | Short synopsis |
| PosterPath | VARCHAR(255) |  | Poster image path |

### Table 5

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| CartId | INT | PK, IDENTITY | Unique cart-line identifier |

### Table 6

| CustomerId | INT | FK -> Users | Owning customer |
| --- | --- | --- | --- |
| ShowId | INT | FK -> Shows | Selected show |
| Quantity | INT | NOT NULL, CHECK>0 | Seats requested |
| AddedDate | DATETIME | NOT NULL | When added to cart |

### Table 7

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| OrderId | INT | PK, IDENTITY | Unique order identifier |
| CustomerId | INT | FK -> Users | Booking customer |
| OrderDate | DATETIME | NOT NULL | Checkout timestamp |
| TotalAmount | DECIMAL(10,2) | NOT NULL | Full order total |
| PaymentMethod | VARCHAR(30) | NOT NULL | Card / Mobile Banking / etc. |
| Status | VARCHAR(20) | NOT NULL, CHECK | Confirmed / Cancelled |

### Table 8

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| OrderItemId | INT | PK, IDENTITY | Unique line-item identifier |
| OrderId | INT | FK -> Orders | Parent order |
| ShowId | INT | FK -> Shows | Booked show |
| Quantity | INT | NOT NULL, CHECK>0 | Seats booked in this line |
| UnitPrice | DECIMAL(10,2) | NOT NULL | Price per seat at booking time |
| Subtotal | DECIMAL(10,2) | NOT NULL | Quantity x UnitPrice |

### Table 9

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| ReviewId | INT | PK, IDENTITY | Unique review identifier |
| CustomerId | INT | FK -> Users | Reviewer |
| ShowId | INT | FK -> Shows | Reviewed show |
| Rating | INT | NOT NULL, CHECK 1-5 | Star rating |
| Comment | VARCHAR(500) |  | Written feedback |
| ReviewDate | DATETIME | NOT NULL | Submission timestamp |

### Table 10

| Column | Data Type | Constraint | Description |
| --- | --- | --- | --- |
| OfferId | INT | PK, IDENTITY | Unique offer identifier |
| ShowId | INT | FK -> Shows | Discounted show |
| DiscountPercent | DECIMAL(5,2) | NOT NULL, CHECK 0-100 | Percentage off |
| StartDate | DATE | NOT NULL | Offer start |
| EndDate | DATE | NOT NULL | Offer end |

___
___

## User Interface Design

All 12 required form mockups follow a consistent colour scheme (navy for Super Admin/entry screens, orange for Admin, green for Customer), a visible title bar on every form, and a Back or Logout control so no screen is a dead end. Data lists use a DataGridView rather than a plain list box, and filters use ComboBox dropdowns rather than free-text boxes.

Login

The single entry point to the system; credentials are validated against Users and UserType decides the landing dashboard.

Sign Up / Registration

New Customers and Theater Owners register here; a red validation label demonstrates the password-length rule.

Super Admin Dashboard

Summary cards for platform-wide totals plus quick-access buttons to every Super Admin feature.

Manage Theater Owners

A DataGridView of theater owners with search/filter and Approve / Reject / Suspend actions.

Platform Sales & Commission Report

A date-filterable revenue chart alongside a per-theater breakdown table.

Show / Movie CRUD

Full Add / Update / Delete control over a theater owner's own shows in a DataGridView.

Seat Inventory Dashboard

Live seats-sold vs seats-available tracking with a low-stock alert banner.

Earnings & Sales Report

A booking-level breakdown of who bought what, filterable by date range, with a total-earnings summary.

Browse Shows

Search box plus three ComboBox dropdown filters (Genre, Location, Price) over a card-based show list.

Show Details & Reviews

Full show information, a seat-quantity selector, an Add to Cart button, and existing reviews below.

Cart

Editable cart lines with remove/update actions and a computed grand total before checkout.

Checkout / Invoice

Payment method selection followed by a printable e-ticket/invoice confirming the booking.

."

## Conclusion & Future Work

This report has produced the complete design blueprint for the Movie Theater Management System: a real-world case study, functional requirements and user stories for all three roles, a UI navigation diagram, a normalised database schema with an accompanying SQL script, and mockups for all twelve required forms. Together these deliverables prove that the requirements, the navigation flow, and the database agree with each other — every feature listed in Chapter 2 is reachable through a form shown in Chapter 3 and is backed by a table and a query shown in Chapters 4 and 5.

In the coding phase that follows, the group will implement this design as a working C# Windows Forms application: building the login and role-based routing first, then each dashboard's DataGridView-driven CRUD screens, and finally the customer-facing booking and payment flow. Planned enhancements beyond the base requirements include seat-map selection (choosing individual seat numbers rather than just a quantity), integration with a real payment gateway such as bKash or a card processor, and automated email/SMS notifications for booking confirmations and low-seat alerts to theater owners.

The group anticipates two main challenges during implementation. The first is concurrency: multiple customers may try to book the last few seats of a popular show at the same time, so the checkout transaction must correctly lock or re-check SeatsAvailable to avoid overselling. The second is enforcing the data-isolation requirement strictly at the query layer — every single query issued from an Admin's screens must be filtered by that Admin's own TheaterId, since a single missed WHERE clause would let one theater owner see another owner's private sales data.

---




