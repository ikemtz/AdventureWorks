IF NOT EXISTS (SELECT 1 FROM [dbo].[SalesAgents])
BEGIN
  SET IDENTITY_INSERT [dbo].[SalesAgents] ON 
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10000, N'David Bowie', N'adventure-works\david8')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10001, N'Garrett Morris', N'adventure-works\garrett1')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10002, N'Jae Crowder', N'adventure-works\jae0')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10003, N'Jillian Hervey', N'adventure-works\jillian0')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10004, N'José Clemente Orozco', N'adventure-works\josé1')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10005, N'Linda McCartney', N'adventure-works\linda3')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10006, N'Michael J Fox', N'adventure-works\michael9')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10007, N'Pamela Ander', N'adventure-works\pamela0')
  INSERT [dbo].[SalesAgents] ([Id], [Name], [LoginId]) VALUES (10008, N'Shu Qi', N'adventure-works\shu0')
  SET IDENTITY_INSERT [dbo].[SalesAgents] OFF
END
