﻿CREATE TABLE [BadgeBank](
	[Badge_ID]			int				NOT NULL	PRIMARY KEY,
	[Badge_Name]		varchar(255),
	[Badge_Summary]		varchar(255),
	[Badge_Category]	varchar(255),
	[Badge_Give_Type]	varchar(255),
	[Date_Activated]	datetime,
	[Date_Retired]		datetime,
	[Notes]				varchar(255),
	[Image_Address]		varchar(255)
);

CREATE TABLE [Person](
	[Person_ID]		int				NOT NULL	PRIMARY KEY,
	[Person_Type]	varchar(20),
	[Person_Name]	varchar(50),
	[Person_Email]	varchar(50),
	[Admin_Status]	BIT,
);

CREATE TABLE [BadgeHistory](
	[Transaction_Num]	int				IDENTITY	NOT NULL	PRIMARY KEY,
	[Badge_ID]			int				REFERENCES BadgeBank([Badge_ID]),
	[Giver_ID]			int				REFERENCES Person([Person_ID]),
	[Student_ID]		int				REFERENCES Person([Person_ID]),
	[Time_Stamp]		DateTime,
	[Comment]			varchar(50),
	[Pos_X]				int,
	[Pos_Y]				int
);

CREATE TABLE [CoreRelation](
	[Relation_ID]		int				IDENTITY	NOT NULL	PRIMARY KEY,
	[Core_ID]			int				REFERENCES BadgeBank([Badge_ID]),
	[Competency_ID]		int				REFERENCES BadgeBank([Badge_ID]),
);