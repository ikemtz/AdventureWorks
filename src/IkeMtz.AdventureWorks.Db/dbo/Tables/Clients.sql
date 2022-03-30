CREATE TABLE [dbo].[Clients] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Name]         NVARCHAR (256)     NULL,
    [CompanyName]  NVARCHAR (128)     NOT NULL,
    [SalesPerson]  NVARCHAR (256)     NULL,
    [EmailAddress] NVARCHAR (320)      NULL,
    [Phone]        NVARCHAR (25)      NULL,
    [CreatedBy]     VARCHAR (320)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (320)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

