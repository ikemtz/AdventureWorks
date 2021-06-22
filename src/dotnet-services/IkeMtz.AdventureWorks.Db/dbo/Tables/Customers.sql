CREATE TABLE [dbo].[Customers] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [NameStyle]    BIT                CONSTRAINT [DF_Customers_NameStyle] DEFAULT ((0)) NOT NULL,
    [Title]        NVARCHAR (8)       NULL,
    [FirstName]    NVARCHAR (50)      NOT NULL,
    [MiddleName]   NVARCHAR (50)      NULL,
    [LastName]     NVARCHAR (50)      NOT NULL,
    [Suffix]       NVARCHAR (10)      NULL,
    [CompanyName]  NVARCHAR (128)     NULL,
    [SalesPerson]  NVARCHAR (256)     NULL,
    [EmailAddress] NVARCHAR (50)      NULL,
    [Phone]        NVARCHAR (50)      NULL,
    [CreatedBy]    VARCHAR (50)       NOT NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]    VARCHAR (50)       NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

