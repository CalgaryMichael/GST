USE [master]

IF EXISTS(select * from sys.databases where name = 'GST')
    DROP DATABASE GST

CREATE DATABASE[GST] ON PRIMARY
    (NAME = GST
    ,FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\GST.mdf'
    ,SIZE = 8192KB
    ,MAXSIZE = UNLIMITED)
LOG ON
    (NAME = N'GST_log'
    ,FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\GST_log.ldf'
    ,SIZE = 8192KB
    ,MAXSIZE = 2048MB)
GO

USE [GST]

IF OBJECT_ID('[BadgeHistory]', 'U') IS NOT NULL 
  DROP TABLE [BadgeHistory];

IF OBJECT_ID('[Person]', 'U') IS NOT NULL 
  DROP TABLE [Person];

IF OBJECT_ID('[BadgeBank]', 'U') IS NOT NULL 
  DROP TABLE [BadgeBank];
GO

CREATE TABLE [BadgeBank](
	[BadgeId]		int				NOT NULL	PRIMARY KEY,
	[BadgeName]		nvarchar(255),
	[BadgeSummary]	nvarchar(255),
	[BadgeCategory]	nvarchar(255),
	[BadgeGiveType]	nvarchar(255),
	[DateActivated]	datetime,
	[DateRetired]	nvarchar(255),
	[Notes]			nvarchar(255),
	[Imageaddress]	nvarchar(255)
);

CREATE TABLE [Person](
	[PersonId]		int				NOT NULL	PRIMARY KEY,
	[PersonType]	varchar(20),
	[PersonName]	varchar(50),
	[PersonEmail]	varchar(50),
	[AdminStatus]	varchar(20)
);

CREATE TABLE [BadgeHistory](
	[TransactionNum]	int				IDENTITY	NOT NULL	PRIMARY KEY,
	[BadgeId]			int				REFERENCES BadgeBank([BadgeId]),
	[GiverId]			int				REFERENCES Person([PersonId]),
	[StudentId]			int				REFERENCES Person([PersonId]),
	[TimeStamp]			DateTime,
	[Comment]			varchar(50)
);
GO