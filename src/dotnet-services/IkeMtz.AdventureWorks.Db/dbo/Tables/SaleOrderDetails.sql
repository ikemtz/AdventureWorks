CREATE TABLE [dbo].[SaleOrderDetails] (
    [Id]                UNIQUEIDENTIFIER   NOT NULL,
    [SaleOrderId]       UNIQUEIDENTIFIER   NOT NULL,
    [OrderQty]          SMALLINT           NOT NULL,
    [ProductId]         UNIQUEIDENTIFIER   NOT NULL,
    [UnitPrice]         MONEY              NOT NULL,
    [UnitPriceDiscount] MONEY              CONSTRAINT [DF_SaleOrderDetails_UnitPriceDiscount] DEFAULT ((0.0)) NOT NULL,
    [LineTotal]         AS                 (isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0))),
    [CreatedBy]         VARCHAR (50)       NOT NULL,
    [CreatedOnUtc]      DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]         VARCHAR (50)       NULL,
    [UpdatedOnUtc]      DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_SaleOrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_SaleOrderDetails_OrderQty] CHECK ([OrderQty]>(0)),
    CONSTRAINT [CK_SaleOrderDetails_UnitPrice] CHECK ([UnitPrice]>=(0.00)),
    CONSTRAINT [CK_SaleOrderDetails_UnitPriceDiscount] CHECK ([UnitPriceDiscount]>=(0.00)),
    CONSTRAINT [FK_SaleOrderDetails_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_SaleOrderDetails_SaleOrders] FOREIGN KEY ([SaleOrderId]) REFERENCES [dbo].[SaleOrders] ([Id]) ON DELETE CASCADE
);

