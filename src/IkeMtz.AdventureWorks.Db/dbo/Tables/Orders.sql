CREATE TABLE [dbo].[Orders] (
    [Id]                     UNIQUEIDENTIFIER   NOT NULL,
    [OrderId]                INT                IDENTITY (1, 1) NOT NULL,
    [RevisionNum]            TINYINT            CONSTRAINT [DF_Orders_RevisionNumber] DEFAULT ((0)) NOT NULL,
    [Date]                   DATETIME           CONSTRAINT [DF_Orders_Date] DEFAULT (getdate()) NOT NULL,
    [DueDate]                DATETIME           NOT NULL,
    [ShipDate]               DATETIME           NULL,
    [Status]                 TINYINT            CONSTRAINT [DF_Orders_Status] DEFAULT ((1)) NOT NULL,
    [IsOnlineOrder]          BIT                CONSTRAINT [DF_Orders_OnlineOrderFlag] DEFAULT ((1)) NOT NULL,
    [Num]                    AS                 (isnull(N'SO'+CONVERT([nvarchar](23),[OrderId],(0)),N'*** ERROR ***')),
    [PurchaseOrderNum]       VARCHAR (25)       NULL,
    [CustomerId]             UNIQUEIDENTIFIER   NOT NULL,
    [ShipToAddressId]        UNIQUEIDENTIFIER   NULL,
    [BillToAddressId]        UNIQUEIDENTIFIER   NULL,
    [ShippingType]           TINYINT            NOT NULL,
    [CreditCardApprovalCode] VARCHAR (15)       NULL,
    [SubTotal]               MONEY              CONSTRAINT [DF_Orders_SubTotal] DEFAULT ((0.00)) NOT NULL,
    [TaxAmt]                 MONEY              CONSTRAINT [DF_Orders_TaxAmt] DEFAULT ((0.00)) NOT NULL,
    [Freight]                MONEY              CONSTRAINT [DF_Orders_Freight] DEFAULT ((0.00)) NOT NULL,
    [TotalDue]               AS                 (isnull(([SubTotal]+[TaxAmt])+[Freight],(0))),
    [Comment]                NVARCHAR (500)     NULL,
    [CreatedBy]              VARCHAR (320)      NOT NULL,
    [CreatedOnUtc]           DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]              VARCHAR (320)      NULL,
    [UpdatedOnUtc]           DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Orders_DueDate] CHECK ([DueDate]>=[Date]),
    CONSTRAINT [CK_Orders_Freight] CHECK ([Freight]>=(0.00)),
    CONSTRAINT [CK_Orders_ShipDate] CHECK ([ShipDate]>=[Date] OR [ShipDate] IS NULL),
    CONSTRAINT [CK_Orders_Status] CHECK ([Status]>=(0) AND [Status]<=(8)),
    CONSTRAINT [CK_Orders_SubTotal] CHECK ([SubTotal]>=(0.00)),
    CONSTRAINT [CK_Orders_TaxAmt] CHECK ([TaxAmt]>=(0.00)),
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_OrdersAddresses_BillTo] FOREIGN KEY ([BillToAddressId]) REFERENCES [dbo].[OrderAddresses] ([Id]),
    CONSTRAINT [FK_OrdersAddresses_ShipTo] FOREIGN KEY ([ShipToAddressId]) REFERENCES [dbo].[OrderAddresses] ([Id]),
    CONSTRAINT [UIX_Orders] UNIQUE NONCLUSTERED ([Num] ASC)
);





