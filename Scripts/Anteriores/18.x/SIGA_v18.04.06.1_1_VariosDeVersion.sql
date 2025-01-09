
PRINT '1. Campos_Cajas_F10.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CajasNombres ADD IdTipoComprobanteF10Origen varchar(15) NULL
ALTER TABLE dbo.CajasNombres ADD IdTipoComprobanteF10Destino varchar(15) NULL
GO
ALTER TABLE dbo.CajasNombres ADD CONSTRAINT FK_CajasNombres_TiposComprobantes_F10O 
	FOREIGN KEY (IdTipoComprobanteF10Origen)
	REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CajasNombres ADD CONSTRAINT FK_CajasNombres_TiposComprobantes_F10D
	FOREIGN KEY (IdTipoComprobanteF10Destino)
	REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CajasNombres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '2. Seteos_Cambiar_COMPRASDECIMALESREDONDEOENPRECIO_de_2a4.'
GO

DECLARE @valorActualACambiar varchar(MAX) = '2'
DECLARE @valorNuevoACambiar varchar(MAX) = '4'
DECLARE @valorParametroActual varchar(MAX)
SELECT @valorParametroActual = ValorParametro
  FROM Parametros
 WHERE IdParametro = 'COMPRASDECIMALESREDONDEOENPRECIO'
SET @valorParametroActual = ISNULL(@valorParametroActual, '2');

PRINT '1. Cambio el valor de COMPRASDECIMALESREDONDEOENPRECIO si actualmente es ' + @valorActualACambiar
PRINT '1.1. Valor actual de COMPRASDECIMALESREDONDEOENPRECIO ' + @valorParametroActual

IF @valorParametroActual = @valorActualACambiar
	BEGIN
		PRINT '1.2. Se cambia el valor de COMPRASDECIMALESREDONDEOENPRECIO a ' + @valorNuevoACambiar
		MERGE INTO Parametros AS P
			 USING (SELECT 'COMPRASDECIMALESREDONDEOENPRECIO' AS IdParametro
						   ,@valorNuevoACambiar ValorParametro
						   ,NULL AS CategoriaParametro
						   ,'Decimales Redondeo Precio' AS DescripcionParametro) AS PT
				ON P.IdParametro = PT.IdParametro
		 WHEN MATCHED THEN
			UPDATE
			   SET P.ValorParametro = PT.ValorParametro
		 WHEN NOT MATCHED THEN
			INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
			VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
		;

	END
