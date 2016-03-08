CREATE VIEW [dbo].[AppUserInfo]
	AS SELECT au.AppUserId, au.Name, au.IsGuestUser, ISNULL(COUNT(est.EstimateId),0) [EstimateCount] 
	FROM [AppUser] au
	LEFT JOIN [Estimate] est ON est.UserId = au.AppUserId
	GROUP BY
		au.AppUserId,
		au.Name,
		au.IsGuestUser
