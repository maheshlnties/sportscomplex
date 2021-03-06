USE [master]
GO
/****** Object:  Database [SportsComplex]    Script Date: 05/03/2016 22:15:40 ******/
CREATE DATABASE [SportsComplex] ON  PRIMARY 
( NAME = N'SportsComplex', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.NEWSQLEXPRESS\MSSQL\DATA\SportsComplex.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SportsComplex_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.NEWSQLEXPRESS\MSSQL\DATA\SportsComplex_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SportsComplex] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportsComplex].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SportsComplex] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SportsComplex] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SportsComplex] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SportsComplex] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SportsComplex] SET ARITHABORT OFF
GO
ALTER DATABASE [SportsComplex] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SportsComplex] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SportsComplex] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SportsComplex] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SportsComplex] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SportsComplex] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SportsComplex] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SportsComplex] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SportsComplex] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SportsComplex] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SportsComplex] SET  DISABLE_BROKER
GO
ALTER DATABASE [SportsComplex] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SportsComplex] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SportsComplex] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SportsComplex] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SportsComplex] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SportsComplex] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SportsComplex] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SportsComplex] SET  READ_WRITE
GO
ALTER DATABASE [SportsComplex] SET RECOVERY SIMPLE
GO
ALTER DATABASE [SportsComplex] SET  MULTI_USER
GO
ALTER DATABASE [SportsComplex] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SportsComplex] SET DB_CHAINING OFF
GO
USE [SportsComplex]
GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[EncodedImage] [nvarchar](max) NOT NULL,
	[UploadedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[PsNumber] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[BuisnessUnit] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[DeskPhoneNumber] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[UserRole] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[PsNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BilliardResource]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BilliardResource](
	[BookDate] [datetime] NOT NULL,
	[Items] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BilliardResource] PRIMARY KEY CLUSTERED 
(
	[BookDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BadmintonResource]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BadmintonResource](
	[BookDate] [datetime] NOT NULL,
	[Items] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BadmintonResource] PRIMARY KEY CLUSTERED 
(
	[BookDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournment]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Fees] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[TournmentDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tournment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceSettings]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceSettings](
	[Name] [int] NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_ResourceSettingKeys] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Highlight] [bit] NOT NULL,
	[PostedOn] [datetime] NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TournmentBooking]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TournmentBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TournmentId] [int] NOT NULL,
	[PsNumber] [nvarchar](50) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TournmentBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gym]    Script Date: 05/03/2016 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gym](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PsNumber] [nvarchar](50) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Joined] [bit] NOT NULL,
	[JoinedOn] [datetime] NULL,
	[LeftOn] [datetime] NULL,
 CONSTRAINT [PK_Gym] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEmployee]    Script Date: 05/03/2016 22:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertEmployee]
  @PsNumber nvarchar(50),
  @Name nvarchar(50)
  ,@Gender int
  ,@DateOfBirth date
   ,@Email nvarchar(MAX)
    ,@BuisnessUnit int
     ,@Address nvarchar(MAX)
     ,@DeskPhoneNumber nvarchar(50)
      ,@Mobile nvarchar(50)
       ,@UserRole int
      ,@Password nvarchar(50)
AS 
BEGIN 

insert into dbo.Employees(PsNumber, Name, Gender, DateOfBirth, Email, BuisnessUnit, [Address], DeskPhoneNumber, Mobile, UserRole, [Password])
values(@PsNumber, @Name, @Gender, @DateOfBirth, @Email, @BuisnessUnit, @Address, @DeskPhoneNumber, @Mobile, @UserRole, @Password)


END
GO
/****** Object:  StoredProcedure [dbo].[sp_BookBilliardResource]    Script Date: 05/03/2016 22:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BookBilliardResource]  
  @BookDate date  
   ,@Items nvarchar(MAX) 
AS   
BEGIN   
declare @rows as int
Select @rows = count(*) From dbo.BilliardResource Where BookDate=@BookDate

IF @rows = 0
BEGIN  
	insert into dbo.BilliardResource(BookDate, Items)  
	values(@BookDate, @Items) 
END

ELSE

BEGIN    
	UPDATE [SportsComplex].[dbo].BilliardResource
	SET [BookDate] = @BookDate
		  ,[Items] = @Items
	WHERE BookDate=@BookDate
END
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BookBadmintonResource]    Script Date: 05/03/2016 22:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BookBadmintonResource]  
  @BookDate date  
   ,@Items nvarchar(MAX) 
AS   
BEGIN   
declare @rows as int
Select @rows = count(*) From dbo.BadmintonResource Where BookDate=@BookDate

IF @rows = 0
BEGIN  
	insert into dbo.BadmintonResource(BookDate, Items)  
	values(@BookDate, @Items) 
END

ELSE

BEGIN    
	UPDATE [SportsComplex].[dbo].[BadmintonResource]
	SET [BookDate] = @BookDate
		  ,[Items] = @Items
	WHERE BookDate=@BookDate
END
    
END
GO
/****** Object:  ForeignKey [FK_TournmentBooking_Employee]    Script Date: 05/03/2016 22:15:42 ******/
ALTER TABLE [dbo].[TournmentBooking]  WITH NOCHECK ADD  CONSTRAINT [FK_TournmentBooking_Employee] FOREIGN KEY([PsNumber])
REFERENCES [dbo].[Employees] ([PsNumber])
GO
ALTER TABLE [dbo].[TournmentBooking] CHECK CONSTRAINT [FK_TournmentBooking_Employee]
GO
/****** Object:  ForeignKey [FK_TournmentBooking_Tournment]    Script Date: 05/03/2016 22:15:42 ******/
ALTER TABLE [dbo].[TournmentBooking]  WITH NOCHECK ADD  CONSTRAINT [FK_TournmentBooking_Tournment] FOREIGN KEY([TournmentId])
REFERENCES [dbo].[Tournment] ([Id])
GO
ALTER TABLE [dbo].[TournmentBooking] CHECK CONSTRAINT [FK_TournmentBooking_Tournment]
GO
/****** Object:  ForeignKey [FK_Gym_Employee]    Script Date: 05/03/2016 22:15:42 ******/
ALTER TABLE [dbo].[Gym]  WITH CHECK ADD  CONSTRAINT [FK_Gym_Employee] FOREIGN KEY([PsNumber])
REFERENCES [dbo].[Employees] ([PsNumber])
GO
ALTER TABLE [dbo].[Gym] CHECK CONSTRAINT [FK_Gym_Employee]
GO
