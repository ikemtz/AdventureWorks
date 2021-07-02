﻿CREATE TABLE [dbo].[ClientAddresses] (
    [Id]            UNIQUEIDENTIFIER   NOT NULL,
    [ClientId]      UNIQUEIDENTIFIER   NOT NULL,
    [AddressType]   NVARCHAR (50)      NOT NULL,
    [Line1]         NVARCHAR (60)      NOT NULL,
    [Line2]         NVARCHAR (60)      NULL,
    [City]          NVARCHAR (30)      NOT NULL,
    [StateProvince] NVARCHAR (50)      NOT NULL,
    [CountryRegion] NVARCHAR (50)      NOT NULL,
    [PostalCode]    NVARCHAR (15)      NOT NULL,
    [CreatedBy]     VARCHAR (50)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (50)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_ClientAddresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClientAddresses_Clients] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id])
);

