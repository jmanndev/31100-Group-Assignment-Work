USE [master]
GO
/****** Object:  Database [ENET]    Script Date: 3/05/2017 3:44:05 PM ******/
CREATE DATABASE [ENET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ENET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ENET.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ENET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ENET_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ENET] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ENET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ENET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ENET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ENET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ENET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ENET] SET ARITHABORT OFF 
GO
ALTER DATABASE [ENET] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ENET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ENET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ENET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ENET] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ENET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ENET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ENET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ENET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ENET] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ENET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ENET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ENET] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ENET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ENET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ENET] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ENET] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ENET] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ENET] SET  MULTI_USER 
GO
ALTER DATABASE [ENET] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ENET] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ENET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ENET] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
--ALTER DATABASE [ENET] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ENET]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 3/05/2017 3:44:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/05/2017 3:44:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/05/2017 3:44:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/05/2017 3:44:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/05/2017 3:44:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/05/2017 3:44:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Accountant')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Manager')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Site Engineer')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'005a5457-281a-41b7-9857-6dc1f6784b7c', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c028ca9b-d299-4bff-b30a-b9a92f5dc526', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'650d6adb-d254-41a4-8642-6686ed33bf0b', N'2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7facbe93-b587-4b82-a01e-71f296b318b8', N'3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'005a5457-281a-41b7-9857-6dc1f6784b7c', N'test@test', 0, N'AHm8fpNWNUIEwxL0pkCCp/kIGch91VF2nMayiwypZLD3csUNt1iz1TLVAiaNCIn8PQ==', N'2602e9dd-6302-464d-a29c-6330e5eaf3d3', NULL, 0, 0, NULL, 1, 0, N'test@test')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', N'engineer@test', 0, N'AAatpnveaBHjLdHhl7LZ6nmIpQONGGIydmA36TOuehldwKQDqxwetCyUs2HIgq92BA==', N'47ad72f3-8378-4696-a401-885f41164cf3', NULL, 0, 0, NULL, 1, 0, N'engineer@test')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'650d6adb-d254-41a4-8642-6686ed33bf0b', N'manager@test', 0, N'AHCexXmFPh8J3PIeHWIzpzrLOQMl8qMOB31r/TrwsCqpCpnFv5EGfsk4ndwSYYxw3A==', N'8d21a90d-1dc8-4974-b6ef-2af0f3e2b783', NULL, 0, 0, NULL, 1, 0, N'manager@test')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7facbe93-b587-4b82-a01e-71f296b318b8', N'accountant@test', 0, N'AMMHlFk02IDT5oSmMAPqX7ge0exmbx9zJUO5Hu64UzBSWW1GSw1jZjf007I2i9soMw==', N'74cb7a60-89d6-40db-878b-4521f05b832d', NULL, 0, 0, NULL, 1, 0, N'accountant@test')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a1773167-13e7-414a-b46d-5560e5d22d42', N'geodu3@gmail.com', 0, N'AMvgpj+qrH8j5sNnKq+QNHCmt1R1SarOeNODbKf9s40z7YVB+scV7bToAd0Jl5NFAg==', N'aa98bcba-75d1-4a73-9371-6a95395d7ce8', NULL, 0, 0, NULL, 1, 0, N'geodu3@gmail.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ac7db2fd-abd5-4cb1-be5d-670cf24fc1e3', N'Test@boba', 0, N'AC7I761O7Qo0vHXG5vvGY5ubeTEGYiBFuA+SDFqMXvGkvw9CoHoRg9smm/2ToNdmLw==', N'4c5ee79e-69aa-4881-888a-6218625f71ff', NULL, 0, 0, NULL, 1, 0, N'Test@boba')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c028ca9b-d299-4bff-b30a-b9a92f5dc526', N'engineer2@test', 0, N'AFpAEomYnSgvdEiNeRXwD1I1jt8ekuVHJK3JqbxGyax8QY6iUjr5xqSANajol8yEsw==', N'83e5ff85-e99c-481f-8ddf-8940bcc2d1e4', NULL, 0, 0, NULL, 1, 0, N'engineer2@test')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd8f2dd4d-3b79-4db6-bc59-f698b30f2a39', N'George@test', 0, N'APNKzS3Jb4FXJRaymJdkY05hzox0ibMozepn+ssIPKOppXStflarFO7EkxfP/yV65g==', N'ab47f23c-b00e-40a7-afeb-38c5eb8fb443', NULL, 0, 0, NULL, 1, 0, N'George@test')
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/05/2017 3:44:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 3/05/2017 3:44:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 3/05/2017 3:44:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 3/05/2017 3:44:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 3/05/2017 3:44:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [ENET] SET  READ_WRITE 
GO

/****** Object:  Database [ECare2]    Script Date: 3/05/2017 3:45:09 PM ******/
CREATE DATABASE [ECare2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ECare2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ECare2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ECare2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ECare2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ECare2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECare2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECare2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECare2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECare2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECare2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECare2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECare2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ECare2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECare2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECare2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECare2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECare2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECare2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECare2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECare2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECare2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ECare2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECare2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECare2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECare2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECare2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECare2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ECare2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECare2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ECare2] SET  MULTI_USER 
GO
ALTER DATABASE [ECare2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECare2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ECare2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ECare2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
--ALTER DATABASE [ECare2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ECare2]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DistrictID] [int] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Notes] [text] NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Name] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inspection]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InterventionId] [int] NOT NULL,
	[SiteEngineerId] [nvarchar](128) NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Inspection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Intervention]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intervention](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[InterventionTypeId] [int] NOT NULL,
	[LabourHours] [decimal](18, 0) NULL,
	[MaterialCost] [decimal](18, 0) NULL,
	[SiteEngineerId] [nvarchar](128) NULL,
	[Date] [date] NOT NULL,
	[InterventionStatus] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Life] [int] NOT NULL,
	[ApprovedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_Intervention] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InterventionStatus]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterventionStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_InterventionStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IntervntionType]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntervntionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LabourHours] [int] NOT NULL,
	[Material Cost] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_IntervntionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manager]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[EmployeeId] [nvarchar](128) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[HourApprovalLimit] [decimal](18, 0) NULL,
	[CostApprovalLimit] [decimal](18, 0) NULL,
	[Notes] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiteEngineer]    Script Date: 3/05/2017 3:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteEngineer](
	[EmployeeId] [nvarchar](128) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[HourApprovalLimit] [decimal](18, 0) NULL,
	[CostApprovalLimit] [decimal](18, 0) NULL,
	[Notes] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Client] ON 

GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (1, N'John', 1, N'60 Grove st', NULL)
GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (2, N'Jack', 1, N'61 Groove st', NULL)
GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (3, N'Simon', 2, N'62 the hood', NULL)
GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (4, N'Simeone', 0, N'77 Grove st', NULL)
GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (5, N'Jason', 0, N'44 bond st', NULL)
GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (6, N'Jenny', 0, N'', NULL)
GO
INSERT [dbo].[Client] ([ID], [Name], [DistrictID], [Address], [Notes]) VALUES (7, N'Jenny', 0, N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON 

GO
INSERT [dbo].[District] ([ID], [Name], [Notes]) VALUES (1, N'Urban Indonesia', NULL)
GO
INSERT [dbo].[District] ([ID], [Name], [Notes]) VALUES (2, N'Rural Indonesia', NULL)
GO
INSERT [dbo].[District] ([ID], [Name], [Notes]) VALUES (3, N'Urban Papua New Guinea', NULL)
GO
INSERT [dbo].[District] ([ID], [Name], [Notes]) VALUES (4, N'Rural Papua New Guinea', NULL)
GO
INSERT [dbo].[District] ([ID], [Name], [Notes]) VALUES (5, N'Sydney', NULL)
GO
INSERT [dbo].[District] ([ID], [Name], [Notes]) VALUES (6, N'Rural New South Wales', NULL)
GO
SET IDENTITY_INSERT [dbo].[District] OFF
GO
INSERT [dbo].[Employee] ([Name], [Username], [Id]) VALUES (N'Engi', N'engineer@test', N'1abaa02b-7a5b-4853-aa9a-8dee033e1042')
GO
INSERT [dbo].[Employee] ([Name], [Username], [Id]) VALUES (N'Man', N'manager@test', N'650d6adb-d254-41a4-8642-6686ed33bf0b')
GO
INSERT [dbo].[Employee] ([Name], [Username], [Id]) VALUES (N'Acc', N'accountant@test', N'7facbe93-b587-4b82-a01e-71f296b318b8')
GO
INSERT [dbo].[Employee] ([Name], [Username], [Id]) VALUES (N'Engi2', N'engineer2@test', N'd8f2dd4d-3b79-4db6-bc59-f698b30f2a39')
GO
SET IDENTITY_INSERT [dbo].[Intervention] ON 

GO
INSERT [dbo].[Intervention] ([Id], [ClientId], [InterventionTypeId], [LabourHours], [MaterialCost], [SiteEngineerId], [Date], [InterventionStatus], [Notes], [Life], [ApprovedBy]) VALUES (2, 1, 1, CAST(5 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', CAST(N'2017-05-02' AS Date), 1, NULL, 100, NULL)
GO
INSERT [dbo].[Intervention] ([Id], [ClientId], [InterventionTypeId], [LabourHours], [MaterialCost], [SiteEngineerId], [Date], [InterventionStatus], [Notes], [Life], [ApprovedBy]) VALUES (4, 1, 1, CAST(5 AS Decimal(18, 0)), CAST(250 AS Decimal(18, 0)), N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', CAST(N'2017-05-02' AS Date), 1, NULL, 100, NULL)
GO
INSERT [dbo].[Intervention] ([Id], [ClientId], [InterventionTypeId], [LabourHours], [MaterialCost], [SiteEngineerId], [Date], [InterventionStatus], [Notes], [Life], [ApprovedBy]) VALUES (6, 2, 1, CAST(6 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)), N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', CAST(N'2017-05-02' AS Date), 1, NULL, 100, NULL)
GO
INSERT [dbo].[Intervention] ([Id], [ClientId], [InterventionTypeId], [LabourHours], [MaterialCost], [SiteEngineerId], [Date], [InterventionStatus], [Notes], [Life], [ApprovedBy]) VALUES (7, 2, 2, CAST(10 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', CAST(N'2017-05-02' AS Date), 1, NULL, 100, NULL)
GO
INSERT [dbo].[Intervention] ([Id], [ClientId], [InterventionTypeId], [LabourHours], [MaterialCost], [SiteEngineerId], [Date], [InterventionStatus], [Notes], [Life], [ApprovedBy]) VALUES (8, 3, 1, CAST(5 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'd8f2dd4d-3b79-4db6-bc59-f698b30f2a39', CAST(N'2017-05-02' AS Date), 1, NULL, 100, NULL)
GO
INSERT [dbo].[Intervention] ([Id], [ClientId], [InterventionTypeId], [LabourHours], [MaterialCost], [SiteEngineerId], [Date], [InterventionStatus], [Notes], [Life], [ApprovedBy]) VALUES (9, 3, 1, CAST(10 AS Decimal(18, 0)), CAST(700 AS Decimal(18, 0)), N'd8f2dd4d-3b79-4db6-bc59-f698b30f2a39', CAST(N'2017-05-02' AS Date), 1, NULL, 100, NULL)
GO
SET IDENTITY_INSERT [dbo].[Intervention] OFF
GO
SET IDENTITY_INSERT [dbo].[InterventionStatus] ON 

GO
INSERT [dbo].[InterventionStatus] ([Id], [Name], [Notes]) VALUES (1, N'Proposed', NULL)
GO
INSERT [dbo].[InterventionStatus] ([Id], [Name], [Notes]) VALUES (2, N'Approved', NULL)
GO
INSERT [dbo].[InterventionStatus] ([Id], [Name], [Notes]) VALUES (3, N'Cancelled', NULL)
GO
INSERT [dbo].[InterventionStatus] ([Id], [Name], [Notes]) VALUES (4, N'Completed', NULL)
GO
SET IDENTITY_INSERT [dbo].[InterventionStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[IntervntionType] ON 

GO
INSERT [dbo].[IntervntionType] ([Id], [Name], [LabourHours], [Material Cost], [Notes]) VALUES (1, N'Supply Mosquito Net', 100, 2, NULL)
GO
INSERT [dbo].[IntervntionType] ([Id], [Name], [LabourHours], [Material Cost], [Notes]) VALUES (2, N'Supply and Install Portable Toilet', 1000, 10, NULL)
GO
INSERT [dbo].[IntervntionType] ([Id], [Name], [LabourHours], [Material Cost], [Notes]) VALUES (3, N'Hepatitis Avoidance Training', 500, 20, NULL)
GO
INSERT [dbo].[IntervntionType] ([Id], [Name], [LabourHours], [Material Cost], [Notes]) VALUES (4, N'Supply and Install Storm-proof HomeKit', 5000, 20, NULL)
GO
SET IDENTITY_INSERT [dbo].[IntervntionType] OFF
GO
INSERT [dbo].[Manager] ([EmployeeId], [DistrictId], [HourApprovalLimit], [CostApprovalLimit], [Notes]) VALUES (N'650d6adb-d254-41a4-8642-6686ed33bf0b', 1, CAST(100 AS Decimal(18, 0)), CAST(20000 AS Decimal(18, 0)), NULL)
GO
INSERT [dbo].[SiteEngineer] ([EmployeeId], [DistrictId], [HourApprovalLimit], [CostApprovalLimit], [Notes]) VALUES (N'1abaa02b-7a5b-4853-aa9a-8dee033e1042', 1, CAST(20 AS Decimal(18, 0)), CAST(5000 AS Decimal(18, 0)), NULL)
GO
INSERT [dbo].[SiteEngineer] ([EmployeeId], [DistrictId], [HourApprovalLimit], [CostApprovalLimit], [Notes]) VALUES (N'd8f2dd4d-3b79-4db6-bc59-f698b30f2a39', 2, CAST(10 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), NULL)
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Man_user] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Man_user]
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager_District]
GO
ALTER TABLE [dbo].[SiteEngineer]  WITH CHECK ADD  CONSTRAINT [FK_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[SiteEngineer] CHECK CONSTRAINT [FK_District]
GO
ALTER TABLE [dbo].[SiteEngineer]  WITH CHECK ADD  CONSTRAINT [FK_SiteEngineer_User] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[SiteEngineer] CHECK CONSTRAINT [FK_SiteEngineer_User]
GO
USE [master]
GO
ALTER DATABASE [ECare2] SET  READ_WRITE 
GO
