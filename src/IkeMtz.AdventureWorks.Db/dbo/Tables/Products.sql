CREATE TABLE [dbo].[Products] (
    [Id]                UNIQUEIDENTIFIER   NOT NULL,
    [Name]              NVARCHAR (50)      NOT NULL,
    [ProductNumber]     NVARCHAR (25)      NOT NULL,
    [Color]             NVARCHAR (15)      NULL,
    [StandardCost]      MONEY              NOT NULL,
    [ListPrice]         MONEY              NOT NULL,
    [Size]              NVARCHAR (5)       NULL,
    [Weight]            DECIMAL (8, 2)     NULL,
    [ProductCategoryId] UNIQUEIDENTIFIER   NULL,
    [ProductModelId]    UNIQUEIDENTIFIER   NULL,
    [SellStartDate]     DATETIME           NOT NULL,
    [SellEndDate]       DATETIME           NULL,
    [DiscontinuedDate]  DATETIME           NULL,
    [ThumbNailPhoto]    VARBINARY (5000)    NULL,
    [CreatedBy]     VARCHAR (320)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (320)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Products_ListPrice] CHECK ([ListPrice]>=(0.00)),
    CONSTRAINT [CK_Products_SellEndDate] CHECK ([SellEndDate]>=[SellStartDate] OR [SellEndDate] IS NULL),
    CONSTRAINT [CK_Products_StandardCost] CHECK ([StandardCost]>=(0.00)),
    CONSTRAINT [CK_Products_Weight] CHECK ([Weight]>(0.00)),
    CONSTRAINT [FK_Products_ProductCategories] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategories] ([Id]),
    CONSTRAINT [FK_Products_ProductModels] FOREIGN KEY ([ProductModelId]) REFERENCES [dbo].[ProductModels] ([Id]),
    CONSTRAINT [UIX_Products_Name] UNIQUE NONCLUSTERED ([Name] ASC),
    CONSTRAINT [UIX_Products_ProductNumber] UNIQUE NONCLUSTERED ([ProductNumber] ASC)
);



