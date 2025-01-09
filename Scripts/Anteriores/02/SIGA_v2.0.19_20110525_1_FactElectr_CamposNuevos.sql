--creo tabla nueva
CREATE TABLE [dbo].[AFIPIVAs](
	[IdAFIPIVA] [int] NOT NULL,
	[DescripcionAFIPIVA] [varchar](50) NULL,
	[IdTipoImpuesto] [varchar](5) NULL,
	[Alicuota] [decimal](6, 2) NULL,
 CONSTRAINT [PK_AFIPIVAs] PRIMARY KEY CLUSTERED 
(
	[IdAFIPIVA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AFIPIVAs]  WITH CHECK ADD  CONSTRAINT [FK_AFIPIVAs_Impuestos] FOREIGN KEY([IdTipoImpuesto], [Alicuota])
REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota])
GO

ALTER TABLE [dbo].[AFIPIVAs] CHECK CONSTRAINT [FK_AFIPIVAs_Impuestos]
GO

--inserto registros a la tabla


INSERT INTO [AFIPIVAs]([IdAFIPIVA],[DescripcionAFIPIVA],[IdTipoImpuesto],[Alicuota])
  VALUES(3,'0%','IVA',0.00)
GO

INSERT INTO [AFIPIVAs]([IdAFIPIVA],[DescripcionAFIPIVA],[IdTipoImpuesto],[Alicuota])
  VALUES(4,'10.5%','IVA',10.50) 
GO

INSERT INTO [AFIPIVAs]([IdAFIPIVA],[DescripcionAFIPIVA],[IdTipoImpuesto],[Alicuota])
  VALUES(5,'21%','IVA',21.00) 
GO

INSERT INTO [AFIPIVAs]([IdAFIPIVA],[DescripcionAFIPIVA],[IdTipoImpuesto],[Alicuota])
  VALUES(6,'27%','IVA',27.00) 
GO
  
  
--------------------------
---crea columna para preguntar si es electronico
ALTER TABLE TiposComprobantes ADD EsElectronico bit NULL
GO

UPDATE TiposComprobantes SET EsElectronico = 'False'
GO

INSERT INTO TiposComprobantes 
     ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable]

     ,[LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador]

     ,[AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias]

     ,[EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario]

     ,[ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico])

  VALUES ('eFACT', 'False', 'eFactura', 'VENTAS', -1, 'True' , 'False'

         ,'A,B,C', 24, 'True', 1, null, 'True'

         ,'True', 'True', 'True' ,'eFactura' ,'False' ,2

         ,'False', null, 'True' ,0 ,null

         ,0 ,'.' , 'False', 0.1 , 'True')
GO

ALTER TABLE TiposComprobantes ALTER COLUMN EsElectronico bit NOT NULL
GO


ALTER TABLE Ventas ADD CAE varchar(30) NULL
GO

ALTER TABLE Ventas ADD CAEVencimiento datetime NULL
GO


