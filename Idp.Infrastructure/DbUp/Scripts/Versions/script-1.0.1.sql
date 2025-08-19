insert into Ath_Scopes(Id, Name, Description)
values (1, 'openid', 'Open Id.'),
       (2, 'profile', 'Profile.')

GO

BEGIN
    DECLARE @Client table (Id UNIQUEIDENTIFIER);
    DECLARE @User table (Id UNIQUEIDENTIFIER);

    INSERT INTO Ath_Clients (Name, ClientId, Secret, Operation, ChangedBy, ChangedAt)
    OUTPUT inserted.Id INTO @Client
    VALUES (N'Genesis Client', N'01K2ZZC5C0H76GVJB0HKAKEN05',
            N'2aGti9qeKKO0LVQxG3zCmQ==', 'C', N'Seeder#0', getdate());;

    INSERT INTO Ath_ClientScopes (ScopeId, ClientId, Operation, ChangedBy, ChangedAt)
    VALUES (1, (select Id from @Client), N'C      ',
            N'Seeder#0', getdate()),
           (2, (select Id from @Client), N'C      ',
            N'Seeder#0', getdate());

    INSERT INTO Ath_ClientRedirects (Uri, ClientId, Operation, ChangedBy, ChangedAt)
    VALUES (N'https://localhost:4200/callback',
            (select Id from @Client), N'C      ', N'Seeder#0', getdate());

    INSERT INTO Ath_Users (Username, Email, PasswordHash, HasMfa, LastLoginAt, IsActive, Operation,
                           ChangedBy, ChangedAt)
    OUTPUT inserted.Id INTO @User
    VALUES (N'genesis', N'genesis@admin.com',
            N'$2a$11$f9yXUl0Ijqytbsz6JddxFuIERBV6sQmzGrNExMOt5QyGUxpoI0GnG', 0, N'0001-01-01 00:00:00.0000000 +00:00',
            1, N'C      ', N'Seeder#0', getdate());

    INSERT INTO Ppl_People (Id, FirstName, LastName, Document, PhoneNumber, BirthDate, Operation, ChangedBy,
                            ChangedAt, NormalizedDocument)
    VALUES ((select Id from @User), N'Genesis', N'Admin', N'51.009.031/0001-44', null, N'2025-08-18',
            N'C      ', N'Seeder#0', getdate(), N'51009031000144');

END