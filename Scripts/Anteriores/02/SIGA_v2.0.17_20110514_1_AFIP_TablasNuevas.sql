BEGIN TRANSACTION

CREATE TABLE [AFIPTiposComprobantes](
	[IdAFIPTipoComprobante] [int] NOT NULL,
	[NombreAFIPTipoComprobante] [varchar](100) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[Letra] [varchar](1) NULL,
 CONSTRAINT [PK_AFIPTiposComprobantes] PRIMARY KEY CLUSTERED 
(
	[IdAFIPTipoComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT N'Se creo la tabla [AFIPTiposComprobantes]...';

ALTER TABLE [dbo].[AFIPTiposComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_AFIPTiposComprobantes_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[AFIPTiposComprobantes] CHECK CONSTRAINT [FK_AFIPTiposComprobantes_TiposComprobantes]
GO

PRINT N'Se crearon los indices...';


-----


CREATE TABLE [AFIPTiposDocumentos](
	[IdAFIPTipoDocumento] [int] NOT NULL,
	[NombreAFIPTipoDocumento] [varchar](50) NULL,
	[TipoDocumento] [varchar](5) NULL,
 CONSTRAINT [PK_AFIPTiposDocumentos] PRIMARY KEY CLUSTERED 
(
	[IdAFIPTipoDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
PRINT N'Se creo la tabla [AFIPTiposDocumentos]...';


ALTER TABLE [dbo].[AFIPTiposDocumentos]  WITH CHECK ADD  CONSTRAINT [FK_AFIPTiposDocumentos_TiposDocumento] FOREIGN KEY([TipoDocumento])
REFERENCES [dbo].[TiposDocumento] ([TipoDocumento])
GO

ALTER TABLE [dbo].[AFIPTiposDocumentos] CHECK CONSTRAINT [FK_AFIPTiposDocumentos_TiposDocumento]
GO

PRINT N'Se crearon los incides...';

-------

ALTER TABLE [dbo].[AFIPTiposDocumentos] DROP CONSTRAINT [FK_AFIPTiposDocumentos_TiposDocumento]


ALTER TABLE [dbo].[AFIPTiposDocumentos] ADD CONSTRAINT [FK_AFIPTiposDocumentos_TiposDocumento] FOREIGN KEY ([TipoDocumento]) REFERENCES [dbo].[TiposDocumento] ([TipoDocumento])

COMMIT TRANSACTION


------------------------------------
BEGIN TRANSACTION
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (0, N'CI Policía Federal', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (1, N'CI Buenos Aires', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (2, N'CI Catamarca', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (3, N'CI Córdoba', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (4, N'CI Corrientes', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (5, N'CI Entre Ríos', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (6, N'CI Jujuy', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (7, N'CI Mendoza', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (8, N'CI La Rioja', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (9, N'CI Salta', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (10, N'CI San Juan', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (11, N'CI San Luis', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (12, N'CI Santa Fe', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (13, N'CI Santiago del Estero', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (14, N'CI Tucumán', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (16, N'CI Chaco', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (17, N'CI Chubut', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (18, N'CI Formosa', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (19, N'CI Misiones', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (20, N'CI Neuquén', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (21, N'CI La Pampa', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (22, N'CI Río Negro', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (23, N'CI Santa Cruz', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (24, N'CI Tierra del Fuego', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (30, N'Certificado de Migración', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (80, N'CUIT', N'CUIT')
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (86, N'CUIL', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (87, N'CDI', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (88, N'Usado por Anses para Padrón', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (89, N'LE', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (90, N'LC', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (91, N'CI extranjera', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (92, N'en trámite', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (93, N'Acta nacimiento', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (94, N'Pasaporte', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (95, N'CI Bs. As. RNP', NULL)
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (96, N'DNI', N'DNI')
INSERT INTO [dbo].[AFIPTiposDocumentos] ([IdAFIPTipoDocumento], [NombreAFIPTipoDocumento], [TipoDocumento]) VALUES (99, N'Sin identificar/venta global diaria', NULL)
COMMIT TRANSACTION
------------------------------------





------------------------------------
BEGIN TRANSACTION
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (1, N'FACTURAS A', N'FACT', N'A')
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (2, N'NOTAS DE DEBITO A', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (3, N'NOTAS DE CREDITO A', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (4, N'RECIBOS A', N'RECIBO', N'A')
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (5, N'NOTAS DE VENTA AL CONTADO A', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (6, N'FACTURAS B', N'FACT', N'B')
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (7, N'NOTAS DE DEBITO B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (8, N'NOTAS DE CREDITO B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (9, N'RECIBOS B', N'RECIBO', N'B')
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (10, N'NOTAS DE VENTA AL CONTADO B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (11, N'FACTURAS C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (12, N'NOTAS DE DEBITO C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (13, N'NOTAS DE CREDITO C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (14, N'DOCUMENTO ADUANERO', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (15, N'RECIBOS C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (16, N'NOTAS DE VENTA AL CONTADO C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (19, N'FACTURAS DE EXPORTACION', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (20, N'NOTAS DE DEBITO POR OPERACIONES CON EL EXTERIOR', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (21, N'NOTAS DE CREDITO POR OPERACIONES CON EL EXTERIOR', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (22, N'FACTURAS - PERMISO EXPORTACION SIMPLIFICADO - DTO. 855/97', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (30, N'COMPROBANTES DE COMPRA DE BIENES USADOS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (31, N'MANDATO - CONSIGNACION', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (32, N'COMPROBANTES PARA RECICLAR MATERIALES', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (34, N'COMPROBANTES A DEL APARTADO A  INCISO F  R G  N  1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (35, N'COMPROBANTES B DEL ANEXO I, APARTADO A, INC. F), RG N° 1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (36, N'COMPROBANTES C DEL Anexo I, Apartado A, INC.F), R.G. N° 1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (37, N'NOTAS DE DEBITO O DOCUMENTO EQUIVALENTE QUE CUMPLAN CON LA R.G. N° 1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (38, N'NOTAS DE CREDITO O DOCMENTO EQUIVALENTE QUE CUMPLAN CON LA R.G. N° 1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (39, N'OTROS COMPROBANTES A QUE CUMPLEN CON LA R G  1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (40, N'OTROS COMPROBANTES B QUE CUMPLAN CON LA R.G. N° 1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (41, N'OTROS COMPROBANTES C QUE CUMPLAN CON LA R.G. N° 1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (50, N'RECIBO FACTURA A  REGIMEN DE FACTURA DE CREDITO ', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (51, N'FACTURAS M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (52, N'NOTAS DE DEBITO M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (53, N'NOTAS DE CREDITO M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (54, N'RECIBOS M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (55, N'NOTAS DE VENTA AL CONTADO M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (56, N'COMPROBANTES M DEL ANEXO I  APARTADO A  INC F   R G  N  1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (57, N'OTROS COMPROBANTES M QUE CUMPLAN CON LA R G  N  1415', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (58, N'CUENTAS DE VENTA Y LIQUIDO PRODUCTO M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (59, N'LIQUIDACIONES M', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (60, N'CUENTAS DE VENTA Y LIQUIDO PRODUCTO A', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (61, N'CUENTAS DE VENTA Y LIQUIDO PRODUCTO B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (63, N'LIQUIDACIONES A', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (64, N'LIQUIDACIONES B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (65, N'NOTAS DE CREDITO DE COMPROBANTES CON COD. 34, 39, 58, 59, 60, 63, 96, 97 ', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (66, N'DESPACHO DE IMPORTACION', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (67, N'IMPORTACION DE SERVICIOS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (68, N'LIQUIDACION C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (70, N'RECIBOS FACTURA DE CREDITO', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (71, N'CREDITO FISCAL POR CONTRIBUCIONES PATRONALES', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (73, N'FORMULARIO 1116 RT', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (74, N'CARTA DE PORTE PARA EL TRANSPORTE AUTOMOTOR PARA GRANOS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (75, N'CARTA DE PORTE PARA EL TRANSPORTE FERROVIARIO PARA GRANOS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (80, N'COMPROBANTE DIARIO DE CIERRE (ZETA)', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (81, N'TIQUE FACTURA A   CONTROLADORES FISCALES', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (82, N'TIQUE - FACTURA B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (83, N'TIQUE', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (84, N'COMPROBANTE   FACTURA DE SERVICIOS PUBLICOS   INTERESES FINANCIEROS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (85, N'NOTA DE CREDITO   SERVICIOS PUBLICOS   NOTA DE CREDITO CONTROLADORES FISCALES', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (86, N'NOTA DE DEBITO   SERVICIOS PUBLICOS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (87, N'OTROS COMPROBANTES - SERVICIOS DEL EXTERIOR', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (88, N'OTROS COMPROBANTES - DOCUMENTOS EXCEPTUADOS / REMITO ELECTRONICO ', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (89, N'OTROS COMPROBANTES - DOCUMENTOS EXCEPTUADOS - NOTAS DE DEBITO / RESUMEN DE DATOS', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (90, N'OTROS COMPROBANTES - DOCUMENTOS EXCEPTUADOS - NOTAS DE CREDITO', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (91, N'REMITOS R', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (92, N'AJUSTES CONTABLES QUE INCREMENTAN EL DEBITO FISCAL', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (93, N'AJUSTES CONTABLES QUE DISMINUYEN EL DEBITO FISCAL', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (94, N'AJUSTES CONTABLES QUE INCREMENTAN EL CREDITO FISCAL', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (95, N'AJUSTES CONTABLES QUE DISMINUYEN EL CREDITO FISCAL', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (96, N'FORMULARIO 1116 B', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (97, N'FORMULARIO 1116 C', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (99, N'OTROS COMP  QUE NO CUMPLEN CON LA R G  3419 Y SUS MODIF ', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (101, N'AJUSTE ANUAL PROVENIENTE DE LA  D J  DEL IVA  POSITIVO ', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (102, N'AJUSTE ANUAL PROVENIENTE DE LA  D J  DEL IVA  NEGATIVO ', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (103, N'NOTA DE ASIGNACION', NULL, NULL)
INSERT INTO [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante], [NombreAFIPTipoComprobante], [IdTipoComprobante], [Letra]) VALUES (104, N'NOTA DE CREDITO DE ASIGNACION', NULL, NULL)
COMMIT TRANSACTION
------------------------------------
