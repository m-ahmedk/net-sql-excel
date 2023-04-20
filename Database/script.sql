CREATE DATABASE UserManagementSystem;
GO

USE UserManagementSystem;
GO

CREATE TABLE [dbo].[AppUser](
	[UserID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FirstName] [varchar](200) NULL,
	[LastName] [varchar](200) NULL,
	[BirthDate] [datetime] NULL,
	[Email] [varchar](200) NULL,
	[Phone] [varchar](200) NULL,
	[Zipcode] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_MobileUserIdentity] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[AppUser]
           ([FirstName]
           ,[LastName]
           ,[BirthDate]
           ,[Email]
           ,[Phone]
           ,[Zipcode]
           ,[CreatedAt])
     VALUES
           ('Muhammad Ahmed Villa',
           'Khan', 
           '1995-03-12 00:00:00.000',
           'm.ahmedk287@gmail.com',
           '+923418380518',
           '',
           getDate())
GO

CREATE TABLE [dbo].[Employer](
	[EmployerId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](500) NULL,
	[createdOn] [datetime] NULL,
 CONSTRAINT [PK_Employer] PRIMARY KEY CLUSTERED 
(
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Employer]
           ([Name]
           ,[createdOn])
     VALUES
           ('ABC LLC',
           getdate())
GO

CREATE TABLE [dbo].[AppUser_Employer](
	[UserId] [int] NOT NULL,
	[EmployerId] [int] NOT NULL,
 CONSTRAINT [PK_AppUser_Employer] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AppUser_Employer]  WITH NOCHECK ADD  CONSTRAINT [AppUser_Employer_AppUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUser] ([UserID])
GO

ALTER TABLE [dbo].[AppUser_Employer] CHECK CONSTRAINT [AppUser_Employer_AppUser]
GO

ALTER TABLE [dbo].[AppUser_Employer]  WITH NOCHECK ADD  CONSTRAINT [AppUser_Employer_Employer] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employer] ([EmployerId])
GO

ALTER TABLE [dbo].[AppUser_Employer] CHECK CONSTRAINT [AppUser_Employer_Employer]
GO

INSERT INTO [dbo].[AppUser_Employer]
           ([UserId]
           ,[EmployerId])
     VALUES
           (<UserId, int,>
           ,<EmployerId, int,>)
GO

