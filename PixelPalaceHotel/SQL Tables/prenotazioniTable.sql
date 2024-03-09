USE [PixelPalaceHotel]
GO

/****** Object:  Table [dbo].[Prenotazioni]    Script Date: 09/03/2024 12:56:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prenotazioni](
	[IdPrenotazione] [int] IDENTITY(1,1) NOT NULL,
	[CodiceFiscale] [nvarchar](16) NOT NULL,
	[Cognome] [nvarchar](20) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Citta] [nvarchar](20) NULL,
	[Provincia] [nvarchar](20) NULL,
	[Email] [nvarchar](25) NULL,
	[Tel] [int] NULL,
	[Cell] [int] NOT NULL,
	[IdCamera] [int] NOT NULL,
	[DataPrenotazione] [date] NOT NULL,
	[InizioSoggiorno] [date] NOT NULL,
	[FineSoggiorno] [date] NOT NULL,
	[Anno] [int] NOT NULL,
	[Caparra] [decimal](10, 2) NOT NULL,
	[Tariffa] [decimal](10, 2) NOT NULL,
	[TipoSoggiorno] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Prenotazioni] PRIMARY KEY CLUSTERED 
(
	[IdPrenotazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD  CONSTRAINT [FK_Prenotazioni_Camere] FOREIGN KEY([IdCamera])
REFERENCES [dbo].[Camere] ([IdCamera])
GO

ALTER TABLE [dbo].[Prenotazioni] CHECK CONSTRAINT [FK_Prenotazioni_Camere]
GO

