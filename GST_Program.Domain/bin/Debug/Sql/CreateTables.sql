CREATE TABLE [Badge](
	[BadgeId]		int				NOT NULL	PRIMARY KEY,
	[BadgeName]		varchar(255),
	[BadgeSummary]	varchar(255),
	[BadgeCategory]	varchar(255),
	[BadgeGiveType]	varchar(255),
	[DateActivated]	datetime,
	[DateRetired]	datetime,
	[Notes]			varchar(255),
	[Imageaddress]	varchar(255)
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
	[BadgeId]			int				REFERENCES Badge([BadgeId]),
	[GiverId]			int				REFERENCES Person([PersonId]),
	[StudentId]			int				REFERENCES Person([PersonId]),
	[TimeStamp]			DateTime,
	[Comment]			varchar(50)
);