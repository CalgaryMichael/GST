IF OBJECT_ID('dbo.[BadgeBank]', 'U') IS NOT NULL 
  DROP TABLE dbo.[BadgeBank];
GO

CREATE TABLE [dbo].[BadgeBank](
	[Badge_ID]		int			IDENTITY			NOT NULL,
	[Give_Type]		varchar(20)						NOT NULL,
	[Active_Date]	Date							NOT NULL,
	[Expire_Date]	Date							NOT NULL,
	PRIMARY KEY ([Badge_ID])
);
GO

IF OBJECT_ID('dbo.[BadgeHistory]', 'U') IS NOT NULL 
  DROP TABLE dbo.[BadgeHistory];
GO

IF OBJECT_ID('dbo.[Person]', 'U') IS NOT NULL 
  DROP TABLE dbo.[Person];
GO

CREATE TABLE [dbo].[Person](
	[Person_ID]				varchar(20)						NOT NULL,
	[Person_Type]			varchar(20)						NOT NULL,
	[Person_Name]			varchar(50)						NOT NULL,
	[Person_Email]			varchar(50)						NOT NULL,
	[Admin_Status]			varchar(20)						NOT NULL,
	PRIMARY KEY ([Person_ID]),
);
GO

CREATE TABLE [dbo].[BadgeHistory](
	[Transaction_Num]		int			IDENTITY			NOT NULL,
	[Badge_ID]				int,								
	[ID_Giver]				varchar(20),						
	[Student_ID]			varchar(20),						
	[Time_Stamp]			Date							NOT NULL,
	[Comment]				varchar(50)						NOT NULL,
	constraint fk_BadgeID_BadgeHistory	FOREIGN KEY (Badge_ID) REFERENCES BadgeBank (Badge_ID),
	constraint fk_IDGiver_BadgeHistory	FOREIGN KEY (ID_Giver) REFERENCES Person (Person_ID),
	constraint fk_StudentID_BadgeHistory FOREIGN KEY (Student_ID) REFERENCES Person (Person_ID),
	PRIMARY KEY ([Transaction_Num]),
	
);
GO



