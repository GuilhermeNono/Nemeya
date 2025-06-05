CREATE TABLE Ath_Clients
(
    Id        uniqueidentifier
        constraint PK_Client primary key not null
        constraint DF_Client default NEWID(),
    Name      varchar(254)               not null,
    ClientId  varchar(254)               not null,
    Secret    varchar(254)               not null,
    Operation char(7)                    not null,
    ChangedBy varchar(254)               not null,
    ChangedAt DATETIMEOFFSET             not null
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
    HasMfa       BIT                   not null,
    LastLoginAt  DATETIMEOFFSET        NOT NULL,
    IsActive     BIT                   NOT NULL,
    Operation    char(7)               not null,
    ChangedBy    varchar(254)          not null,
    ChangedAt    DATETIMEOFFSET        not null
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

CREATE TABLE Ath_ClientScopes
(
    Id        uniqueidentifier not null
        constraint PK_ClientScope primary key
        constraint DF_ClientScope default NEWID(),
    ScopeId   int              not null
        constraint FK_ClientScope_Scopes references Ath_Scopes (Id),
    ClientId  uniqueidentifier not null
        constraint FK_ClientScope_Clients references Ath_Clients (Id),
    Operation char(7)          not null,
    ChangedBy varchar(254)     not null,
    ChangedAt DATETIMEOFFSET   not null
)
    GO

CREATE INDEX IDX_ClientScope_ClientId_ScopedId ON Ath_ClientScopes (ScopeId, ClientId)
    GO

CREATE TABLE Ath_ClientRedirects
(
    Id        uniqueidentifier not null
        constraint PK_ClientRedirect primary key
        constraint DF_ClientRedirect default NEWID(),
    Uri       varchar(600)     not null,
    ClientId  uniqueidentifier not null
        constraint FK_ClientRedirect_Clients references Ath_Clients (Id),
    Operation char(7)          not null,
    ChangedBy varchar(254)     not null,
    ChangedAt DATETIMEOFFSET   not null
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
    RefreshToken varchar(160)     NOT NULL,
    Operation    char(7)          not null,
    ChangedBy    varchar(254)     not null,
    ChangedAt    DATETIMEOFFSET   not null
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
    State         varchar(180) null,
    IsUsed        BIT              NOT NULL,
    UsedAt        DATETIMEOFFSET NULL,
    ExpiresAt     DATETIMEOFFSET   NOT NULL,
    Operation     char(7)          not null,
    ChangedBy     varchar(254)     not null,
    ChangedAt     DATETIMEOFFSET   not null
)
    GO

CREATE TABLE Ath_Consent
(
    Id        bigint           not null
        constraint PK_AuthorizationConsent primary key identity,
    UserId    uniqueidentifier not null
        constraint FK_AuthorizationConsent_Users REFERENCES Ath_Users (Id),
    ClientId  uniqueidentifier not null
        constraint FK_AuthorizationConsent_Clients references Ath_Clients (Id),
    GrantedAt DATETIMEOFFSET   NOT NULL,
    ExpiresAt DATETIMEOFFSET NULL,
    RevokedAt DATETIMEOFFSET NULL,
    Operation char(7)          not null,
    ChangedBy varchar(254)     not null,
    ChangedAt DATETIMEOFFSET   not null
)
    GO

CREATE TABLE Ath_ConsentScopes
(
    Id bigint not null
        constraint PK_AuthorizationConsentScope primary key identity,
    ConsentId bigint not null
        constraint FK_AuthorizationConsentScope_Consent references Ath_Consent(Id),
    ScopeId int not null constraint FK_AuthorizationConsentScope_Scope references Ath_Scopes(Id),
    ConsentedAt datetimeoffset not null
)

go

CREATE TABLE Ppl_People(
    Id uniqueidentifier not null 
        constraint PK_People primary key
        constraint FK_People_User references Ath_Users(Id),
    FirstName varchar(254) not null,
    LastName varchar(254) not null,
    DocumentHash varchar(254) not null,
    PhoneNumber varchar(40) null,
    BirthDate Date null,
    Operation char(7)          not null,
    ChangedBy varchar(254)     not null,
    ChangedAt DATETIMEOFFSET   not null
)

go

CREATE TABLE Ath_LoginAttempts(
    Id bigint not null constraint PK_AuthorizationLoginAttempt primary key identity,
    UserId    uniqueidentifier not null
        constraint FK_AuthorizationLoginAttempt_Users REFERENCES Ath_Users (Id),
    IpAddress varchar(60) not null,
    AttemptAt datetimeoffset not null,
    UserAgent varchar(140) not null,
    ItWasSuccessful bit not null
)