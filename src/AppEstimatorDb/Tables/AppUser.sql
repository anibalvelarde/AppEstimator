CREATE TABLE [dbo].[AppUser]
  (
    [AppUserId] INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(35) NOT NULL,
    GitHubId NVARCHAR(100) NOT NULL,
    IsGuestUser bit NOT NULL,
    ts rowversion NOT NULL,
    PRIMARY KEY CLUSTERED ([AppUserId] ASC)
  );