USE [master]
GO
/****** Object:  Database [mycoop]    Script Date: 13.08.2014 2:24:51 ******/
CREATE DATABASE [mycoop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mycoop', FILENAME = N'F:\arcsight\mycoop.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mycoop_log', FILENAME = N'F:\arcsight\mycoop_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [mycoop] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mycoop].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [mycoop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mycoop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mycoop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mycoop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mycoop] SET ARITHABORT OFF 
GO
ALTER DATABASE [mycoop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mycoop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [mycoop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mycoop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mycoop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mycoop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mycoop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mycoop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mycoop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mycoop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mycoop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mycoop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mycoop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mycoop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mycoop] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [mycoop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mycoop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [mycoop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mycoop] SET RECOVERY FULL 
GO
ALTER DATABASE [mycoop] SET  MULTI_USER 
GO
ALTER DATABASE [mycoop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mycoop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mycoop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mycoop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [mycoop]
GO
/****** Object:  StoredProcedure [dbo].[DeleteGroup]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGroup]
	-- Add the parameters for the stored procedure here
	@groupId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.UserGroups
	where groupId = @groupId;

	delete from dbo.Groups
	where Id = @groupId;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@userId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from dbo.UserGroups
	where userId = @userId;

	delete from dbo.Users
	where Id = @userId;
END

GO
/****** Object:  Table [dbo].[Companies]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PrimaryKey_0c8af8a8-f8d1-fd2e-8ab2-26fc84b8aab3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedByUserId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnits]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
 CONSTRAINT [PK_OrgUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PermissionLevels]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PermissionLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysEvents]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_SysEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysEventTypes]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysEventTypes](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SysEventTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.08.2014 2:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[TypeId] [int] NOT NULL,
	[PermissionLevelId] [int] NOT NULL,
	[LastAcitve] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModifiedDate], [CreatedDate], [ModifiedByUserId], [CreatedByUserId]) VALUES (4, N'Test Group', N'312', CAST(0x07FA8B5C948FDA380B AS DateTime2), CAST(0x070E2D703D5BDA380B AS DateTime2), 1, 1)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModifiedDate], [CreatedDate], [ModifiedByUserId], [CreatedByUserId]) VALUES (5, N'Test group 2', N'Group for testing', CAST(0x073A64D64296DB380B AS DateTime2), CAST(0x070DF2E91A5CDA380B AS DateTime2), 7, 1)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModifiedDate], [CreatedDate], [ModifiedByUserId], [CreatedByUserId]) VALUES (7, N'New test group', N'Another description', CAST(0x075E291DCD8CDB380B AS DateTime2), CAST(0x073788FE588BDB380B AS DateTime2), 1, 8)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModifiedDate], [CreatedDate], [ModifiedByUserId], [CreatedByUserId]) VALUES (8, N'IT Tech', N'Technical Staff', CAST(0x0773F9A112A9DB380B AS DateTime2), CAST(0x0773F9A112A9DB380B AS DateTime2), 8, 8)
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[OrgUnits] ON 

INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1, N'vasja', N'qwrqw', CAST(0x07126A818FBFDF380B AS DateTime2), CAST(0x071A94B216BBE0380B AS DateTime2), 1, 1, 77.55, 5.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (2, N'sfasf', N'qwrqw', CAST(0x079FCE2298BFDF380B AS DateTime2), CAST(0x079FCE2298BFDF380B AS DateTime2), 1, 1, 0, 0)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1003, N'sfasf', N'qwrqw', CAST(0x0746C76263ADE0380B AS DateTime2), CAST(0x0746C76263ADE0380B AS DateTime2), 1, 1, 54.55, 1.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1010, N'sfasf', N'qwrqw', CAST(0x0758F5DCF1B0E0380B AS DateTime2), CAST(0x0758F5DCF1B0E0380B AS DateTime2), 1, 1, 54.55, 1.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1011, N'sfasf', N'qwrqw', CAST(0x07A0DC3F94B4E0380B AS DateTime2), CAST(0x07A0DC3F94B4E0380B AS DateTime2), 1, 1, 54.55, 1.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1012, N'sfasf', N'qwrqw', CAST(0x07838E0952B6E0380B AS DateTime2), CAST(0x07838E0952B6E0380B AS DateTime2), 1, 1, 54.55, 1.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1013, N'sfasf', N'qwrqw', CAST(0x07B5AAB392B9E0380B AS DateTime2), CAST(0x07B5AAB392B9E0380B AS DateTime2), 1, 1, 54.55, 1.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1014, N'sfasf', N'qwrqw', CAST(0x07C5767395B9E0380B AS DateTime2), CAST(0x07C5767395B9E0380B AS DateTime2), 1, 1, 54.55, 1.2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng]) VALUES (1015, N'sfasf', N'qwrqw', CAST(0x07E290FA10BBE0380B AS DateTime2), CAST(0x07E290FA10BBE0380B AS DateTime2), 1, 1, 54.55, 1.2)
SET IDENTITY_INSERT [dbo].[OrgUnits] OFF
SET IDENTITY_INSERT [dbo].[PermissionLevels] ON 

INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (1, N'System Administrator')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (2, N'Workspace Administrator')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (3, N'Contributor')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (4, N'Approver')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (5, N'Browser')
SET IDENTITY_INSERT [dbo].[PermissionLevels] OFF
INSERT [dbo].[SysEventTypes] ([Id], [Name], [Description]) VALUES (1, N'Error', N'Error')
INSERT [dbo].[SysEventTypes] ([Id], [Name], [Description]) VALUES (2, N'Info', N'Info')
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (1, 4, CAST(0x077E079D945EDA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (1, 5, CAST(0x07384219B192DA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (1, 7, CAST(0x07CE5E8F908EDB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (7, 5, CAST(0x075163BA4396DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (8, 4, CAST(0x073CC9454A6FDA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (8, 7, CAST(0x07F043C8768BDB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (11, 4, CAST(0x07585106FEA4DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (12, 4, CAST(0x077BC95E79A8DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreatedDate]) VALUES (12, 7, CAST(0x0769A25E79A8DB380B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (1, N'mr.gusev.k@gmail.com', N'Kirill', N'Gusev', N'0ad0c86f73998b52a047127cff79d27e', 1, 1, CAST(0x070000000000D9380B AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (7, N'testuser@testuser.com', N'Test', N'User', N'1e5e87bd07d5f42098176c65b1104855', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (8, N'tmiller@google.com', N'Tom', N'Miller', N'95efb63a9bb3fec658354a879b34501b', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (9, N'mycoopdev@gmail.com', N'James', N'Smith', N'202400f12056bfa3117fce28d79a23d4', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (10, N'jcoop@google.com', N'James', N'Cahit', N'977aab2f2dca35f5b4161ba930f173e9', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (11, N'jcash@google.com', N'Johnny', N'Cash', N'e88a17b2fb4c317a0ce295f44356a92a', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (12, N'jw@google.com', N'Wishbone', N'Johnson', N'325a3d5566f9c90c0c8e3c84f495500c', 0, 1, CAST(0x070000000000000000 AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Users] FOREIGN KEY([ModifiedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Users]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Users1] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Users1]
GO
ALTER TABLE [dbo].[OrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnits_OrgUnits] FOREIGN KEY([ParentId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[OrgUnits] CHECK CONSTRAINT [FK_OrgUnits_OrgUnits]
GO
ALTER TABLE [dbo].[OrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnits_Users] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OrgUnits] CHECK CONSTRAINT [FK_OrgUnits_Users]
GO
ALTER TABLE [dbo].[SysEvents]  WITH CHECK ADD  CONSTRAINT [FK_SysEvents_SysEventTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[SysEventTypes] ([Id])
GO
ALTER TABLE [dbo].[SysEvents] CHECK CONSTRAINT [FK_SysEvents_SysEventTypes]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Groups]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PermissionLevels] FOREIGN KEY([PermissionLevelId])
REFERENCES [dbo].[PermissionLevels] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PermissionLevels]
GO
USE [master]
GO
ALTER DATABASE [mycoop] SET  READ_WRITE 
GO
