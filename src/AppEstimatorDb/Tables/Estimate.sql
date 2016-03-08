  CREATE TABLE [dbo].[Estimate]
  (
    [EstimateId] INT IDENTITY(1,1) NOT NULL,
    UserId INT NOT NULL,
    CreatedOnUTC DATETIME2 NOT NULL,
    LastUpdatedOn DATETIME2 NULL,
    ProjectName NVARCHAR(150) NOT NULL,
    TCF FLOAT NULL,
    [ECF] FLOAT NULL,
    UAP FLOAT NULL,
    UUCP FLOAT NULL,
    UCP FLOAT NULL,
    Effort FLOAT NOT NULL,
    HoursPerUCP INT NOT NULL,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([EstimateId] ASC)
  );