
/****** Creacion de Tabla [AFIPTiposComprobantesTiposCbtes] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AFIPTiposComprobantesTiposCbtes](
	[IdAFIPTipoComprobante] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
 CONSTRAINT [PK_AFIPTiposComprobantesTiposCbtes] PRIMARY KEY CLUSTERED 
(
	[IdAFIPTipoComprobante] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AFIPTiposComprobantesTiposCbtes]  WITH CHECK ADD  CONSTRAINT [FK_AFIPTiposComprobantesTiposCbtes_AFIPTiposComprobantes] FOREIGN KEY([IdAFIPTipoComprobante])
REFERENCES [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante])
GO

ALTER TABLE [dbo].[AFIPTiposComprobantesTiposCbtes] CHECK CONSTRAINT [FK_AFIPTiposComprobantesTiposCbtes_AFIPTiposComprobantes]
GO


/****** Inserto los registros de tabla anterior ******/

INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante
           ,IdTipoComprobante
           ,Letra)
SELECT IdAFIPTipoComprobante
      ,IdTipoComprobante
      ,Letra
  FROM AFIPTiposComprobantes
  WHERE Letra IS NOT NULL
GO
  
  
/****** Inserto los registros de Facturacion Electronica ******/

INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (1, 'eFACT', 'A')
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (1, 'eREMITO', 'A')
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (3, 'eNCRED', 'A')
GO
	
INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (6, 'eFACT', 'B')
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (6, 'eREMITO', 'B')
GO
		
INSERT INTO AFIPTiposComprobantesTiposCbtes
   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
 VALUES
   (8, 'eNCRED', 'B')
GO
