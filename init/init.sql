CREATE DATABASE Trips;
GO

USE Trips;

CREATE TABLE Client
(
    IdClient  int           NOT NULL IDENTITY,
    FirstName nvarchar(120) NOT NULL,
    LastName  nvarchar(120) NOT NULL,
    Email     nvarchar(120) NOT NULL,
    Telephone nvarchar(120) NOT NULL,
    Pesel     nvarchar(120) NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY (IdClient),
    CONSTRAINT Client_pesel_uq UNIQUE (Pesel)
);

-- Table: Client_Trip
CREATE TABLE Client_Trip
(
    IdClient     int      NOT NULL,
    IdTrip       int      NOT NULL,
    RegisteredAt datetime NOT NULL,
    PaymentDate  datetime NULL,
    CONSTRAINT Client_Trip_pk PRIMARY KEY (IdClient, IdTrip)
);

-- Table: Country
CREATE TABLE Country
(
    IdCountry int           NOT NULL IDENTITY,
    Name      nvarchar(120) NOT NULL,
    CONSTRAINT Country_pk PRIMARY KEY (IdCountry)
);

-- Table: Country_Trip
CREATE TABLE Country_Trip
(
    IdCountry int NOT NULL,
    IdTrip    int NOT NULL,
    CONSTRAINT Country_Trip_pk PRIMARY KEY (IdCountry, IdTrip)
);

-- Table: Trip
CREATE TABLE Trip
(
    IdTrip      int           NOT NULL IDENTITY,
    Name        nvarchar(120) NOT NULL,
    Description nvarchar(220) NOT NULL,
    DateFrom    datetime      NOT NULL,
    DateTo      datetime      NOT NULL,
    MaxPeople   int           NOT NULL,
    CONSTRAINT Trip_pk PRIMARY KEY (IdTrip)
);

-- foreign keys
-- Reference: Country_Trip_Country (table: Country_Trip)
ALTER TABLE Country_Trip
    ADD CONSTRAINT Country_Trip_Country
        FOREIGN KEY (IdCountry)
            REFERENCES Country (IdCountry);

-- Reference: Country_Trip_Trip (table: Country_Trip)
ALTER TABLE Country_Trip
    ADD CONSTRAINT Country_Trip_Trip
        FOREIGN KEY (IdTrip)
            REFERENCES Trip (IdTrip);

-- Reference: Table_5_Client (table: Client_Trip)
ALTER TABLE Client_Trip
    ADD CONSTRAINT Table_5_Client
        FOREIGN KEY (IdClient)
            REFERENCES Client (IdClient);

-- Reference: Table_5_Trip (table: Client_Trip)
ALTER TABLE Client_Trip
    ADD CONSTRAINT Table_5_Trip
        FOREIGN KEY (IdTrip)
            REFERENCES Trip (IdTrip);

INSERT INTO Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES ('John', 'Doe', 'john@example.com', '123123123', '123123123');
INSERT INTO Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES ('John2', 'Doe2', 'john@example.com', '123123123', '123123124');

INSERT INTO Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES ('someTrip', 'someTripDesc', getdate(), getdate(), 20)
INSERT INTO Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES ('someTrip2', 'someTripDesc2', getdate(), getdate(), 20)
INSERT INTO Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES ('someTrip3', 'someTripDesc3', getdate(), getdate(), 20)

INSERT INTO Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (1, 1, getdate(), getdate());

INSERT INTO Country (Name)
VALUES ('Polska');

INSERT INTO Country_Trip (IdCountry, IdTrip)
VALUES (1, 1);
