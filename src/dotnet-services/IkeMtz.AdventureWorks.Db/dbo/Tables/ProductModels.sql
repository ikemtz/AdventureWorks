CREATE TABLE [dbo].[ProductModels] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Name]         NVARCHAR (50)      NOT NULL,
    [Description]  NVARCHAR (400)     NULL,
    [CreatedBy]    VARCHAR (50)       NOT NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) NOT NULL,
    [UpdatedBy]    VARCHAR (50)       NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_ProductModels] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UIX_ProductModels] UNIQUE NONCLUSTERED ([Name] ASC)
);



