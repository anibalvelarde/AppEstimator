CREATE TABLE [dbo].[EstimateEnvironmentalFactor]
(
    [EstimateEnvironmentalFactorId] INT IDENTITY(1,1) NOT NULL,
    EstimateId INT NOT NULL,
    EnvironmentalFactorId INT NOT NULL,
	FactorValue INT,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([EstimateEnvironmentalFactorId] ASC),
	FOREIGN KEY ([EstimateId]) REFERENCES [dbo].[Estimate] ([EstimateId]),
	FOREIGN KEY ([EnvironmentalFactorId]) REFERENCES [dbo].[EnvironmentalFactor] ([EnvironmentalFactorId])
);
