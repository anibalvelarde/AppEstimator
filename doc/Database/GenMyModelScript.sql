USE AppEstimator
GO

-- Create schemas

-- Create tables
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AppUser'))
BEGIN
  CREATE TABLE AppUser
  (
    Id INT NOT NULL,
    Name NVARCHAR(35),
    GitHubId NVARCHAR(40),
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Estimate'))
BEGIN
  CREATE TABLE Estimate
  (
    Id INT NOT NULL,
    UserId INT,
    CreatedOnUTC DATETIME2,
    LastUpdatedOn DATETIME2,
    ProjectName NVARCHAR(150),
    TCF FLOAT,
    EF FLOAT,
    UAP FLOAT,
    UUCP FLOAT,
    UCP FLOAT,
    Effort FLOAT,
    HoursPerUCP INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TechnicalFactor'))
BEGIN
  CREATE TABLE TechnicalFactor
  (
    Id INT NOT NULL,
    Name NVARCHAR(50),
    Multiplier INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EnvironmentalFactor'))
BEGIN
  CREATE TABLE EnvironmentalFactor
  (
    Id INT NOT NULL,
    Name NVARCHAR(50),
    Multiplier INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EstimateTF'))
BEGIN
  CREATE TABLE EstimateTF
  (
    Id INT NOT NULL,
    EstimateId INT,
    TechnicalFactorId INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EstimateEF'))
BEGIN
  CREATE TABLE EstimateEF
  (
    Id INT NOT NULL,
    EstimateId INT,
    EnvironmentalFactorId INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UseCase'))
BEGIN
  CREATE TABLE UseCase
  (
    Id INT NOT NULL,
    Title NVARCHAR(100),
    ComplexityId INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Actor'))
BEGIN
  CREATE TABLE Actor
  (
    Id INT NOT NULL,
    Name NVARCHAR(100),
    ComplexityId INT,
    PRIMARY KEY(Id)
  )
END;

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Complexity'))
BEGIN
  CREATE TABLE Complexity
  (
    Id INT NOT NULL,
    Type CHARACTER(1),
    Name NVARCHAR(20),
    Value INT,
    PRIMARY KEY(Id)
  )
END;


-- Create FKs
ALTER TABLE UseCase
    ADD    FOREIGN KEY (ComplexityId)
    REFERENCES Complexity(Id)
;
    
ALTER TABLE Actor
    ADD    FOREIGN KEY (ComplexityId)
    REFERENCES Complexity(Id)
;
    
ALTER TABLE Estimate
    ADD    FOREIGN KEY (UserId)
    REFERENCES AppUser(Id)
;
    
ALTER TABLE EstimateTF
    ADD    FOREIGN KEY (EstimateId)
    REFERENCES Estimate(Id)
;
    
ALTER TABLE EstimateTF
    ADD    FOREIGN KEY (TechnicalFactorId)
    REFERENCES TechnicalFactor(Id)
;
    
ALTER TABLE EstimateEF
    ADD    FOREIGN KEY (EstimateId)
    REFERENCES Estimate(Id)
;
    
ALTER TABLE EstimateEF
    ADD    FOREIGN KEY (EnvironmentalFactorId)
    REFERENCES EnvironmentalFactor(Id)
;
    

