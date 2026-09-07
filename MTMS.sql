

USE [master];
GO

IF DB_ID(N'MTMS') IS NOT NULL
BEGIN
    ALTER DATABASE [MTMS] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [MTMS];
END
GO

CREATE DATABASE [MTMS];
GO

USE [MTMS];
GO

CREATE TABLE [dbo].[AudienceFeedback](
    [FeedbackID]     varchar(50) NOT NULL,
    [UserID]         varchar(50) NOT NULL,
    [MovieID]        varchar(50) NOT NULL,
    [F_Rating]       varchar(50) NOT NULL,
    [F_Comment]      varchar(50) NOT NULL,
    [F_ReviewDate]   varchar(50) NOT NULL
);
GO

CREATE TABLE [dbo].[BookingTicket](
    [BookingID]      varchar(50) NOT NULL,
    [UserID]         varchar(50) NOT NULL,
    [ShowID]         varchar(50) NOT NULL,
    [SeatID]         varchar(50) NOT NULL,
    [BookingDate]    varchar(50) NOT NULL,
    [Quantity]       varchar(50) NOT NULL,
    [TotalPrice]     varchar(50) NOT NULL,
    [Ticket_Status]  varchar(50) NOT NULL
);
GO

CREATE TABLE [dbo].[ManageMovies](
    [MovieID]          varchar(50) NOT NULL,
    [M_Title]          varchar(50) NOT NULL,
    [M_Genre]          varchar(50) NOT NULL,
    [M_Duration]       varchar(50) NOT NULL,
    [M_ReleaseDate]    varchar(50) NOT NULL,
    [M_Language]       varchar(50) NOT NULL,
    [M_Rating]         varchar(50) NOT NULL,
    [M_PosterPath]     varchar(5000) NOT NULL,
    [M_Status]         varchar(50) NOT NULL,
    CONSTRAINT [PK_ManageMovies] PRIMARY KEY CLUSTERED ([MovieID] ASC)
);
GO

CREATE TABLE [dbo].[ManageSeat](
    [SeatID]        varchar(50) NOT NULL,
    [ShowID]        varchar(50) NOT NULL,
    [SeatNumber]    varchar(50) NOT NULL,
    [SeatType]      varchar(50) NOT NULL,
    [Seat_Status]   varchar(50) NOT NULL,
    CONSTRAINT [PK_ManageSeat] PRIMARY KEY CLUSTERED ([SeatID] ASC)
);
GO

CREATE TABLE [dbo].[ManageShows](
    [ShowID]              varchar(50) NOT NULL,
    [MovieID]             varchar(50) NOT NULL,
    [ShowDate]            varchar(50) NOT NULL,
    [ShowTime]            varchar(50) NOT NULL,
    [S_HallNo]            varchar(50) NOT NULL,
    [S_Price]             varchar(50) NOT NULL,
    [S_TotalSeats]        varchar(50) NOT NULL,
    [S_AvailableSeats]    varchar(50) NOT NULL,
    CONSTRAINT [PK_ManageShows] PRIMARY KEY CLUSTERED ([ShowID] ASC)
);
GO

CREATE TABLE [dbo].[User](
    [UserName]  varchar(50) NOT NULL,
    [Password]  varchar(50) NOT NULL,
    [Role]      nvarchar(20) NULL
);
GO


IF NOT EXISTS (SELECT 1 FROM [dbo].[User] WHERE [UserName] = 'A001')
    INSERT INTO [dbo].[User] ([UserName], [Password], [Role])
    VALUES ('A001', '1234', 'Admin');
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[User] WHERE [UserName] = 'C001')
    INSERT INTO [dbo].[User] ([UserName], [Password], [Role])
    VALUES ('C001', '1234', 'Customer');
GO


IF NOT EXISTS (SELECT 1 FROM [dbo].[User] WHERE [UserName] = 'SA001')
    INSERT INTO [dbo].[User] ([UserName], [Password], [Role])
    VALUES ('SA001', '1234', 'SuperAdmin');
GO

USE [master];
GO
ALTER DATABASE [MTMS] SET MULTI_USER;
GO
