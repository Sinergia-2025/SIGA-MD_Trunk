PRINT ''
PRINT '1. ADD FOREIGN KEY PRODUCTOS: Campo IdFormula referenciado a ProductosFormula'

IF OBJECT_ID('FK_Productos_ProductosFormulas') IS NULL 
BEGIN
    PRINT ''
    PRINT '1.1. Ajustar información pre-existente'
    UPDATE P
       SET IdFormula = NULL
      FROM Productos P
     WHERE P.IdFormula IS NOT NULL
       AND NOT EXISTS (SELECT * FROM ProductosFormulas PF WHERE PF.IdProducto = P.IdProducto AND PF.IdFormula = P.IdFormula)

    PRINT ''
    PRINT '1.2. ADD FOREIGN KEY PRODUCTOS: Agregando'
	ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_ProductosFormulas] FOREIGN KEY([IdProducto], [IdFormula])
	REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
	ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_ProductosFormulas]
END

PRINT ''
PRINT '2. Tabla ClientesActualizacionesSucesos: Nuevos campos para control de actualizador automatico'
PRINT ''
PRINT '2.0. Tabla ClientesActualizacionesSucesos: Limpio la tabla porque hasta ahora son solo pruebas'
DELETE FROM ClientesActualizacionesSucesos
DELETE FROM ClientesActualizaciones

PRINT ''
PRINT '2.1. Tabla ClientesActualizacionesSucesos: Agregar nuevos campos'
ALTER TABLE dbo.ClientesActualizacionesSucesos ADD Mensaje varchar(1000) NULL
ALTER TABLE dbo.ClientesActualizacionesSucesos ADD NombreScript varchar(100) NULL
ALTER TABLE dbo.ClientesActualizacionesSucesos ADD Script text NULL
GO

PRINT ''
PRINT '2.2. Tabla ClientesActualizacionesSucesos: Valores por defecto para campo (pero la tabla está vacia, no habria problemas)'
UPDATE ClientesActualizacionesSucesos
   SET Mensaje = ''
     , NombreScript = ''
     , Script = ''
PRINT ''
PRINT '2.3. Tabla ClientesActualizacionesSucesos: Campos en NOT NULL'
ALTER TABLE dbo.ClientesActualizacionesSucesos ALTER COLUMN Mensaje varchar(1000) NOT NULL
ALTER TABLE dbo.ClientesActualizacionesSucesos ALTER COLUMN NombreScript varchar(100) NOT NULL
ALTER TABLE dbo.ClientesActualizacionesSucesos ALTER COLUMN Script text NOT NULL
GO


PRINT ''
PRINT '3. Correción de los Parámetros CANTIDADLINEASDEPRODUCTOAEVALUARPARADESCRECARGO y PORCENTAJEDEDESCRECARGOPORLINEADEPRODUCTO cuando el valor está vacio.'

IF (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'CANTIDADLINEASDEPRODUCTOAEVALUARPARADESCRECARGO') = ''
	UPDATE Parametros SET ValorParametro = 0 WHERE IdParametro = 'CANTIDADLINEASDEPRODUCTOAEVALUARPARADESCRECARGO'
IF (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'PORCENTAJEDEDESCRECARGOPORLINEADEPRODUCTO') = ''
	UPDATE Parametros SET ValorParametro = 0 WHERE IdParametro = 'PORCENTAJEDEDESCRECARGOPORLINEADEPRODUCTO'

PRINT ''
PRINT '4. Menu Turismo: Eliminar de todo quien no sea empresa de Turismo'
IF dbo.SoyHAR() = 'False' AND dbo.BaseConCuit('30714374938') = 'False'
BEGIN
    DELETE FROM Bitacora WHERE IdFuncion IN ('EstadosTurismoABM', 'Turismo')
    DELETE FROM RolesFunciones WHERE IdFuncion IN ('EstadosTurismoABM', 'Turismo')
    DELETE FROM Funciones WHERE Id IN ('EstadosTurismoABM')
    DELETE FROM Funciones WHERE Id IN ('Turismo')
END
