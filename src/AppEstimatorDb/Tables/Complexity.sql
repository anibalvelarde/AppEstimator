CREATE TABLE [dbo].[Complexity]
  (
    [ComplexityId] INT IDENTITY(1,1) NOT NULL,
    [Type] CHARACTER(1) NOT NULL,
    Name NVARCHAR(20) NOT NULL,
    Value INT NOT NULL,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([ComplexityId] ASC)
  )
