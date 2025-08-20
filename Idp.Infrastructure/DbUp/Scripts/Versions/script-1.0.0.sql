CREATE TABLE Ath_Clients
(
    Id        uniqueidentifier NOT NULL
        CONSTRAINT PK_Client PRIMARY KEY
        CONSTRAINT DF_Client DEFAULT NEWID(),
    Name      varchar(254) NOT NULL,
    ClientId  varchar(254) NOT NULL,
    Secret    varchar(254) NOT NULL,
    Operation char(7) NOT NULL,
    ChangedBy varchar(254) NOT NULL,
    ChangedAt datetimeoffset NOT NULL
)
GO

CREATE TABLE Ath_Users
(
    Id           uniqueidentifier NOT NULL
        CONSTRAINT PK_User PRIMARY KEY
        CONSTRAINT DF_User DEFAULT NEWID(),
    Username     varchar(254) NOT NULL,
    Email        varchar(254) NOT NULL,
    PasswordHash varchar(254) NOT NULL,
    HasMfa       bit NOT NULL,
    LastLoginAt  datetimeoffset NOT NULL,
    IsActive     bit NOT NULL,
    Operation    char(7) NOT NULL,
    ChangedBy    varchar(254) NOT NULL,
    ChangedAt    datetimeoffset NOT NULL
)
GO

CREATE TABLE Ath_Scopes
(
    Id          int NOT NULL
        CONSTRAINT PK_Scope PRIMARY KEY,
    Name        varchar(254) NOT NULL,
    Description varchar(254) NOT NULL
)
GO

CREATE TABLE Ath_ClientScopes
(
    Id        uniqueidentifier NOT NULL
        CONSTRAINT PK_ClientScope PRIMARY KEY
        CONSTRAINT DF_ClientScope DEFAULT NEWID(),
    ScopeId   int NOT NULL
        CONSTRAINT FK_ClientScope_Scopes REFERENCES Ath_Scopes (Id),
    ClientId  uniqueidentifier NOT NULL
        CONSTRAINT FK_ClientScope_Clients REFERENCES Ath_Clients (Id),
    Operation char(7) NOT NULL,
    ChangedBy varchar(254) NOT NULL,
    ChangedAt datetimeoffset NOT NULL
)
GO

CREATE INDEX IDX_ClientScope_ClientId_ScopedId ON Ath_ClientScopes (ScopeId, ClientId)
GO

CREATE TABLE Ath_ClientRedirects
(
    Id        uniqueidentifier NOT NULL
        CONSTRAINT PK_ClientRedirect PRIMARY KEY
        CONSTRAINT DF_ClientRedirect DEFAULT NEWID(),
    Uri       varchar(600) NOT NULL,
    ClientId  uniqueidentifier NOT NULL
        CONSTRAINT FK_ClientRedirect_Clients REFERENCES Ath_Clients (Id),
    Operation char(7) NOT NULL,
    ChangedBy varchar(254) NOT NULL,
    ChangedAt datetimeoffset NOT NULL
)
GO

CREATE INDEX IDX_ClientRedirect_ClientId ON Ath_ClientRedirects (ClientId)
GO

CREATE TABLE Ath_Tokens
(
    Id           uniqueidentifier NOT NULL
        CONSTRAINT PK_Token PRIMARY KEY
        CONSTRAINT DF_Token DEFAULT NEWID(),
    UserId       uniqueidentifier NOT NULL
        CONSTRAINT FK_Token_Users REFERENCES Ath_Users (Id),
    ClientId     uniqueidentifier NOT NULL
        CONSTRAINT FK_Token_Clients REFERENCES Ath_Clients (Id),
    ExpiresAt    datetimeoffset NOT NULL,
    RefreshToken varchar(160) NOT NULL,
    Operation    char(7) NOT NULL,
    ChangedBy    varchar(254) NOT NULL,
    ChangedAt    datetimeoffset NOT NULL
)
GO

CREATE TABLE Ath_AuthorizationCodes
(
    Id            uniqueidentifier NOT NULL
        CONSTRAINT PK_AuthorizationCode PRIMARY KEY
        CONSTRAINT DF_AuthorizationCode DEFAULT NEWID(),
    UserId        uniqueidentifier NOT NULL
        CONSTRAINT FK_AuthorizationCode_Users REFERENCES Ath_Users (Id),
    ClientId      uniqueidentifier NOT NULL
        CONSTRAINT FK_AuthorizationCode_Clients REFERENCES Ath_Clients (Id),
    Code          varchar(256) NOT NULL,
    CodeChallenge varchar(128) NOT NULL,
    State         varchar(180) NULL,
    IsUsed        bit NOT NULL,
    UsedAt        datetimeoffset NULL,
    ExpiresAt     datetimeoffset NOT NULL,
    Operation     char(7) NOT NULL,
    ChangedBy     varchar(254) NOT NULL,
    ChangedAt     datetimeoffset NOT NULL
)
GO

CREATE TABLE Ath_Consent
(
    Id        bigint NOT NULL
        CONSTRAINT PK_AuthorizationConsent PRIMARY KEY IDENTITY,
    UserId    uniqueidentifier NOT NULL
        CONSTRAINT FK_AuthorizationConsent_Users REFERENCES Ath_Users (Id),
    ClientId  uniqueidentifier NOT NULL
        CONSTRAINT FK_AuthorizationConsent_Clients REFERENCES Ath_Clients (Id),
    GrantedAt datetimeoffset NOT NULL,
    ExpiresAt datetimeoffset NULL,
    RevokedAt datetimeoffset NULL,
    Operation char(7) NOT NULL,
    ChangedBy varchar(254) NOT NULL,
    ChangedAt datetimeoffset NOT NULL
)
GO

CREATE TABLE Ath_ConsentScopes
(
    Id bigint NOT NULL
        CONSTRAINT PK_AuthorizationConsentScope PRIMARY KEY IDENTITY,
    ConsentId bigint NOT NULL
        CONSTRAINT FK_AuthorizationConsentScope_Consent REFERENCES Ath_Consent(Id),
    ScopeId int NOT NULL
        CONSTRAINT FK_AuthorizationConsentScope_Scope REFERENCES Ath_Scopes(Id),
    ConsentedAt datetimeoffset NOT NULL
)
GO

CREATE TABLE Ppl_People
(
    Id uniqueidentifier NOT NULL
        CONSTRAINT PK_People PRIMARY KEY
        CONSTRAINT FK_People_User FOREIGN KEY REFERENCES Ath_Users(Id),
    FirstName varchar(254) NOT NULL,
    LastName varchar(254) NOT NULL,
    Document varchar(50) NOT NULL,
    NormalizedDocument varchar(50) NOT NULL,
    PhoneNumber varchar(40) NULL,
    BirthDate date NULL,
    Operation char(7) NOT NULL,
    ChangedBy varchar(254) NOT NULL,
    ChangedAt datetimeoffset NOT NULL
)
GO

CREATE TABLE Ath_LoginAttempts
(
    Id bigint NOT NULL CONSTRAINT PK_AuthorizationLoginAttempt PRIMARY KEY IDENTITY,
    UserId    uniqueidentifier NOT NULL
        CONSTRAINT FK_AuthorizationLoginAttempt_Users REFERENCES Ath_Users (Id),
    IpAddress varchar(60) NOT NULL,
    AttemptAt datetimeoffset NOT NULL,
    UserAgent varchar(140) NOT NULL,
    ItWasSuccessful bit NOT NULL
)
GO

CREATE TABLE Ath_SigningKeys
(
    Id          uniqueidentifier NOT NULL
        CONSTRAINT PK_SigningKey PRIMARY KEY,
    KeyId       nvarchar(128) NOT NULL
        CONSTRAINT UQ_SigningKey_KeyId UNIQUE,
    PublicJWK   nvarchar(max) NOT NULL,
    CanIssue    bit NOT NULL,
    ExpiredAt   datetimeoffset NULL,
    GracePeriod datetimeoffset NULL,
    Algorithm   nvarchar(20) NOT NULL,
    Operation   char(7) NOT NULL,
    ChangedBy   varchar(254) NOT NULL,
    ChangedAt   datetimeoffset NOT NULL
)
GO
