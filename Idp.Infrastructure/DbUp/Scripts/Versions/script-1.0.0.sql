CREATE TABLE Ath_Clients
(
    Id       uniqueidentifier
        constraint PK_Client primary key not null
        constraint DF_Client default NEWID(),
    ClientId varchar(254)                not null,
    Secret   varchar(254)                not null
)

go

CREATE TABLE Ath_Users
(
    Id           uniqueidentifier
        constraint PK_User primary key not null
        constraint DF_User default NEWID(),
    Username     varchar(254)          not null,
    Email        varchar(254)          not null,
    PasswordHash varchar(254)          not null,
    HasMfa       BIT                   not null
)

go

CREATE TABLE Ath_Scopes
(
    Id          int
        constraint PK_Scope primary key not null,
    Name        varchar(254)            not null,
    Description varchar(254)            not null
)

go

CREATE INDEX IDX_Scope_Name ON Ath_Scopes (Name)

go

CREATE TABLE Ath_ClientScopes
(
    Id       uniqueidentifier not null
        constraint PK_ClientScope primary key
        constraint DF_ClientScope default NEWID(),
    ScopeId  int              not null
        constraint FK_ClientScope_Scopes references Ath_Scopes (Id),
    ClientId uniqueidentifier not null
        constraint FK_ClientScope_Clients references Ath_Clients (Id)
)

GO

CREATE INDEX IDX_ClientScope_ClientId_ScopedId ON Ath_ClientScopes (ScopeId, ClientId)

GO

CREATE TABLE Ath_ClientRedirects
(
    Id       uniqueidentifier not null
        constraint PK_ClientRedirect primary key
        constraint DF_ClientRedirect default NEWID(),
    Uri      varchar(600)     not null,
    ClientId uniqueidentifier not null
        constraint FK_ClientRedirect_Clients references Ath_Clients (Id),
)

GO

CREATE INDEX IDX_ClientRedirect_ClientId ON Ath_ClientRedirects (ClientId)

GO

CREATE TABLE Ath_Tokens
(
    Id           uniqueidentifier not null
        constraint PK_Token primary key
        constraint DF_Token default NEWID(),
    UserId       uniqueidentifier not null
        constraint FK_Token_Users references Ath_Users (Id),
    ClientId     uniqueidentifier not null
        constraint FK_Token_Clients references Ath_Clients (Id),
    ExpiresAt    DATETIMEOFFSET   NOT NULL,
    RefreshToken varchar(160)     NOT NULL
)

GO

CREATE TABLE Ath_AuthorizationCodes
(
    Id            uniqueidentifier not null
        constraint PK_AuthorizationCode primary key
        constraint DF_AuthorizationCode default NEWID(),
    UserId        uniqueidentifier not null
        constraint FK_AuthorizationCode_Users REFERENCES Ath_Users (Id),
    ClientId      uniqueidentifier not null
        constraint FK_AuthorizationCode_Clients references Ath_Clients (Id),
    Code          varchar(256)     not null,
    CodeChallenge varchar(128)     NOT NULL,
    State         varchar(180)     null,
    ExpiresAt     DATETIMEOFFSET   NOT NULL
)