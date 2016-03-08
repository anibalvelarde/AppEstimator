/***
	Adding test data for Application User
**/
if not exists(select * from dbo.AppUser where Name = 'AnibalUser')
	insert into dbo.AppUser(Name, GitHubId, IsGuestUser) values('AnibalUser','02E7DB20-B45E-431E-B3E0-61E1FF71953C', 0);
if not exists(select * from dbo.AppUser where Name = 'AnibalVip')
	insert into dbo.AppUser(Name, GitHubId, IsGuestUser) values('AnibalVip','02E7DB20-B45E-431E-B3E0-61E1FF71952C', 0);
if not exists(select * from dbo.AppUser where Name = 'AnibalVelarde')
	insert into dbo.AppUser(Name, GitHubId, IsGuestUser) values('AnibalVelarde','02E7DB20-B45E-431E-B3E0-61E1FF71951C', 0);