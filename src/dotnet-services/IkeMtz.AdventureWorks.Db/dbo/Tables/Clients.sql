CREATE TABLE [dbo].[Clients] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Name]         NVARCHAR (512)     NULL,
    [CompanyName]  NVARCHAR (128)     NOT NULL,
    [SalesPerson]  NVARCHAR (256)     NULL,
    [EmailAddress] NVARCHAR (50)      NULL,
    [Phone]        NVARCHAR (50)      NULL,
    [CreatedBy]    VARCHAR (50)       NOT NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]    VARCHAR (50)       NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

