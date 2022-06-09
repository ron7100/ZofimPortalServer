﻿USE [master]
GO

/****** Object:  Database [ZofimPortalDB]    Script Date: 31/10/2021 08:47:01 ******/
CREATE DATABASE [ZofimPortalDB]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZofimPortalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ZofimPortalDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ZofimPortalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ZofimPortalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ZofimPortalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ZofimPortalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ZofimPortalDB] SET  MULTI_USER 
GO

ALTER DATABASE [ZofimPortalDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ZofimPortalDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ZofimPortalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ZofimPortalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ZofimPortalDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ZofimPortalDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ZofimPortalDB] SET  READ_WRITE 
GO


USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Hanhaga]    Script Date: 31/10/2021 08:47:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hanhaga](
	[Name] [nvarchar](50) NOT NULL,
	[ShevetNumber] [int] NOT NULL,
	[GeneralArea] [nvarchar](50) NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Hanhaga] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Shevet]    Script Date: 31/10/2021 08:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shevet](
	[Name] [nvarchar](50) NOT NULL,
	[HanhagaID] [int] NOT NULL,
	[MembersAmount] [int] NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Shevet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Shevet]  WITH CHECK ADD  CONSTRAINT [FK_Shevet_Hanhaga] FOREIGN KEY([HanhagaID])
REFERENCES [dbo].[Hanhaga] ([ID])
GO

ALTER TABLE [dbo].[Shevet] CHECK CONSTRAINT [FK_Shevet_Hanhaga]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[User]    Script Date: 31/10/2021 08:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[email] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[personalID] [nvarchar](10) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_email] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 21/11/2021 08:29:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[RoleName] [nvarchar](50) NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Worker]    Script Date: 31/10/2021 08:47:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Worker](
	[ShevetID] [int] NULL,
	[RoleID] [int] NOT NULL,
	[HanhagaID] [int] NULL,
	[UserID] [int] NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Hanhaga] FOREIGN KEY([HanhagaID])
REFERENCES [dbo].[Hanhaga] ([ID])
GO

ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Hanhaga]
GO

ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Shevet] FOREIGN KEY([ShevetID])
REFERENCES [dbo].[Shevet] ([ID])
GO

ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Shevet]
GO

ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO

ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_User]
GO

ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO

ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Role]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[\]    Script Date: 31/10/2021 08:47:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parent](
	[ShevetID] [int] NULL,
	[UserID] [int] NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_Parent_Shevet] FOREIGN KEY([ShevetID])
REFERENCES [dbo].[Shevet] ([ID])
GO

ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_Parent_Shevet]
GO

ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_Parent_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO

ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_Parent_User]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Cadet]    Script Date: 31/10/2021 08:48:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cadet](
	[fName] [nvarchar](50) NOT NULL,
	[lName] [nvarchar](50) NOT NULL,
	[PersonalID] [nvarchar](50) NOT NULL,
	[ShevetID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Cadet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cadet]  WITH CHECK ADD  CONSTRAINT [FK_Cadet_Shevet] FOREIGN KEY([ShevetID])
REFERENCES [dbo].[Shevet] ([ID])
GO

ALTER TABLE [dbo].[Cadet] CHECK CONSTRAINT [FK_Cadet_Shevet]
GO

ALTER TABLE [dbo].[Cadet]  WITH CHECK ADD  CONSTRAINT [FK_Cadet_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO

ALTER TABLE [dbo].[Cadet] CHECK CONSTRAINT [FK_Cadet_Role]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Cadet_Parent]    Script Date: 31/10/2021 08:48:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cadet_Parent](
	[ParentID] [int] NOT NULL,
	[CadetID] [int] NOT NULL,
	CONSTRAINT [PK_Cadet_Parent] PRIMARY KEY CLUSTERED 
(
	[ParentID] ASC,
	[CadetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cadet_Parent]  WITH CHECK ADD  CONSTRAINT [FK_Cadet_Parent_Cadet] FOREIGN KEY([CadetID])
REFERENCES [dbo].[Cadet] ([ID])
GO

ALTER TABLE [dbo].[Cadet_Parent] CHECK CONSTRAINT [FK_Cadet_Parent_Cadet]
GO

ALTER TABLE [dbo].[Cadet_Parent]  WITH CHECK ADD  CONSTRAINT [FK_Cadet_Parent_Parent] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Parent] ([ID])
GO

ALTER TABLE [dbo].[Cadet_Parent] CHECK CONSTRAINT [FK_Cadet_Parent_Parent]
GO

USE [ZofimPortalDB]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 09/06/2022 23:02:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity](
	[Name] [nvarchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[RelevantClass] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[DiscountPercent] [int] NULL,
	[IsOpen] [int] NOT NULL,
	[ShevetID] [int] NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Shevet] FOREIGN KEY([ShevetID])
REFERENCES [dbo].[Shevet] ([ID])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Shevet]
GO

/****** Object:  Table [dbo].[ActivitiesHistory]    Script Date: 31/10/2021 08:48:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActivitiesHistory](
	[CadetID] [int] NOT NULL,
	[ActivityID] [int] NOT NULL,
	CONSTRAINT [PK_ActivitiesHistory] PRIMARY KEY CLUSTERED 
(
	[CadetID] ASC,
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActivitiesHistory]  WITH CHECK ADD  CONSTRAINT [FK_ActivitiesHistory_Cadet] FOREIGN KEY([CadetID])
REFERENCES [dbo].[Cadet] ([ID])
GO

ALTER TABLE [dbo].[ActivitiesHistory] CHECK CONSTRAINT [FK_ActivitiesHistory_Cadet]
GO

ALTER TABLE [dbo].[ActivitiesHistory]  WITH CHECK ADD  CONSTRAINT [FK_ActivitiesHistory_Activity] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Activity] ([ID])
GO

ALTER TABLE [dbo].[ActivitiesHistory] CHECK CONSTRAINT [FK_ActivitiesHistory_Activity]
GO

USE [ZofimPortalDB]
GO