USE [Campeonato]
GO

/****** Object:  Table [dbo].[Resultado]    Script Date: 10/08/2021 15:42:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP TABLE [dbo].[Resultado]

CREATE TABLE [dbo].[Resultado](
	[id_jogo] [int] NOT NULL,
	[id_time] [int] NOT NULL,
	[vitorias] [int] NULL,
	[empates] [int] NULL,
	[derrotas] [int] NULL,
	[golsPro] [int] NULL,
	[golsContra] [int] NULL,
	[saldodeGol] [int] NULL,
	[qtdjogos] [int] NULL,
	[PontosGanhos] [int] NULL,
 CONSTRAINT [PK_Resultado] PRIMARY KEY CLUSTERED 
(
	[id_jogo],[id_time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


