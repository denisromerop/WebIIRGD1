USE [Campeonato]
GO

/****** Object:  Table [dbo].[Resultado]    Script Date: 10/08/2021 15:42:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP TABLE [dbo].[Resultado]

CREATE TABLE [dbo].[Resultado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Resultado]  WITH CHECK ADD  CONSTRAINT [FK_Resultado_Jogo] FOREIGN KEY([Id_Jogo])
REFERENCES [dbo].[Jogo] ([Id])
GO

ALTER TABLE [dbo].[Resultado] CHECK CONSTRAINT [FK_Resultado_Jogo]
GO

ALTER TABLE [dbo].[Resultado]  WITH CHECK ADD  CONSTRAINT [FK_Resultado_Time] FOREIGN KEY([Id_Time])
REFERENCES [dbo].[Time] ([Id])
GO

ALTER TABLE [dbo].[Resultado] CHECK CONSTRAINT [FK_Resultado_Time]
GO




