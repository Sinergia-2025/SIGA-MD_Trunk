PRINT ''
PRINT '1. Menu: Arreglar opción de menu en Metalsur'
IF dbo.BaseConCUIT('33631312379') = 1
BEGIN
    UPDATE Funciones
       SET Archivo = 'Eniac.SiGA.Win.Metalsur'
     WHERE Id = 'Backups'
END

PRINT ''
PRINT '2. REMITO DE TRANSPORTISTA: Actualización de registros inconsistentes SubTotal'
UPDATE V SET V.SubTotal = V.ValorDeclarado FROM Ventas V WHERE IdTipoComprobante = 'REMITOTRANSP' AND V.SubTotal = 0
GO

DECLARE @um char(2) = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas WHERE IdUnidadDeMedida = 'UN')

IF @um IS NULL
    SET @um = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas)

PRINT @um

PRINT ''
PRINT '3. Tabla Productos: Actualización de registros pre-existentes'
UPDATE P SET P.IdUnidadDeMedida = @um, P.Tamano = 1 FROM Productos P WHERE P.IdUnidadDeMedida IS NULL
UPDATE P SET P.Conversion = 1 FROM Productos P WHERE P.Conversion = 0
GO
