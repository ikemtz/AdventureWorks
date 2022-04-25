CREATE TABLE [dbo].[Customers] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Num]          VARCHAR (15)       NOT NULL,
    [Name]         NVARCHAR (256)     NULL,
    [CompanyName]  NVARCHAR (128)     NOT NULL,
    [SalesAgentId] INT                NOT NULL,
    [EmailAddress] NVARCHAR (320)     NULL,
    [Phone]        NVARCHAR (25)      NULL,
    [CreatedBy]    VARCHAR (320)      NOT NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]    VARCHAR (320)      NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customers_SalesAgents] FOREIGN KEY ([SalesAgentId]) REFERENCES [dbo].[SalesAgents] ([Id])
);








GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Customers]
    ON [dbo].[Customers]([Num] ASC);

