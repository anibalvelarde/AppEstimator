CREATE TABLE [dbo].[Actor]
  (
    [ActorId] INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    ComplexityId INT NOT NULL,
	EstimateId INT NOT NULL,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([ActorId] ASC),
    FOREIGN KEY ([ComplexityId]) REFERENCES [dbo].[Complexity] ([ComplexityId]),
	FOREIGN KEY ([EstimateId]) REFERENCES [dbo].[Estimate] ([EstimateId])
  );

