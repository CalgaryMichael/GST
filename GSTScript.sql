IF OBJECT_ID('dbo.[BadgeHistory]', 'U') IS NOT NULL 
  DROP TABLE dbo.[BadgeHistory];
GO

IF OBJECT_ID('dbo.[Person]', 'U') IS NOT NULL 
  DROP TABLE dbo.[Person];
GO

IF OBJECT_ID('dbo.[BadgeBank]', 'U') IS NOT NULL 
  DROP TABLE dbo.[BadgeBank];
GO

CREATE TABLE [dbo].[BadgeBank](
	[Badge_ID] varchar(10),
	[Badge_Name] nvarchar(255),
	[Badge_Summary] nvarchar(255),
	[Badge_Category] nvarchar(255),
	[Badge_Give_Type] nvarchar(255),
	[Date_Activated] datetime,
	[Date_Retired] nvarchar(255),
	[Notes] nvarchar(255),
	[Image_address] nvarchar(255)
	PRIMARY KEY ([Badge_ID]),
);
GO

CREATE TABLE [dbo].[Person](
	[Person_ID]				varchar(20)						NOT NULL,
	[Person_Type]			varchar(20),
	[Person_Name]			varchar(50),
	[Person_Email]			varchar(50),
	[Admin_Status]			varchar(20),
	PRIMARY KEY ([Person_ID]),
);
GO

CREATE TABLE [dbo].[BadgeHistory](
	[Transaction_Num]		int			IDENTITY			NOT NULL,
	[Badge_ID]				varchar(10),								
	[ID_Giver]				varchar(20),						
	[Student_ID]			varchar(20),						
	[Time_Stamp]			Date,
	[Comment]				varchar(50),
	constraint fk_BadgeID_BadgeHistory	FOREIGN KEY (Badge_ID) REFERENCES BadgeBank (Badge_ID),
	constraint fk_IDGiver_BadgeHistory	FOREIGN KEY (ID_Giver) REFERENCES Person (Person_ID),
	constraint fk_StudentID_BadgeHistory FOREIGN KEY (Student_ID) REFERENCES Person (Person_ID),
	PRIMARY KEY ([Transaction_Num]),
	
);
GO