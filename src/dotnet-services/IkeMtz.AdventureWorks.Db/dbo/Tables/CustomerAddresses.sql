CREATE TABLE [dbo].[CustomerAddresses] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [CustomerId]   UNIQUEIDENTIFIER   NOT NULL,
    [AddressId]    UNIQUEIDENTIFIER   NOT NULL,
    [AddressType]  NVARCHAR (50)      NOT NULL,
    [CreatedBy]    VARCHAR (50)       NOT NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]    VARCHAR (50)       NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_CustomerAddresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerAddresses_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([Id]),
    CONSTRAINT [FK_CustomerAddresses_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [UIX_CustomerAddresses] UNIQUE NONCLUSTERED ([CustomerId] ASC, [AddressId] ASC)
);

