CREATE TABLE Doctor
(
    IdDoctor       int           NOT NULL,
    FirstName      nvarchar(100) NOT NULL,
    LastName       nvarchar(100) NOT NULL,
    Specialization nvarchar(100) NULL,
    PriceForVisit  money         NOT NULL,
    CONSTRAINT Doctor_pk PRIMARY KEY (IdDoctor)
);

-- Table: Patient
CREATE TABLE Patient
(
    IdPatient int           NOT NULL,
    FirstName nvarchar(100) NOT NULL,
    LastName  nvarchar(100) NOT NULL,
    Birthdate date          NOT NULL,
    CONSTRAINT Patient_pk PRIMARY KEY (IdPatient)
);

-- Table: Schedule
CREATE TABLE Schedule
(
    IdSchedule int      NOT NULL,
    IdDoctor   int      NOT NULL,
    DateFrom   datetime NOT NULL,
    DateTo     datetime NOT NULL,
    CONSTRAINT Schedule_pk PRIMARY KEY (IdSchedule)
);

-- Table: Visit
CREATE TABLE Visit
(
    IdVisit   int      identity NOT NULL,
    Date      datetime NOT NULL,
    IdPatient int      NOT NULL,
    IdDoctor  int      NOT NULL,
    Price     money    NOT NULL,
    CONSTRAINT Visit_pk PRIMARY KEY (IdVisit)
);

-- foreign keys
-- Reference: Schedule_Doctor (table: Schedule)
ALTER TABLE Schedule
    ADD CONSTRAINT Schedule_Doctor
        FOREIGN KEY (IdDoctor)
            REFERENCES Doctor (IdDoctor);

-- Reference: Table_6_Doctor (table: Visit)
ALTER TABLE Visit
    ADD CONSTRAINT Table_6_Doctor
        FOREIGN KEY (IdDoctor)
            REFERENCES Doctor (IdDoctor);

-- Reference: Table_6_Patient (table: Visit)
ALTER TABLE Visit
    ADD CONSTRAINT Table_6_Patient
        FOREIGN KEY (IdPatient)
            REFERENCES Patient (IdPatient);

insert into Patient(IdPatient, FirstName, LastName, Birthdate)
values (1, 'John1', 'Doe1', GETDATE());
insert into Patient(IdPatient, FirstName, LastName, Birthdate)
values (2, 'John2', 'Doe2', GETDATE());
insert into Patient(IdPatient, FirstName, LastName, Birthdate)
values (3, 'John3', 'Doe3', GETDATE());

insert into Doctor(IdDoctor, FirstName,LastName,Specialization, PriceForVisit) values (1, 'DocFirtsName1', 'DocLastName1', 'Some spec', 120);
insert into Doctor(IdDoctor, FirstName,LastName,Specialization, PriceForVisit) values (2, 'DocFirtsName2', 'DocLastName2', 'Some spec', 220);
insert into Doctor(IdDoctor, FirstName,LastName,Specialization, PriceForVisit) values (3, 'DocFirtsName3', 'DocLastName3', 'Some spec', 320);

insert into Visit(Date, IdPatient, IdDoctor, Price) values (GETDATE(), 1, 1, 150);