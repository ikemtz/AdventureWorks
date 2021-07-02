/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\dbo\Data\dbo.Clients.Table.sql
:r .\dbo\Data\dbo.ClientAddresses.Table.sql
:r .\dbo\Data\dbo.ProductCategories.Table.sql
:r .\dbo\Data\dbo.ProductModels.Table.sql
:r .\dbo\Data\dbo.Products.Table.sql
:r .\dbo\Data\dbo.SaleOrderAddresses.Table.sql
:r .\dbo\Data\dbo.SaleOrders.Table.sql
:r .\dbo\Data\dbo.SaleOrderDetails.Table.sql
