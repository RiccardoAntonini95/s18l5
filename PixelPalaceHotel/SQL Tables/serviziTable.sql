USE [PixelPalaceHotel]
GO

/****** Object:  Table [dbo].[Servizi]    Script Date: 09/03/2024 12:56:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Servizi](
	[IdServizio] [int] IDENTITY(1,1) NOT NULL,
	[TipoServizio] [nvarchar](30) NOT NULL,
	[DataServizio] [datetime] NOT NULL,
	[Quantita] [int] NOT NULL,
	[Prezzo] [decimal](10, 2) NOT NULL,
	[IdPrenotazione] [int] NOT NULL,
 CONSTRAINT [PK_Servizi] PRIMARY KEY CLUSTERED 
(
	[IdServizio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Servizi]  WITH CHECK ADD  CONSTRAINT [FK_Servizi_Prenotazioni] FOREIGN KEY([IdPrenotazione])
REFERENCES [dbo].[Prenotazioni] ([IdPrenotazione])
GO

ALTER TABLE [dbo].[Servizi] CHECK CONSTRAINT [FK_Servizi_Prenotazioni]
GO

