CREATE TABLE [dbo].[CustomerAddresses] (
    [Id]            UNIQUEIDENTIFIER   NOT NULL,
    [CustomerId]      UNIQUEIDENTIFIER   NOT NULL,
    [AddressType]   NVARCHAR (50)      NOT NULL,
    [Line1]         NVARCHAR (60)      NOT NULL,
    [Line2]         NVARCHAR (60)      NULL,
    [City]          NVARCHAR (100)      NOT NULL,
    [StateProvince] NVARCHAR (50)      NOT NULL,
    [CountryRegion] NVARCHAR (50)      NOT NULL,
    [PostalCode]    NVARCHAR (15)      NOT NULL,
    [CreatedBy]     VARCHAR (320)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (320)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_CustomerAddresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerAddresses_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);

