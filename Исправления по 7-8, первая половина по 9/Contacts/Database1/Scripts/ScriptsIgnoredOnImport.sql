
CREATE DATABASE [TestDB]
GO
SET QUOTED_IDENTIFIER OFF;
GO
USE [TestDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO
INSERT INTO [dbo].[ContactType]
           ([Name])
     VALUES
           ('Phone'),
		   ('Email')
GO
INSERT INTO [dbo].[StatusType]
           ([Name])
     VALUES
           ('NotSet'),
		   ('Verified')
GO
INSERT INTO [dbo].[Cards]
           ([Name]
           ,[BranchId]
           ,[SynCode]
           ,[StatusTypeId])
     VALUES
           ('РЎР±РµСЂР±Р°РЅРє, Р±Р°РЅРєРѕРІСЃРєРѕРµ РѕС‚РґРµР»РµРЅРёРµ РЅР° СЃС‚СѓРґРµРЅС‡РµСЃРєРѕР№'
           ,54
           ,70221040444044
           ,2)
GO
INSERT INTO [dbo].[Contacts]
           ([Value]
           ,[CardId]
           ,[ContactTypeId])
     VALUES
           ('(234) 5674345'
           ,1
		   ,1)

GO
