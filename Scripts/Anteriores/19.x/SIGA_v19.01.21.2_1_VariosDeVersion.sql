PRINT '1. Traducciones'
-- SOLO PARA ALMAFUERTE
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('20231852698'))
BEGIN
	IF EXISTS (SELECT 1 FROM Traducciones WHERE IdFuncion = 'InfPedidosDetallados')
	BEGIN
		PRINT '1.1. InfPedidosDetallados Cambiar Nombre Etiqueta Precio x Tamaño'
		INSERT INTO [dbo].Traducciones
						(IdFuncion, Pantalla, Control, IdIdioma, Texto)
				VALUES
						('InfPedidosDetallados', '', 'PrecioVentaPorTamano', 'es_AR', '$ x Kg');
	END
	IF EXISTS (SELECT 1 FROM Traducciones WHERE IdFuncion = 'InfPresupuestosDetallados')	
	BEGIN
		PRINT '1.2. InfPresupuestosDetallados Cambiar Nombre Etiqueta Precio x Tamaño'
		INSERT INTO [dbo].Traducciones
						(IdFuncion, Pantalla, Control, IdIdioma, Texto)
				VALUES
						('InfPresupuestosDetallados', '', 'PrecioVentaPorTamano', 'es_AR', '$ x Kg');
	END

	IF EXISTS (SELECT 1 FROM Traducciones WHERE IdFuncion = 'PedidosAdmin')
	BEGIN
		PRINT '1.3. PedidosAdmin Cambiar Nombre Etiqueta Tamaño'
		INSERT INTO [dbo].Traducciones
						(IdFuncion, Pantalla, Control, IdIdioma, Texto)
				VALUES
						('PedidosAdmin', '', 'Tamano', 'es_AR', 'Kg Pieza');
	END

	IF EXISTS (SELECT 1 FROM Traducciones WHERE IdFuncion = 'PresupuestosAdmin')	
	BEGIN
		PRINT '1.4. PresupuestosAdmin Cambiar Nombre Etiqueta Precio x Tamaño'
		INSERT INTO [dbo].Traducciones
						(IdFuncion, Pantalla, Control, IdIdioma, Texto)
				VALUES
						('PresupuestosAdmin', '', 'Tamano', 'es_AR', 'Kg Pieza');
	END
END

PRINT ''
PRINT '2. Campo IdProveedorPreasignado en Cheques'
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
ALTER TABLE dbo.Cheques ADD IdProveedorPreasignado bigint NULL
GO
COMMIT

PRINT ''
PRINT '3. Parametro Cantidad de Decimales a guardar en VentasProductos'
-- SOLO HAR
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))

BEGIN
    MERGE INTO Parametros AS P
            USING (SELECT 'FACTURACIONDECIMALESGRABARDETALLEENPRECIO' AS IdParametro, '2' ValorParametro, 'Decimales Grabar Detalle En Precio'  AS DescripcionParametro)
            AS PT ON P.IdParametro = PT.IdParametro
        WHEN MATCHED THEN
            UPDATE SET P.ValorParametro = PT.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
    ;

END;
