CREATE TABLE [dbo].[OrderLineItems] (
    [Id]                UNIQUEIDENTIFIER   NOT NULL,
    [OrderId]       UNIQUEIDENTIFIER   NOT NULL,
    [OrderQty]          SMALLINT           NOT NULL,
    [ProductId]         UNIQUEIDENTIFIER   NOT NULL,
    [UnitPrice]         MONEY              NOT NULL,
    [UnitPriceDiscount] MONEY              CONSTRAINT [DF_OrderLineItems_UnitPriceDiscount] DEFAULT ((0.0)) NOT NULL,
    [LineTotal]         AS                 (isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0))),
    [CreatedBy]     VARCHAR (320)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (320)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_OrderLineItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_OrderLineItems_OrderQty] CHECK ([OrderQty]>(0)),
    CONSTRAINT [CK_OrderLineItems_UnitPrice] CHECK ([UnitPrice]>=(0.00)),
    CONSTRAINT [CK_OrderLineItems_UnitPriceDiscount] CHECK ([UnitPriceDiscount]>=(0.00)),
    CONSTRAINT [FK_OrderLineItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_OrderLineItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE
);

