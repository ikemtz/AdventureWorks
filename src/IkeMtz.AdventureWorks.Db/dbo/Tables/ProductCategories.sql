CREATE TABLE [dbo].[ProductCategories] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Name]         NVARCHAR (50)      NOT NULL,
    [CreatedBy]     VARCHAR (320)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (320)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UIX_ProductCategories] UNIQUE NONCLUSTERED ([Name] ASC)
);

