﻿  CREATE TABLE [dbo].[EnvironmentalFactor]
  (
    [EnvironmentalFactorId] INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL, 
    Multiplier FLOAT NOT NULL,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([EnvironmentalFactorId] ASC)
  );