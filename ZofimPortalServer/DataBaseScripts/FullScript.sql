USE [master]
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

/****** Object:  Table [dbo].[Parent]    Script Date: 31/10/2021 08:47:54 ******/
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
	[class] [nvarchar](50) NOT NULL,
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
	[CadetsAmount] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[DiscountPercent] [int] NULL,
	[IsOpen] [int] NOT NULL,
	[ShevetID] [int] NOT NULL,
	[HanhagaID] [int] NOT NULL,
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

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Hanhaga] FOREIGN KEY([HanhagaID])
REFERENCES [dbo].[Hanhaga] ([ID])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Hanhaga]
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

USE ZofimPortalDB
INSERT INTO Hanhaga
VALUES ('איילון', 20, 'מרכז', 1),
	   ('דן', 13, 'מרכז', 2),
	   ('דרום', 22, 'דרום', 3),
	   ('דרור', 9, 'מרכז', 4),
	   ('החוף', 17, 'מרכז', 5),
	   ('החורש', 13, 'מרכז', 6),
	   ('הצוק', 11, 'מרכז', 7),
	   ('השחר', 11, 'מרכז', 8),
	   ('חיפה', 16, 'צפון', 9),
	   ('יהודה', 15, 'מרכז', 10),
	   ('ירושלים', 15, 'מרכז', 11),
	   ('צפון', 20, 'צפון', 12),
	   ('רמת גן', 9, 'מרכז', 13),
	   ('שורק', 19, 'דרום', 14),
	   ('תל אביב יפו', 21, 'מרכז', 15)

INSERT INTO Shevet
VALUES ('אופק', 1, 300, 1),
	   ('אחווה', 1, 300, 2),
	   ('אייל', 1, 300, 3),
	   ('איתן', 1, 300, 4),
	   ('אמיר', 1, 300, 5),
	   ('ארבל', 1, 300, 6),
	   ('אתגר', 1, 300, 7),
	   ('דגן', 1, 300, 8),
	   ('דרור', 1, 300, 9),
	   ('יובל', 1, 300, 10),
	   ('לביא', 1, 300, 11),
	   ('להב', 1, 300, 12),
	   ('לפיד', 1, 300, 13),
	   ('משמר דוד', 1, 300, 14),
	   ('ניר', 1, 300, 15),
	   ('נעלה', 1, 300, 16),
	   ('סופה', 1, 300, 17),
	   ('עמית', 1, 300, 18),
	   ('ראם', 1, 300, 19),
	   ('תבור', 1, 300, 20),
	   ('און', 2, 300, 21),
	   ('ברק', 2, 300, 22),
	   ('גבעתיים', 2, 300, 23),
	   ('גילעד', 2, 300, 24),
	   ('גל', 2, 300, 25),
	   ('גנים', 2, 300, 26),
	   ('דור', 2, 300, 27),
	   ('המושבה', 2, 300, 28),
	   ('להב', 2, 300, 29),
	   ('מגן', 2, 300, 30),
	   ('עוגן', 2, 300, 31),
	   ('עוז', 2, 300, 32),
	   ('ראשונים', 2, 300, 33),
	   ('אדם', 3, 300, 34),
	   ('אדר', 3, 300, 35),
	   ('אופק', 3, 300, 36),
	   ('איתן', 3, 300, 37),
	   ('אשל', 3, 300, 38),
	   ('במדבר', 3, 300, 39),
	   ('חצרים', 3, 300, 40),
	   ('יואב', 3, 300, 41),
	   ('כרמים', 3, 300, 42),
	   ('מצדה', 3, 300, 43),
	   ('נגב', 3, 300, 44),
	   ('נועם', 3, 300, 45),
	   ('נופר', 3, 300, 46),
	   ('ניצני נגב', 3, 300, 47),
	   ('נמרוד', 3, 300, 48),
	   ('סיני', 3, 300, 49),
	   ('צור', 3, 300, 50),
	   ('צחור', 3, 300, 51),
	   ('רכסים', 3, 300, 52),
	   ('שגיא', 3, 300, 53),
	   ('שמשון', 3, 300, 54),
	   ('שקד', 3, 300, 55),
	   ('בזק', 4, 300, 56),
	   ('בן יהודה', 4, 300, 57),
	   ('לביא', 4, 300, 58),
	   ('סירונית - צופי ים', 4, 300, 59),
	   ('עיר ימים', 4, 300, 60),
	   ('פולג', 4, 300, 61),
	   ('רגבים', 4, 300, 62),
	   ('רמון', 4, 300, 63),
	   ('תמיד', 4, 300, 64),
	   ('איתן', 5, 300, 65),
	   ('ארבל', 5, 300, 66),
	   ('ארנון', 5, 300, 67),
	   ('דן', 5, 300, 68),
	   ('יהודה', 5, 300, 69),
	   ('יעד', 5, 300, 70),
	   ('כנען', 5, 300, 71),
	   ('מכבים', 5, 300, 72),
	   ('מעוז', 5, 300, 73),
	   ('משואות', 5, 300, 74),
	   ('מתן', 5, 300, 75),
	   ('עומר', 5, 300, 76),
	   ('עתיד', 5, 300, 77),
	   ('צופי ים בת ים', 5, 300, 78),
	   ('רעם', 5, 300, 79),
	   ('שורק', 5, 300, 80),
	   ('שקמה', 5, 300, 81),
	   ('אילן', 6, 300, 82),
	   ('אלומות', 6, 300, 83),
	   ('אלון', 6, 300, 84),
	   ('אלמוג', 6, 300, 85),
	   ('בני היער', 6, 300, 86),
	   ('גולן', 6, 300, 87),
	   ('גפן', 6, 300, 88),
	   ('החלוץ', 6, 300, 89),
	   ('מגל', 6, 300, 90),
	   ('עומר', 6, 300, 91),
	   ('פלג', 6, 300, 92),
	   ('צוקים', 6, 300, 93),
	   ('שקד', 6, 300, 94),
	   ('איתן', 7, 300, 95),
	   ('ארד', 7, 300, 96),
	   ('געש', 7, 300, 97),
	   ('דקר', 7, 300, 98),
	   ('הרצל', 7, 300, 99),
	   ('לביא', 7, 300, 100),
	   ('נוה מגן', 7, 300, 101),
	   ('ני"ר', 7, 300, 102),
	   ('סער', 7, 300, 103),
	   ('רשפים', 7, 300, 104),
	   ('שחף', 7, 300, 105),
	   ('אופק', 8, 300, 106),
	   ('אפיק', 8, 300, 107),
	   ('גלבוע', 8, 300, 108),
	   ('הדר', 8, 300, 109),
	   ('הראל', 8, 300, 110),
	   ('נבו', 8, 300, 111),
	   ('נחשון', 8, 300, 112),
	   ('עמירים', 8, 300, 113),
	   ('צור', 8, 300, 114),
	   ('רכ"ס', 8, 300, 115),
	   ('שליט', 8, 300, 116),
	   ('אורן', 9, 300, 117),
	   ('אילנות', 9, 300, 118),
	   ('אפיק', 9, 300, 119),
	   ('גלים', 9, 300, 120),
	   ('דרור', 9, 300, 121),
	   ('העדן', 9, 300, 122),
	   ('חופים', 9, 300, 123),
	   ('כרמל', 9, 300, 124),
	   ('לטם', 9, 300, 125),
	   ('מגשים', 9, 300, 126),
	   ('משוטטי בכרמל', 9, 300, 127),
	   ('נשרים', 9, 300, 128),
	   ('עמית', 9, 300, 129),
	   ('צופי ים חיפה', 9, 300, 130),
	   ('צופית', 9, 300, 131),
	   ('תדהר', 9, 300, 132),
	   ('אופק', 10, 300, 133),
	   ('איתן', 10, 300, 134),
	   ('דקר', 10, 300, 135),
	   ('האלה', 10, 300, 136),
	   ('הראל', 10, 300, 137),
	   ('זאב', 10, 300, 138),
	   ('חרוב', 10, 300, 139),
	   ('יהודה', 10, 300, 140),
	   ('יונתן', 10, 300, 141),
	   ('לביא', 10, 300, 142),
	   ('ערבה', 10, 300, 143),
	   ('פסגות', 10, 300, 144),
	   ('רועי', 10, 300, 145),
	   ('שוב"ל', 10, 300, 146),
	   ('שורק', 10, 300, 147),
	   ('אלעד', 11, 300, 148),
	   ('אמיר', 11, 300, 149),
	   ('אריאל', 11, 300, 150),
	   ('בית הכרם', 11, 300, 151),
	   ('היובל', 11, 300, 152),
	   ('העומר', 11, 300, 153),
	   ('הר חומה', 11, 300, 154),
	   ('הראל', 11, 300, 155),
	   ('זוהר', 11, 300, 156),
	   ('להבות', 11, 300, 157),
	   ('מודיעין', 11, 300, 158),
	   ('מצדה', 11, 300, 159),
	   ('משואות', 11, 300, 160),
	   ('עוז', 11, 300, 161),
	   ('רכסים', 11, 300, 162),
	   ('אדיס', 12, 300, 163),
	   ('איריס', 12, 300, 164),
	   ('אלון', 12, 300, 165),
	   ('אשחר', 12, 300, 166),
	   ('גונן', 12, 300, 167),
	   ('גלעד', 12, 300, 168),
	   ('יבנאל', 12, 300, 169),
	   ('יזרעאל', 12, 300, 170),
	   ('ים', 12, 300, 171),
	   ('כרם', 12, 300, 172),
	   ('לביא', 12, 300, 173),
	   ('להבות', 12, 300, 174),
	   ('מעיינות', 12, 300, 175),
	   ('משגב', 12, 300, 176),
	   ('עמיחי', 12, 300, 177),
	   ('עפר', 12, 300, 178),
	   ('צופי ים כנרת', 12, 300, 179),
	   ('שחר', 12, 300, 180),
	   ('שלהבת', 12, 300, 181),
	   ('תבור', 12, 300, 182),
	   ('אילת', 13, 300, 183),
	   ('אפעל', 13, 300, 184),
	   ('ירדן', 13, 300, 185),
	   ('ירקון', 13, 300, 186),
	   ('עלית', 13, 300, 187),
	   ('רמת גן', 13, 300, 188),
	   ('רמת חן', 13, 300, 189),
	   ('רעים', 13, 300, 190),
	   ('שקמה', 13, 300, 191),
	   ('אביב', 14, 300, 192),
	   ('איתן', 14, 300, 193),
	   ('אריות', 14, 300, 194),
	   ('גי"א', 14, 300, 195),
	   ('דותן', 14, 300, 196),
	   ('הנחל', 14, 300, 197),
	   ('יאיר', 14, 300, 198),
	   ('ירדן', 14, 300, 199),
	   ('כפיר', 14, 300, 200),
	   ('מידב', 14, 300, 201),
	   ('סהר', 14, 300, 202),
	   ('סער', 14, 300, 203),
	   ('עידן', 14, 300, 204),
	   ('ערבה', 14, 300, 205),
	   ('ראם', 14, 300, 206),
	   ('רעות', 14, 300, 207),
	   ('שחר', 14, 300, 208),
	   ('שלהבת', 14, 300, 209),
	   ('שני"ר', 14, 300, 210),
	   ('אביב', 15, 300, 211),
	   ('אופק', 15, 300, 212),
	   ('איתן', 15, 300, 213),
	   ('בית דני', 15, 300, 214),
	   ('דיזנגוף', 15, 300, 215),
	   ('דן', 15, 300, 216),
	   ('הגבעה', 15, 300, 217),
	   ('החורש', 15, 300, 218),
	   ('הנשיא', 15, 300, 219),
	   ('הצוק', 15, 300, 220),
	   ('חצב', 15, 300, 221),
	   ('יפו', 15, 300, 222),
	   ('כפיר', 15, 300, 223),
	   ('צבר', 15, 300, 224),
	   ('צהלה', 15, 300, 225),
	   ('צופי ים יפו', 15, 300, 226),
	   ('צופי ים תל אביב', 15, 300, 227),
	   ('קהילה', 15, 300, 228),
	   ('רמת אביב ג', 15, 300, 229),
	   ('רעות', 15, 300, 230),
	   ('תמר', 15, 300, 231)

INSERT INTO [User]
VALUES ('aaa@gmail.com', 'AAA', 'AAA', '000000000', 'aaa', 1),
	   ('bbb@gmail.com', 'BBB', 'BBB', '000000001', 'bbb', 2),
	   ('ccc@gmail.com', 'CCC', 'CCC', '000000002', 'ccc', 3),
	   ('ddd@gmail.com', 'DDD', 'DDD', '000000003', 'ddd', 4),
	   ('eee@gmail.com', 'EEE', 'EEE', '000000004', 'eee', 5),
	   ('fff@gmail.com', 'FFF', 'FFF', '000000005', 'fff', 6),
	   ('ggg@gmail.com', 'GGG', 'GGG', '000000006', 'ggg', 7),
	   ('hhh@gmail.com', 'HHH', 'HHH', '000000007', 'hhh', 8),
	   ('iii@gmail.com', 'III', 'III', '000000008', 'iii', 9),
	   ('jjj@gmail.com', 'JJJ', 'JJJ', '000000009', 'jjj', 10),
	   ('kkk@gmail.com', 'KKK', 'KKK', '000000010', 'kkk', 11),
	   ('lll@gmail.com', 'LLL', 'LLL', '000000011', 'lll', 12),
	   ('mmm@gmail.com', 'MMM', 'MMM', '000000012', 'mmm', 13),
	   ('nnn@gmail.com', 'NNN', 'NNN', '000000013', 'nnn', 14),
	   ('ooo@gmail.com', 'OOO', 'OOO', '000000014', 'ooo', 15),
	   ('ppp@gmail.com', 'PPP', 'PPP', '000000015', 'ppp', 16),
	   ('qqq@gmail.com', 'QQQ', 'QQQ', '000000016', 'qqq', 17),
	   ('rrr@gmail.com', 'RRR', 'RRR', '000000017', 'rrr', 18),
	   ('sss@gmail.com', 'SSS', 'SSS', '000000018', 'sss', 19),
	   ('ttt@gmail.com', 'TTT', 'TTT', '000000019', 'ttt', 20),
	   ('uuu@gmail.com', 'UUU', 'UUU', '000000020', 'uuu', 21),
	   ('vvv@gmail.com', 'VVV', 'VVV', '000000021', 'vvv', 22),
	   ('www@gmail.com', 'WWW', 'WWW', '000000022', 'www', 23),
	   ('xxx@gmail.com', 'XXX', 'XXX', '000000023', 'xxx', 24),
	   ('yyy@gmail.com', 'YYY', 'YYY', '000000024', 'yyy', 25),
	   ('zzz@gmail.com', 'ZZZ', 'ZZZ', '000000025', 'zzz', 26),
	   ('aaa1@gmail.com', 'AAA1', 'AAA1', '000000026', 'aaa1', 27),
	   ('bbb1@gmail.com', 'BBB1', 'BBB1', '000000027', 'bbb1', 28),
	   ('ccc1@gmail.com', 'CCC1', 'CCC1', '000000028', 'ccc1', 29),
	   ('ddd1@gmail.com', 'DDD1', 'DDD1', '000000029', 'ddd1', 30),
	   ('eee1@gmail.com', 'EEE1', 'EEE1', '000000030', 'eee1', 31),
	   ('fff1@gmail.com', 'FFF1', 'FFF1', '000000031', 'fff1', 32),
	   ('ggg1@gmail.com', 'GGG1', 'GGG1', '000000032', 'ggg1', 33),
	   ('hhh1@gmail.com', 'HHH1', 'HHH1', '000000033', 'hhh1', 34),
	   ('iii1@gmail.com', 'III1', 'III1', '000000034', 'iii1', 35),
	   ('jjj1@gmail.com', 'JJJ1', 'JJJ1', '000000035', 'jjj1', 36),
	   ('kkk1@gmail.com', 'KKK1', 'KKK1', '000000036', 'kkk1', 37),
	   ('lll1@gmail.com', 'LLL1', 'LLL1', '000000037', 'lll1', 38),
	   ('mmm1@gmail.com', 'MMM1', 'MMM1', '000000038', 'mmm1', 39),
	   ('nnn1@gmail.com', 'NNN1', 'NNN1', '000000039', 'nnn1', 40),
	   ('ooo1@gmail.com', 'OOO1', 'OOO1', '000000040', 'ooo1', 41),
	   ('ppp1@gmail.com', 'PPP1', 'PPP1', '000000041', 'ppp1', 42),
	   ('qqq1@gmail.com', 'QQQ1', 'QQQ1', '000000042', 'qqq1', 43),
	   ('rrr1@gmail.com', 'RRR1', 'RRR1', '000000043', 'rrr1', 44),
	   ('sss1@gmail.com', 'SSS1', 'SSS1', '000000044', 'sss1', 45),
	   ('ttt1@gmail.com', 'TTT1', 'TTT1', '000000045', 'ttt1', 46),
	   ('uuu1@gmail.com', 'UUU1', 'UUU1', '000000046', 'uuu1', 47),
	   ('vvv1@gmail.com', 'VVV1', 'VVV1', '000000047', 'vvv1', 48),
	   ('www1@gmail.com', 'WWW1', 'WWW1', '000000048', 'www1', 49),
	   ('xxx1@gmail.com', 'XXX1', 'XXX1', '000000049', 'xxx1', 50),
	   ('yyy1@gmail.com', 'YYY1', 'YYY1', '000000050', 'yyy1', 51),
	   ('zzz1@gmail.com', 'ZZZ1', 'ZZZ1', '000000051', 'zzz1', 52)

INSERT INTO [Role]
VALUES ('אדמין', 1),
	   ('ראש הנהגה', 2),
	   ('ראש שבט', 3),
	   ('חניך ד', 4),
	   ('חניך ה', 5),
	   ('חניך ו', 6),
	   ('חניך ז', 7),
	   ('חניך ח', 8),
	   ('חניך ט', 9),
	   ('מדריך ד', 10),
	   ('מדריך ה', 11),
	   ('מדריך ו', 12),
	   ('מדריך ז', 13),
	   ('מדריך ח', 14),
	   ('מדריך ט', 15),
	   ('רשגד ד', 16),
	   ('רשגד ה', 17),
	   ('רשגד ו', 18),
	   ('רשגד ז', 19),
	   ('רשגד ח', 20),
	   ('פעיל', 21)

INSERT INTO Parent
VALUES (1, 1, 1),
	   (231, 3, 2),
	   (4, 4, 3),
	   (7, 5, 4),
	   (19, 6, 5),
	   (204, 7, 6),
	   (82, 8, 7),
	   (205, 9, 8)

INSERT INTO Worker ([RoleID], UserID, ID)
VALUES (1, 2, 1)

INSERT INTO Worker ([RoleID], HanhagaID, UserID, ID)
VALUES (2, 1, 10, 2),
	   (2, 2, 12, 4),
	   (2, 3, 13, 5),
	   (2, 4, 14, 6),
	   (2, 5, 15, 7),
	   (2, 6, 16, 8),
	   (2, 7, 17, 9),
	   (2, 8, 18, 10),
	   (2, 9, 19, 11),
	   (2, 10, 20, 12),
	   (2, 11, 21, 13),
	   (2, 12, 22, 14),
	   (2, 13, 23, 15),
	   (2, 14, 24, 16),
	   (2, 15, 25, 17)

INSERT INTO Worker(ShevetID, [RoleID], HanhagaID, UserID, ID)
VALUES (1, 3, 1, 11, 3),
	   (45, 3, 3, 26, 18),
	   (67, 3, 5, 27, 19),
	   (112, 3, 8, 28, 20),
	   (149, 3, 11, 29, 21)

INSERT INTO Cadet
VALUES ('aaa', 'AAA', 'ד', '100000000', 1, 4, 1),
	   ('ccc', 'CCC', 'ה', '100000001', 231, 5, 2),
	   ('ddd', 'DDD', 'י', '100000002', 4, 10, 3),
	   ('eee', 'EEE', 'יא', '100000003', 7, 16, 4),
	   ('fff', 'FFF', 'יב', '100000004', 19, 15, 5),
	   ('ggg', 'GGG', 'יא', '100000005', 204, 17, 6),
	   ('hhh', 'HHH', 'ז', '100000006', 82, 7, 7),
	   ('iii', 'III', 'ט', '100000007', 205, 9, 8),
	   ('iiii', 'III', 'יב', '100000008', 205, 20, 9),
	   ('ii', 'III', 'ו', '100000009', 112, 6, 10)

INSERT INTO Cadet_Parent
VALUES (1, 1),
	   (2, 2),
	   (3, 3),
	   (4, 4),
	   (5, 5),
	   (6, 6),
	   (7, 7),
	   (8, 8),
	   (8, 9),
	   (8, 10)

INSERT INTO Activity
VALUES ('טיול פסח ח', '2022-04-11', '2022-04-14', 8, 0, 600, 0, 0, 112, 8, 0),
       ('טיול פסח ז', '2022-04-11', '2022-04-13', 7, 0, 500, 0, 0, 112, 8, 1),
       ('מחנה קיץ ח', '2022-06-30', '2022-07-04', 8, 0, 800, 0, 0, 112, 8, 2),
       ('מחנה קיץ ז', '2022-06-30', '2022-07-03', 7, 0, 700, 0, 0, 112, 8, 3)

INSERT INTO ActivitiesHistory
VALUES (9, 0),
	   (9, 2),
	   (7, 1),
	   (7, 3)