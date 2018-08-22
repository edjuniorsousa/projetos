USE [Estudos]
GO

/****** Object:  Table [dbo].[SolicitacaoAntecipacao]    Script Date: 22/08/2018 09:43:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitacaoAntecipacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataSolicitacao] [datetime] NOT NULL,
	[DataAnaliseInicio] [datetime] NULL,
	[DataAnaliseFim] [datetime] NULL,
	[Status] [varchar](1) NOT NULL,
	[Resultado] [varchar](10) NULL,
	[TransacaoId] [int] NULL,
	[ValorTotalTransacao] [float] NULL,
	[ValorTotalRepasse] [float] NULL,
 CONSTRAINT [PK_SolicitacaoAntecipacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitacaoAntecipacao]  WITH CHECK ADD  CONSTRAINT [FK_SolicitacaoAntecipacao_Transacao] FOREIGN KEY([TransacaoId])
REFERENCES [dbo].[Transacao] ([Id])
GO

ALTER TABLE [dbo].[SolicitacaoAntecipacao] CHECK CONSTRAINT [FK_SolicitacaoAntecipacao_Transacao]
GO


