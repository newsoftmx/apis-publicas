USE [dbMFC]
GO

/****** Object:  Table [dbo].[Abonos]    Script Date: 07/06/2019 12:57:52 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Abonos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Matrimonio_ID] [int] NOT NULL,
	[Fecha] [date] NULL,
	[Abono] [decimal](8, 2) NULL,
	[Observacion] [nvarchar](100) NULL,
 CONSTRAINT [PK_Abonos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Abonos]  WITH CHECK ADD  CONSTRAINT [FK_Abonos_Matrimonios] FOREIGN KEY([Matrimonio_ID])
REFERENCES [dbo].[Matrimonios] ([ID])
GO

ALTER TABLE [dbo].[Abonos] CHECK CONSTRAINT [FK_Abonos_Matrimonios]
GO
----------------------------------------------------------------------------------------USE [dbMFC]
GO

/****** Object:  Table [dbo].[Matrimonios]    Script Date: 07/06/2019 12:58:25 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Matrimonios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Matrimonio] [nvarchar](50) NOT NULL,
	[NombreEsposa] [nvarchar](100) NULL,
	[NombreEsposo] [nvarchar](100) NULL,
	[FechaMatrimonio] [date] NULL,
	[Nivel] [smallint] NULL,
	[Mensualidad] [decimal](8, 2) NULL,
	[ID_Usuario] [int] NULL,
 CONSTRAINT [PK_Matrimonios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Matrimonios]  WITH CHECK ADD  CONSTRAINT [FK_Matrimonios_Usuarios] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID])
GO

ALTER TABLE [dbo].[Matrimonios] CHECK CONSTRAINT [FK_Matrimonios_Usuarios]
GO

-----------------------------------------------------------------------------------------
USE [dbMFC]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/06/2019 12:58:52 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[Nivel_Usuario] [smallint] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



