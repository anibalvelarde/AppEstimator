  CREATE TABLE [dbo].[EstimateTechnicalFactor]
  (
    [EstimateTechnicalFactorId] INT IDENTITY(1,1) NOT NULL,
    EstimateId INT NOT NULL,
    TechnicalFactorId INT NOT NULL,
	FactorValue INT,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([EstimateTechnicalFactorId] ASC),
    FOREIGN KEY ([EstimateId]) REFERENCES [dbo].[Estimate] ([EstimateId]),
    FOREIGN KEY ([TechnicalFactorId]) REFERENCES [dbo].[TechnicalFactor] ([TechnicalFactorId])
  );
