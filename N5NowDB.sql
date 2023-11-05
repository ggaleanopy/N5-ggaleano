USE [master]
GO

/****** Object:  Database [N5NowDB]    Script Date: 04/11/2023 9:21:07 ******/
CREATE DATABASE [N5NowDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'N5NowDB', FILENAME = N'/var/opt/mssql/data/N5NowDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'N5NowDB_log', FILENAME = N'/var/opt/mssql/data/N5NowDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [N5NowDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [N5NowDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [N5NowDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [N5NowDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [N5NowDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [N5NowDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [N5NowDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [N5NowDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [N5NowDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [N5NowDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [N5NowDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [N5NowDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [N5NowDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [N5NowDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [N5NowDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [N5NowDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [N5NowDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [N5NowDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [N5NowDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [N5NowDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [N5NowDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [N5NowDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [N5NowDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [N5NowDB] SET RECOVERY FULL 
GO

ALTER DATABASE [N5NowDB] SET  MULTI_USER 
GO

ALTER DATABASE [N5NowDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [N5NowDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [N5NowDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [N5NowDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [N5NowDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [N5NowDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [N5NowDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [N5NowDB] SET  READ_WRITE 
GO

USE [N5NowDB]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 04/11/2023 9:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [text] NOT NULL,
	[ApellidoEmpleado] [text] NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionType]    Script Date: 04/11/2023 9:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [text] NOT NULL,
 CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permissions]  WITH NOCHECK ADD  CONSTRAINT [FK_Permissions_PermissionType] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[PermissionType] ([Id])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee Forename' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'NombreEmpleado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee Surname' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'ApellidoEmpleado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'TipoPermiso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission granted on date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'FechaPermiso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionType', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
