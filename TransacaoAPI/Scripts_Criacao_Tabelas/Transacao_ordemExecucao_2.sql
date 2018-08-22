USE [Estudos]
GO

/****** Object:  Table [dbo].[Transacao]    Script Date: 22/08/2018 09:43:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Transacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataTransacao] [datetime] NOT NULL,
	[DataRepasse] [datetime] NULL,
	[Confirmacao] [varchar](10) NULL,
	[ValorTransacao] [float] NOT NULL,
	[IdTaxa] [int] NULL,
	[ValorRepasse] [float] NULL,
	[NumeroParcelas] [int] NOT NULL,
 CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Taxa] FOREIGN KEY([IdTaxa])
REFERENCES [dbo].[Taxa] ([Id])
GO

ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Taxa]
GO


