﻿/*
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
:r .\dbo\Data\dbo.SalesAgents.Table.sql
:r .\dbo\Data\dbo.Customers.Table.sql
:r .\dbo\Data\dbo.CustomerAddresses.Table.sql
:r .\dbo\Data\dbo.ProductCategories.Table.sql
:r .\dbo\Data\dbo.ProductModels.Table.sql
:r .\dbo\Data\dbo.Products.Table.sql
:r .\dbo\Data\dbo.OrderAddresses.Table.sql
:r .\dbo\Data\dbo.Orders.Table.sql
:r .\dbo\Data\dbo.OrderLineItems.Table.sql
