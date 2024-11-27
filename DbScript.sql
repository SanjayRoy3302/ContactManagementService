USE [master]
GO

/****** Object:  Database [ContactManagement]    Script Date: 24-Nov-24 3:52:12 PM ******/
CREATE DATABASE [ContactManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ContactManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ContactManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ContactManagement] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ContactManagement] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ContactManagement] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ContactManagement] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ContactManagement] SET ARITHABORT OFF 
GO

ALTER DATABASE [ContactManagement] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ContactManagement] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ContactManagement] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ContactManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ContactManagement] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ContactManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ContactManagement] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ContactManagement] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ContactManagement] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ContactManagement] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ContactManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ContactManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ContactManagement] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ContactManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ContactManagement] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ContactManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ContactManagement] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ContactManagement] SET RECOVERY FULL 
GO

ALTER DATABASE [ContactManagement] SET  MULTI_USER 
GO

ALTER DATABASE [ContactManagement] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ContactManagement] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ContactManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ContactManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ContactManagement] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ContactManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ContactManagement] SET QUERY_STORE = ON
GO

ALTER DATABASE [ContactManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [ContactManagement] SET  READ_WRITE 
GO

