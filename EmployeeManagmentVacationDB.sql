USE [master]
GO
/****** Object:  Database [EmployeeManagmentVacationDB]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE DATABASE [EmployeeManagmentVacationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeManagmentVacationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EmployeeManagmentVacationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeManagmentVacationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EmployeeManagmentVacationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagmentVacationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EmployeeManagmentVacationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeNumber] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[GenderCode] [nvarchar](1) NOT NULL,
	[ReportedToEmployeeNumber] [nvarchar](6) NULL,
	[VacationDaysLeft] [int] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeVacationApprovals]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeVacationApprovals](
	[EmployeeNumber] [nvarchar](6) NOT NULL,
	[VacationRequestId] [int] NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeVacationApprovals] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC,
	[VacationRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestStates]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStates](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_RequestStates] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VacationRequests]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VacationRequests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestSubmissionDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[EmployeeNumber] [nvarchar](6) NOT NULL,
	[VacationTypeCode] [nvarchar](1) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[TotalVacationDays] [int] NOT NULL,
	[RequestStateId] [int] NOT NULL,
	[ApprovedByEmployeeNumber] [nvarchar](6) NULL,
	[DeclinedByEmployeeNumber] [nvarchar](6) NULL,
 CONSTRAINT [PK_VacationRequests] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VacationTypes]    Script Date: 2/11/2025 5:55:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VacationTypes](
	[VacationTypeCode] [nvarchar](1) NOT NULL,
	[VacationTypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_VacationTypes] PRIMARY KEY CLUSTERED 
(
	[VacationTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_DepartmentId]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_DepartmentId] ON [dbo].[Employees]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_PositionId]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_PositionId] ON [dbo].[Employees]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Employees_ReportedToEmployeeNumber]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_ReportedToEmployeeNumber] ON [dbo].[Employees]
(
	[ReportedToEmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeVacationApprovals_VacationRequestId]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeVacationApprovals_VacationRequestId] ON [dbo].[EmployeeVacationApprovals]
(
	[VacationRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VacationRequests_ApprovedByEmployeeNumber]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_VacationRequests_ApprovedByEmployeeNumber] ON [dbo].[VacationRequests]
(
	[ApprovedByEmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VacationRequests_DeclinedByEmployeeNumber]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_VacationRequests_DeclinedByEmployeeNumber] ON [dbo].[VacationRequests]
(
	[DeclinedByEmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VacationRequests_EmployeeNumber]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_VacationRequests_EmployeeNumber] ON [dbo].[VacationRequests]
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VacationRequests_RequestStateId]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_VacationRequests_RequestStateId] ON [dbo].[VacationRequests]
(
	[RequestStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VacationRequests_VacationTypeCode]    Script Date: 2/11/2025 5:55:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_VacationRequests_VacationTypeCode] ON [dbo].[VacationRequests]
(
	[VacationTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees_ReportedToEmployeeNumber] FOREIGN KEY([ReportedToEmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees_ReportedToEmployeeNumber]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions_PositionId]
GO
ALTER TABLE [dbo].[EmployeeVacationApprovals]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeVacationApprovals_Employees_EmployeeNumber] FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[EmployeeVacationApprovals] CHECK CONSTRAINT [FK_EmployeeVacationApprovals_Employees_EmployeeNumber]
GO
ALTER TABLE [dbo].[EmployeeVacationApprovals]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeVacationApprovals_VacationRequests_VacationRequestId] FOREIGN KEY([VacationRequestId])
REFERENCES [dbo].[VacationRequests] ([RequestId])
GO
ALTER TABLE [dbo].[EmployeeVacationApprovals] CHECK CONSTRAINT [FK_EmployeeVacationApprovals_VacationRequests_VacationRequestId]
GO
ALTER TABLE [dbo].[VacationRequests]  WITH CHECK ADD  CONSTRAINT [FK_VacationRequests_Employees_ApprovedByEmployeeNumber] FOREIGN KEY([ApprovedByEmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[VacationRequests] CHECK CONSTRAINT [FK_VacationRequests_Employees_ApprovedByEmployeeNumber]
GO
ALTER TABLE [dbo].[VacationRequests]  WITH CHECK ADD  CONSTRAINT [FK_VacationRequests_Employees_DeclinedByEmployeeNumber] FOREIGN KEY([DeclinedByEmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[VacationRequests] CHECK CONSTRAINT [FK_VacationRequests_Employees_DeclinedByEmployeeNumber]
GO
ALTER TABLE [dbo].[VacationRequests]  WITH CHECK ADD  CONSTRAINT [FK_VacationRequests_Employees_EmployeeNumber] FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[VacationRequests] CHECK CONSTRAINT [FK_VacationRequests_Employees_EmployeeNumber]
GO
ALTER TABLE [dbo].[VacationRequests]  WITH CHECK ADD  CONSTRAINT [FK_VacationRequests_RequestStates_RequestStateId] FOREIGN KEY([RequestStateId])
REFERENCES [dbo].[RequestStates] ([StateId])
GO
ALTER TABLE [dbo].[VacationRequests] CHECK CONSTRAINT [FK_VacationRequests_RequestStates_RequestStateId]
GO
ALTER TABLE [dbo].[VacationRequests]  WITH CHECK ADD  CONSTRAINT [FK_VacationRequests_VacationTypes_VacationTypeCode] FOREIGN KEY([VacationTypeCode])
REFERENCES [dbo].[VacationTypes] ([VacationTypeCode])
GO
ALTER TABLE [dbo].[VacationRequests] CHECK CONSTRAINT [FK_VacationRequests_VacationTypes_VacationTypeCode]
GO
USE [master]
GO
ALTER DATABASE [EmployeeManagmentVacationDB] SET  READ_WRITE 
GO
