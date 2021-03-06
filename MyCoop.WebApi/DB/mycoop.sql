USE [master]
GO
/****** Object:  Database [mycoop]    Script Date: 14.09.2014 11:24:47 ******/
CREATE DATABASE [mycoop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mycoop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2\MSSQL\DATA\mycoop.mdf' , SIZE = 6208KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mycoop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2\MSSQL\DATA\mycoop_log.ldf' , SIZE = 6400KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  StoredProcedure [dbo].[DeleteBusinessProcess]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBusinessProcess]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.AttributeBusinessProcesses
	where BusinessProcessId = @id;

	delete from dbo.BusinessProcesses
	where Id = @id;

END

GO
/****** Object:  StoredProcedure [dbo].[DeleteComponent]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteComponent]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.DocumentTemplates
	SET ComponentId = NULL
	WHERE ComponentId = @id;

	delete from dbo.Components
	where Id = @id;

END

GO
/****** Object:  StoredProcedure [dbo].[DeleteDocumentTemplate]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDocumentTemplate]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.WorkspaceDocumentTemplates
	where DocumentTemplateId = @id;

	delete from dbo.DocumentTemplates
	where Id = @id;

END

GO
/****** Object:  StoredProcedure [dbo].[DeleteGroup]    Script Date: 14.09.2014 11:24:47 ******/
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
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.UserGroups
	where groupId = @id;

	delete from dbo.Groups
	where Id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteOrgUnit]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteOrgUnit]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.IncidentOrgUnits
	where OrgUnitId = @id;

	delete from dbo.OrgUnitUserPermissions
	where OrgUnitId = @id;

	delete from dbo.OrgUnitGroupPermissions
	where OrgUnitId = @id;

	delete from dbo.BusinessProcessAttributes
	where EXISTS(SELECT 1 FROM dbo.BusinessProcesses WHERE OrgUnitId = @id);

	delete from dbo.BusinessProcesses
	where OrgUnitId = @id;

	delete from dbo.OrgUnits
	where ParentId = @id;

	delete from dbo.OrgUnits
	where Id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 14.09.2014 11:24:47 ******/
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
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from dbo.UserGroups
	where userId = @id;

	delete from dbo.Users
	where Id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteWorkspaceTemplate]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteWorkspaceTemplate]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.OrgUnits
	SET WorkspaceTemplateId = NULL
	WHERE WorkspaceTemplateId = @id;

    delete from dbo.WorkspaceDocumentTemplates
	where WorkspaceTemplateId = @id;

	delete from dbo.WorkspaceTemplateComponents
	where WorkspaceTemplateId = @id;

	delete from dbo.WorkspaceTemplates
	where Id = @id;
END

GO
/****** Object:  Table [dbo].[AttributeBusinessProcesses]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeBusinessProcesses](
	[BusinessProcessId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_AttributeBusinessProcesses] PRIMARY KEY CLUSTERED 
(
	[BusinessProcessId] ASC,
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttributeTypes]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttributeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessProcessAttributes]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessProcessAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AttributeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessProcessAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessProcesses]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessProcesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[OrgUnitId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
 CONSTRAINT [PK_BusinessProcesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Components]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentTemplates]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Reference] [nvarchar](max) NOT NULL,
	[Purpose] [nvarchar](max) NOT NULL,
	[PagesCount] [int] NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[ComponentId] [int] NULL,
 CONSTRAINT [PK_DocumentTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModifiedByUserId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncidentOrgUnits]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentOrgUnits](
	[IncidentId] [int] NOT NULL,
	[OrgUnitId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_IncidentOrgUnits] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC,
	[OrgUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incidents]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[FacilityType] [int] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[Duration] [bigint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncidentUsers]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentUsers](
	[IncidentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_IncidentUsers] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnitGroupPermissions]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnitGroupPermissions](
	[OrgUnitId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[PermissionLevelId] [int] NOT NULL,
 CONSTRAINT [PK_OrgUnitGroupPermissions] PRIMARY KEY CLUSTERED 
(
	[OrgUnitId] ASC,
	[GroupId] ASC,
	[PermissionLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnits]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[WorkspaceTemplateId] [int] NULL,
 CONSTRAINT [PK_OrgUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnitUserPermissions]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnitUserPermissions](
	[OrgUnitId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionLevelId] [int] NOT NULL,
 CONSTRAINT [PK_OrgUnitUserPermissions] PRIMARY KEY CLUSTERED 
(
	[OrgUnitId] ASC,
	[UserId] ASC,
	[PermissionLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PermissionLevels]    Script Date: 14.09.2014 11:24:47 ******/
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
/****** Object:  Table [dbo].[SysEvents]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[UserId] [int] NULL,
	[TransactionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SysEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
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
/****** Object:  Table [dbo].[WorkspaceDocumentTemplates]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceDocumentTemplates](
	[WorkspaceTemplateId] [int] NOT NULL,
	[DocumentTemplateId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_WorkspaceDocumentTemplates] PRIMARY KEY CLUSTERED 
(
	[WorkspaceTemplateId] ASC,
	[DocumentTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkspaceTemplateComponents]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceTemplateComponents](
	[WorkspaceTemplateId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_WorkspaceTemplateComponents] PRIMARY KEY CLUSTERED 
(
	[WorkspaceTemplateId] ASC,
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkspaceTemplates]    Script Date: 14.09.2014 11:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[ModifiedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_WorkspaceTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Components] ON 

INSERT [dbo].[Components] ([Id], [Name]) VALUES (1, N'BIA')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (4, N'BCP')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (5, N'RA')
SET IDENTITY_INSERT [dbo].[Components] OFF
SET IDENTITY_INSERT [dbo].[DocumentTemplates] ON 

INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (12, N'ISO22031:2012 Gap Assessment', N'MC00001', N'To assess the level of compliance of an organisation against the ISO 22301 standard', 5, N'/Content/DocumentTemplates/BankOfAmericaCOOP_825d0b40-4263-4932-bbba-22e3d0044ea8.docx', 1)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (13, N'Business Continuity Context Requirements and Scope', N'MC04001', N'To set out the organisational context of the BCMS. It describes what the organisation does, how it does it, what factors influence the way it operates and the reasons for the definition of the scope of the BCMS', 9, N'/Content/DocumentTemplates/COOPPlanTemplate_8e12c38b-e042-471d-a6cf-5927e5ee4092.doc', 1)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (14, N'Legal and Regulatory Requirements Procedure', N'MC04002', N'Describes how the applicable legal and regulatory requirements relevant to the BCMS will be identified, accessed, assessed, documented, maintained and communicated', 5, N'/Content/DocumentTemplates/Final_COOP_Completed_Example_v1_a3cce349-64db-44f4-9712-917c75bec098.doc', 4)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (15, N'Business Continuity Policy', N'MC05001', N'The Business Continuity policy acts as the root “Quality Manual” of the Business Continuity Management System (BCMS) and must be approved by Top Management (defined as the “person or group of people who direct and control the organisation at the highest level”) as evidence of their commitment', 10, N'/Content/DocumentTemplates/coop_plan_template_instructions_57ae12dc-4b43-45e2-afaa-5b1363884674.doc', 4)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (16, N'Roles Responsibilities and Authorities', N'MC05002', N'To define the roles, responsibilities and authorities within the BCMS', 2, N'/Content/DocumentTemplates/major_disaster_requests_4608eb85-4beb-4d67-8f5c-f3c7007eeabd.doc', 5)
SET IDENTITY_INSERT [dbo].[DocumentTemplates] OFF
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (4, N'Engineering', N'312', CAST(0x07D8029B3796F5380B AS DateTime2), CAST(0x070E2D703D5BDA380B AS DateTime2), 8, 1)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (5, N'Sales', N'Group for ...', CAST(0x07D050AF4196F5380B AS DateTime2), CAST(0x070DF2E91A5CDA380B AS DateTime2), 8, 1)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (7, N'Security', N'Another description', CAST(0x0786B9E94C96F5380B AS DateTime2), CAST(0x073788FE588BDB380B AS DateTime2), 8, 8)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (8, N'IT Tech', N'Technical Staff', CAST(0x0773F9A112A9DB380B AS DateTime2), CAST(0x0773F9A112A9DB380B AS DateTime2), 8, 8)
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Incidents] ON 

INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (1, N'Test incident', 47.216667, 38.916666999999961, N'Taganrog', 1, 1, 1, CAST(0x070000000000000000 AS DateTime2), 0, N'Fire')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (2, N'Sample incident', 42.3584308, -71.0597732, N'Boston', 3, 2, 3, CAST(0x070000000000F2380B AS DateTime2), 25200000, N'123123')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (3, N'Worcester Fire Depot', 42.2625932, -71.8022934, N'worchester, massachusetts', 1, 1, 1, CAST(0x07800C6F4596F5380B AS DateTime2), 0, N'Explosions were heard.')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (4, N'New York City Train Derail', 40.7127837, -74.005941300000018, N'new york city, ny', 2, 3, 2, CAST(0x0780E719A597F5380B AS DateTime2), 0, N'Test')
SET IDENTITY_INSERT [dbo].[Incidents] OFF
INSERT [dbo].[OrgUnitGroupPermissions] ([OrgUnitId], [GroupId], [PermissionLevelId]) VALUES (1016, 8, 4)
INSERT [dbo].[OrgUnitGroupPermissions] ([OrgUnitId], [GroupId], [PermissionLevelId]) VALUES (1027, 4, 1)
INSERT [dbo].[OrgUnitGroupPermissions] ([OrgUnitId], [GroupId], [PermissionLevelId]) VALUES (1029, 4, 4)
SET IDENTITY_INSERT [dbo].[OrgUnits] ON 

INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1016, N'Bank of America', N'Washington DC 20004', CAST(0x07DB659ACE9BE1380B AS DateTime2), CAST(0x079E4CB99F41F7380B AS DateTime2), 10, NULL, 38.8951382, -77.0226217, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1017, N'Northeast', N'New York', CAST(0x0711E4E6169CE1380B AS DateTime2), CAST(0x07E48B09BB95F5380B AS DateTime2), 1, 1016, 40.7127837, -74.005941300000018, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1018, N'SouthEast', N'Boston', CAST(0x0714541D4B9CE1380B AS DateTime2), CAST(0x07268EDEB395F5380B AS DateTime2), 1, 1016, 42.3584308, -71.0597732, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1019, N'NorthWest', N'Chicago', CAST(0x07DB096A77A5E1380B AS DateTime2), CAST(0x0773632D6695F5380B AS DateTime2), 11, 1016, 41.8781136, -87.629798199999982, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1020, N'World Bank', N'22182', CAST(0x072AC07BE3A6E1380B AS DateTime2), CAST(0x0795AA1BEB95F5380B AS DateTime2), 8, NULL, 38.9457197, -77.297978199999989, 2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1021, N'SouthWest', N'lewes, de', CAST(0x07EDD53CBFA8E1380B AS DateTime2), CAST(0x078E0C0CD295F5380B AS DateTime2), 8, 1016, 38.7745565, -75.139349799999991, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1027, N'Marketing', N'Boston', CAST(0x07AE4B2C9B47EE380B AS DateTime2), CAST(0x075FB1540995F5380B AS DateTime2), 8, 1020, 42.3584308, -71.0597732, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1028, N'Engineering', N'Boston', CAST(0x07AFCDA40948EE380B AS DateTime2), CAST(0x0746E64B1A95F5380B AS DateTime2), 8, 1020, 42.3584308, -71.0597732, 3)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1029, N'Design', N'Boston', CAST(0x0711F1629248EE380B AS DateTime2), CAST(0x07EBE2952695F5380B AS DateTime2), 8, 1020, 42.3584308, -71.0597732, 3)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1030, N'Recovery', N'salisbury, md', CAST(0x0774CE640698F5380B AS DateTime2), CAST(0x0726254A2098F5380B AS DateTime2), 8, 1027, 38.3606736, -75.599369200000012, 1)
SET IDENTITY_INSERT [dbo].[OrgUnits] OFF
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1016, 8, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1016, 9, 2)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1027, 1, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1027, 8, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1028, 1, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1029, 1, 1)
SET IDENTITY_INSERT [dbo].[PermissionLevels] ON 

INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (1, N'System Administrator')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (2, N'Workspace Administrator')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (3, N'Contributor')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (4, N'Approver')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (5, N'Browser')
SET IDENTITY_INSERT [dbo].[PermissionLevels] OFF
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (1, 4, CAST(0x077E079D945EDA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (1, 5, CAST(0x07384219B192DA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (1, 7, CAST(0x07CE5E8F908EDB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (7, 5, CAST(0x075163BA4396DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (8, 4, CAST(0x073CC9454A6FDA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (8, 7, CAST(0x07F043C8768BDB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (11, 4, CAST(0x07585106FEA4DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (12, 4, CAST(0x077BC95E79A8DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (12, 7, CAST(0x0769A25E79A8DB380B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (1, N'mr.gusev.k@gmail.com', N'Johnny', N'Carson', N'0ad0c86f73998b52a047127cff79d27e', 1, 1, CAST(0x070000000000D9380B AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (7, N'testuser@testuser.com', N'Tammy', N'Blooms', N'1e5e87bd07d5f42098176c65b1104855', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (8, N'tmiller@google.com', N'Tom', N'Miller', N'95efb63a9bb3fec658354a879b34501b', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (9, N'mycoopdev@gmail.com', N'James', N'Smith', N'202400f12056bfa3117fce28d79a23d4', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (10, N'jcoop@google.com', N'James', N'Cahit', N'977aab2f2dca35f5b4161ba930f173e9', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (11, N'jcash@google.com', N'Johnny', N'Cash', N'e88a17b2fb4c317a0ce295f44356a92a', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (12, N'jw@google.com', N'Wishbone', N'Johnson', N'325a3d5566f9c90c0c8e3c84f495500c', 0, 1, CAST(0x070000000000000000 AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 12, CAST(0x074235F60745EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 13, CAST(0x0753F1150845EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 15, CAST(0x07DF13180845EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 16, CAST(0x07A6E8190845EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (2, 13, CAST(0x072717340C45EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (2, 15, CAST(0x072717340C45EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 12, CAST(0x07FD96891245EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 13, CAST(0x0725E5891245EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 16, CAST(0x076610881245EE380B AS DateTime2))
SET IDENTITY_INSERT [dbo].[WorkspaceTemplates] ON 

INSERT [dbo].[WorkspaceTemplates] ([Id], [Name], [CreationTime], [ModificationTime], [CreatedByUserId], [ModifiedByUserId]) VALUES (1, N'Sample workspace template', CAST(0x070000000000E5380B AS DateTime2), CAST(0x0779CFC40745EE380B AS DateTime2), 1, 1)
INSERT [dbo].[WorkspaceTemplates] ([Id], [Name], [CreationTime], [ModificationTime], [CreatedByUserId], [ModifiedByUserId]) VALUES (2, N'Test workspace template', CAST(0x072312A39F9FE5380B AS DateTime2), CAST(0x07A3ADFE0B45EE380B AS DateTime2), 1, 1)
INSERT [dbo].[WorkspaceTemplates] ([Id], [Name], [CreationTime], [ModificationTime], [CreatedByUserId], [ModifiedByUserId]) VALUES (3, N'Sample workspace 2', CAST(0x07B2C07DBA00E8380B AS DateTime2), CAST(0x0744EB4D1245EE380B AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[WorkspaceTemplates] OFF
ALTER TABLE [dbo].[AttributeBusinessProcesses]  WITH CHECK ADD  CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcessAttributes] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[BusinessProcessAttributes] ([Id])
GO
ALTER TABLE [dbo].[AttributeBusinessProcesses] CHECK CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcessAttributes]
GO
ALTER TABLE [dbo].[AttributeBusinessProcesses]  WITH CHECK ADD  CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcesses] FOREIGN KEY([BusinessProcessId])
REFERENCES [dbo].[BusinessProcesses] ([Id])
GO
ALTER TABLE [dbo].[AttributeBusinessProcesses] CHECK CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcesses]
GO
ALTER TABLE [dbo].[BusinessProcessAttributes]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProcessAttributes_AttributeTypes] FOREIGN KEY([AttributeTypeId])
REFERENCES [dbo].[AttributeTypes] ([Id])
GO
ALTER TABLE [dbo].[BusinessProcessAttributes] CHECK CONSTRAINT [FK_BusinessProcessAttributes_AttributeTypes]
GO
ALTER TABLE [dbo].[BusinessProcesses]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProcesses_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[BusinessProcesses] CHECK CONSTRAINT [FK_BusinessProcesses_OrgUnits]
GO
ALTER TABLE [dbo].[DocumentTemplates]  WITH CHECK ADD  CONSTRAINT [FK_DocumentTemplates_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([Id])
GO
ALTER TABLE [dbo].[DocumentTemplates] CHECK CONSTRAINT [FK_DocumentTemplates_Components]
GO
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
ALTER TABLE [dbo].[IncidentOrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_IncidentOrgUnits_Incidents] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incidents] ([Id])
GO
ALTER TABLE [dbo].[IncidentOrgUnits] CHECK CONSTRAINT [FK_IncidentOrgUnits_Incidents]
GO
ALTER TABLE [dbo].[IncidentOrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_IncidentOrgUnits_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[IncidentOrgUnits] CHECK CONSTRAINT [FK_IncidentOrgUnits_OrgUnits]
GO
ALTER TABLE [dbo].[IncidentUsers]  WITH CHECK ADD  CONSTRAINT [FK_IncidentUsers_Incidents] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incidents] ([Id])
GO
ALTER TABLE [dbo].[IncidentUsers] CHECK CONSTRAINT [FK_IncidentUsers_Incidents]
GO
ALTER TABLE [dbo].[IncidentUsers]  WITH CHECK ADD  CONSTRAINT [FK_IncidentUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[IncidentUsers] CHECK CONSTRAINT [FK_IncidentUsers_Users]
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitGroupPermissions_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions] CHECK CONSTRAINT [FK_OrgUnitGroupPermissions_Groups]
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitGroupPermissions_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions] CHECK CONSTRAINT [FK_OrgUnitGroupPermissions_OrgUnits]
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitGroupPermissions_PermissionLevels] FOREIGN KEY([PermissionLevelId])
REFERENCES [dbo].[PermissionLevels] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions] CHECK CONSTRAINT [FK_OrgUnitGroupPermissions_PermissionLevels]
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
ALTER TABLE [dbo].[OrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnits_WorkspaceTemplates] FOREIGN KEY([WorkspaceTemplateId])
REFERENCES [dbo].[WorkspaceTemplates] ([Id])
GO
ALTER TABLE [dbo].[OrgUnits] CHECK CONSTRAINT [FK_OrgUnits_WorkspaceTemplates]
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitUserPermissions_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions] CHECK CONSTRAINT [FK_OrgUnitUserPermissions_OrgUnits]
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitUserPermissions_PermissionLevels] FOREIGN KEY([PermissionLevelId])
REFERENCES [dbo].[PermissionLevels] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions] CHECK CONSTRAINT [FK_OrgUnitUserPermissions_PermissionLevels]
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitUserPermissions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions] CHECK CONSTRAINT [FK_OrgUnitUserPermissions_Users]
GO
ALTER TABLE [dbo].[SysEvents]  WITH CHECK ADD  CONSTRAINT [FK_SysEvents_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SysEvents] CHECK CONSTRAINT [FK_SysEvents_Users]
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
ALTER TABLE [dbo].[WorkspaceDocumentTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceDocumentTemplates_DocumentTemplates] FOREIGN KEY([DocumentTemplateId])
REFERENCES [dbo].[DocumentTemplates] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates] CHECK CONSTRAINT [FK_WorkspaceDocumentTemplates_DocumentTemplates]
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceDocumentTemplates_WorkspaceTemplates] FOREIGN KEY([WorkspaceTemplateId])
REFERENCES [dbo].[WorkspaceTemplates] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates] CHECK CONSTRAINT [FK_WorkspaceDocumentTemplates_WorkspaceTemplates]
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplateComponents_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents] CHECK CONSTRAINT [FK_WorkspaceTemplateComponents_Components]
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplateComponents_WorkspaceTemplates] FOREIGN KEY([WorkspaceTemplateId])
REFERENCES [dbo].[WorkspaceTemplates] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents] CHECK CONSTRAINT [FK_WorkspaceTemplateComponents_WorkspaceTemplates]
GO
ALTER TABLE [dbo].[WorkspaceTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplates_Users] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplates] CHECK CONSTRAINT [FK_WorkspaceTemplates_Users]
GO
ALTER TABLE [dbo].[WorkspaceTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplates_Users1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplates] CHECK CONSTRAINT [FK_WorkspaceTemplates_Users1]
GO
USE [master]
GO
ALTER DATABASE [mycoop] SET  READ_WRITE 
GO
