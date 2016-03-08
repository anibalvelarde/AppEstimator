  CREATE TABLE [dbo].[UseCase]
  (
    [UseCaseId] INT IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(1500) NULL,
    ComplexityId INT NOT NULL,
	EstimateId INT NOT NULL,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([UseCaseId] ASC),
    FOREIGN KEY ([ComplexityId]) REFERENCES [dbo].[Complexity] ([ComplexityId]),
	FOREIGN KEY ([EstimateId]) REFERENCES [dbo].[Estimate] ([EstimateId])
  );
