USE [master]
GO
/****** Object:  Database [BD_MINIMARKET]    Script Date: 11/03/2024 03:40:56 p. m. ******/
CREATE DATABASE [BD_MINIMARKET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_MINIMARKET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BD_MINIMARKET.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_MINIMARKET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BD_MINIMARKET_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BD_MINIMARKET] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_MINIMARKET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_MINIMARKET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_MINIMARKET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_MINIMARKET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_MINIMARKET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_MINIMARKET] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_MINIMARKET] SET  MULTI_USER 
GO
ALTER DATABASE [BD_MINIMARKET] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_MINIMARKET] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_MINIMARKET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_MINIMARKET] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_MINIMARKET] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_MINIMARKET] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BD_MINIMARKET] SET QUERY_STORE = ON
GO
ALTER DATABASE [BD_MINIMARKET] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BD_MINIMARKET]
GO
/****** Object:  Table [dbo].[TB_ALMACENES]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALMACENES](
	[codigo_al] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_al] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_TB_ALMACENES] PRIMARY KEY CLUSTERED 
(
	[codigo_al] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CATEGORIAS]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CATEGORIAS](
	[codigo_ca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ca] [varchar](40) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_TB_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[codigo_ca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MARCAS]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MARCAS](
	[codigo_ma] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ma] [varchar](40) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_TB_MARCAS] PRIMARY KEY CLUSTERED 
(
	[codigo_ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PRODUCTOS]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PRODUCTOS](
	[codigo_pr] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_pr] [varchar](100) NULL,
	[codigo_ma] [int] NOT NULL,
	[codigo_um] [int] NOT NULL,
	[codigo_ca] [int] NOT NULL,
	[stock_min] [decimal](10, 2) NULL,
	[stock_max] [decimal](10, 2) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_TB_PRODUCTOS] PRIMARY KEY CLUSTERED 
(
	[codigo_pr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_STOCK_PRODUCTOS]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_STOCK_PRODUCTOS](
	[codigo_pr] [int] NULL,
	[codigo_al] [int] NULL,
	[stock_actual] [decimal](10, 2) NULL,
	[pu_compra] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_UNIDADES_MEDIDAS]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_UNIDADES_MEDIDAS](
	[codigo_um] [int] IDENTITY(1,1) NOT NULL,
	[abreviatura_um] [varchar](3) NULL,
	[descripcion_um] [varchar](20) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_TB_UNIDADES_MEDIDAS] PRIMARY KEY CLUSTERED 
(
	[codigo_um] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_TB_PRODUCTOS_TB_CATEGORIAS] FOREIGN KEY([codigo_ca])
REFERENCES [dbo].[TB_CATEGORIAS] ([codigo_ca])
GO
ALTER TABLE [dbo].[TB_PRODUCTOS] CHECK CONSTRAINT [FK_TB_PRODUCTOS_TB_CATEGORIAS]
GO
ALTER TABLE [dbo].[TB_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_TB_PRODUCTOS_TB_MARCAS] FOREIGN KEY([codigo_ma])
REFERENCES [dbo].[TB_MARCAS] ([codigo_ma])
GO
ALTER TABLE [dbo].[TB_PRODUCTOS] CHECK CONSTRAINT [FK_TB_PRODUCTOS_TB_MARCAS]
GO
ALTER TABLE [dbo].[TB_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_TB_PRODUCTOS_TB_UNIDADES_MEDIDAS] FOREIGN KEY([codigo_um])
REFERENCES [dbo].[TB_UNIDADES_MEDIDAS] ([codigo_um])
GO
ALTER TABLE [dbo].[TB_PRODUCTOS] CHECK CONSTRAINT [FK_TB_PRODUCTOS_TB_UNIDADES_MEDIDAS]
GO
ALTER TABLE [dbo].[TB_STOCK_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_TB_STOCK_PRODUCTOS_TB_ALMACENES] FOREIGN KEY([codigo_al])
REFERENCES [dbo].[TB_ALMACENES] ([codigo_al])
GO
ALTER TABLE [dbo].[TB_STOCK_PRODUCTOS] CHECK CONSTRAINT [FK_TB_STOCK_PRODUCTOS_TB_ALMACENES]
GO
ALTER TABLE [dbo].[TB_STOCK_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_TB_STOCK_PRODUCTOS_TB_PRODUCTOS] FOREIGN KEY([codigo_pr])
REFERENCES [dbo].[TB_PRODUCTOS] ([codigo_pr])
GO
ALTER TABLE [dbo].[TB_STOCK_PRODUCTOS] CHECK CONSTRAINT [FK_TB_STOCK_PRODUCTOS_TB_PRODUCTOS]
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_al]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_al] 
@nCodigo_al int=0    
as    
-- Actualiza estado a inactivo, se realiza eliminacion logica    
update TB_ALMACENES set estado=0 WHERE codigo_al = @nCodigo_al; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ca]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_ca]
@nCodigo_ca int=0
as
-- Actualiza estado a inactivo, se realiza eliminacion logica
update TB_CATEGORIAS set estado=0 WHERE codigo_ca = @nCodigo_ca;
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ma]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_ma]
@nCodigo_ma int=0  
as  
-- Actualiza estado a inactivo, se realiza eliminacion logica  
update TB_MARCAS set estado=0 WHERE codigo_ma = @nCodigo_ma;  
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_um]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_um]
@nCodigo_um int=0    
as    
-- Actualiza estado a inactivo, se realiza eliminacion logica    
update TB_UNIDADES_MEDIDAS set estado=0 WHERE codigo_um = @nCodigo_um; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_al]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Guardar_al] -- Tarea de insercion o actualizacion    
@nOpcion int=0,    
@nCodigo_al int=0,    
@cDescripcion_al varchar(50)=''    
as    
if @nOpcion = 1 -- Nuevo Registro    
begin    
 insert into TB_ALMACENES(descripcion_al, estado) values(@cDescripcion_al, 1);    
end;    
else -- Actualizar registro    
begin    
 update TB_ALMACENES set descripcion_al=@cDescripcion_al where codigo_al = @nCodigo_al;    
end; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ca]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Guardar_ca] -- Tarea de insercion o actualizacion
@nOpcion int=0,
@nCodigo_ca int=0,
@cDescripcion_ca varchar(40)=''
as
if @nOpcion = 1 -- Nuevo Registro
begin
	insert into TB_CATEGORIAS(descripcion_ca, estado) values(@cDescripcion_ca, 1);
end;
else -- Actualizar registro
begin
	update TB_CATEGORIAS set descripcion_ca=@cDescripcion_ca where codigo_ca = @nCodigo_ca;
end;
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ma]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Guardar_ma] -- Tarea de insercion o actualizacion  
@nOpcion int=0,  
@nCodigo_ma int=0,  
@cDescripcion_ma varchar(40)=''  
as  
if @nOpcion = 1 -- Nuevo Registro  
begin  
 insert into TB_MARCAS(descripcion_ma, estado) values(@cDescripcion_ma, 1);  
end;  
else -- Actualizar registro  
begin  
 update TB_MARCAS set descripcion_ma=@cDescripcion_ma where codigo_ma = @nCodigo_ma;  
end;  
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_um]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Guardar_um] -- Tarea de insercion o actualizacion    
@nOpcion int=0,    
@nCodigo_um int=0,    
@cAbreviatura_um varchar(3)='',
@cDescripcion_um varchar(20)=''   
as    
if @nOpcion = 1 -- Nuevo Registro    
begin    
 insert into TB_UNIDADES_MEDIDAS(abreviatura_um,
								 descripcion_um,
								 estado)
								 values(@cAbreviatura_um,
										@cDescripcion_um,
										1);    
end;    
else -- Actualizar registro    
begin    
 update TB_UNIDADES_MEDIDAS set abreviatura_um = @cAbreviatura_um,
								descripcion_um=@cDescripcion_um
							where codigo_um = @nCodigo_um;    
end; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_al]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[USP_Listado_al]
@cTexto varchar(50) =''    
as    
 select codigo_al, descripcion_al     
 from TB_ALMACENES   
 where estado = 1 and     
 upper(trim(cast(codigo_al as char))+trim(descripcion_al)) like '%'+upper(trim(@cTexto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ca]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[USP_Listado_ca]
@cTexto varchar(100) =''
as
	select codigo_ca, descripcion_ca 
	from TB_CATEGORIAS 
	where estado = 1 and 
	upper(trim(cast(codigo_ca as char))+trim(descripcion_ca)) like '%'+upper(trim(@cTexto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ma]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[USP_Listado_ma]
@cTexto varchar(40) =''  
as  
 select codigo_ma, descripcion_ma   
 from TB_MARCAS   
 where estado = 1 and   
 upper(trim(cast(codigo_ma as char))+trim(descripcion_ma)) like '%'+upper(trim(@cTexto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_um]    Script Date: 11/03/2024 03:40:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[USP_Listado_um]
@cTexto varchar(20) =''    
as    
 select codigo_um,
		abreviatura_um,
		descripcion_um
 from TB_UNIDADES_MEDIDAS
 where estado = 1 and     
 upper(trim(cast(codigo_um as char))+
		trim(abreviatura_um)+
		trim(descripcion_um)) like '%'+upper(trim(@cTexto))+'%';
GO
USE [master]
GO
ALTER DATABASE [BD_MINIMARKET] SET  READ_WRITE 
GO
