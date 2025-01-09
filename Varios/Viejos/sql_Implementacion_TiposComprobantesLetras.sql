
CREATE TABLE [dbo].[TiposComprobantesLetras](
[IdTipoComprobante] [varchar](15) NOT NULL,
[Letra] [varchar](1) NOT NULL,
[ArchivoAImprimir] [varchar](100) NOT NULL,
[ArchivoAImprimirEmbebido] [bit] NOT NULL,
[NombreImpresora] [varchar](100) NULL,
CONSTRAINT [PK_TiposComprobantesLetras] PRIMARY KEY CLUSTERED 
(
[IdTipoComprobante] ASC,
[Letra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TiposComprobantesLetras] WITH CHECK ADD CONSTRAINT [FK_TiposComprobantesLetras_TiposComprobantesLetras] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[TiposComprobantesLetras] CHECK CONSTRAINT [FK_TiposComprobantesLetras_TiposComprobantesLetras]
GO
