SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Nueva tabla ArchivosImportados'
CREATE TABLE [dbo].[ArchivosImportados](
	[IdFuncion] [varchar](30) NOT NULL,
	[IdSubFuncion] [varchar](30) NOT NULL,
	[NombreArchivo] [varchar](256) NOT NULL,
	[FechaLectura] [datetime] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[NombrePC] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ArchivosImportados] PRIMARY KEY CLUSTERED 
([IdFuncion] ASC,[IdSubFuncion] ASC,[NombreArchivo] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ArchivosImportados]  WITH CHECK ADD  CONSTRAINT [FK_ArchivosImportados_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO
ALTER TABLE [dbo].[ArchivosImportados] CHECK CONSTRAINT [FK_ArchivosImportados_Funciones]
GO

ALTER TABLE [dbo].[ArchivosImportados]  WITH CHECK ADD  CONSTRAINT [FK_ArchivosImportados_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[ArchivosImportados] CHECK CONSTRAINT [FK_ArchivosImportados_Usuarios]
GO


PRINT ''
PRINT '3.Parametro: Pago mis Cuentas Valor por Defecto'
DECLARE @idParametro VARCHAR(MAX) = 'PMCFORMATO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Formato PMC'
DECLARE @valorParametro VARCHAR(MAX) = 'PMC'

IF dbo.BaseConCuit('30714374938') = 'True' -- EduViajes
BEGIN
    SET @valorParametro = 'ROELAPMC'
END

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


PRINT ''
PRINT '4. Configuraciones iniciales para EduViajes'
IF dbo.BaseConCuit('30714374938') = 'True' -- EduViajes
BEGIN
    PRINT ''
    PRINT '4.1. Definir impresora PorCuentaOrden para ver comprobante FICHA en PMC'
    UPDATE Impresoras SET PorCtaOrden = 1 WHERE IdImpresora = 'NORMAL'


    -- PARA EDUVIAJES
    PRINT ''
    PRINT '4.2. Reporte para imprimir Fichas'
    INSERT [dbo].[TiposComprobantesLetras] 
                ([IdTipoComprobante], [Letra], 
                 [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora], [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], 
                 [ArchivoAImprimir2], [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido]) 
        VALUES  ('FICHAS', 'X', 
                 '357_Cuota.rdlc', 'False', '', 99, 98, 1, 1, 
                 '', 'False', '', 'False')
END
