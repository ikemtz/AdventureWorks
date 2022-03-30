CREATE TABLE [dbo].[ProductModels] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Name]         NVARCHAR (50)      NOT NULL,
    [Description]  NVARCHAR (500)     NULL,
    [CreatedBy]     VARCHAR (320)       NOT NULL,
    [CreatedOnUtc]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]     VARCHAR (320)       NULL,
    [UpdatedOnUtc]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_ProductModels] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UIX_ProductModels] UNIQUE NONCLUSTERED ([Name] ASC)
);



