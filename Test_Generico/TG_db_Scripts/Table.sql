
/********************************************************/
IF OBJECT_ID (N'[dbo].[TG_User]', N'U') IS NOT NULL 
	DROP TABLE [dbo].[TG_User];

CREATE TABLE [dbo].[TG_User] (
	[TG_User_Id] INT IDENTITY (1,1),
	[Name] VARCHAR(100) NOT NULL,
	[LastName] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[Password] VARCHAR(100) NOT NULL,
	[Active] bit NOT NULL

	CONSTRAINT [PK_User_Id] PRIMARY KEY ([TG_User_Id])
);
/********************************************************/