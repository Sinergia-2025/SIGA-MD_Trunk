-----------------------------------------------------------------------------------------------------------------------------------
/* Script borra funciones "Liquidación de tarjetas" y "Anular liquidaciones de tarjetas" */
IF dbo.SoyHAR() = 0
BEGIN
	--Al NO ser la Base de HAR GROUP, comienza la sentencia
	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'AnularLiquidacionesTarjetas'))
	BEGIN
        DELETE Traducciones WHERE IdFuncion = 'AnularLiquidacionesTarjetas'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'AnularLiquidacionesTarjetas'
        DELETE RolesFunciones WHERE IdFuncion = 'AnularLiquidacionesTarjetas'
		DELETE Funciones WHERE Id = 'AnularLiquidacionesTarjetas'
		PRINT 'Se eliminó la función "Anular Liquidaciones de Tarjetas" en Bancos'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Anular Liquidaciones de Tarjetas" en Bancos'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'LiquidacionesTarjeta'))
	BEGIN
        DELETE Traducciones WHERE IdFuncion = 'LiquidacionesTarjeta'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'LiquidacionesTarjeta'
        DELETE RolesFunciones WHERE IdFuncion = 'LiquidacionesTarjeta'
        DELETE Funciones WHERE Id = 'LiquidacionesTarjeta'
		PRINT 'Se eliminó la función "Liquidaciones de Tarjetas" en Bancos'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Liquidaciones de Tarjetas" en Bancos'
	END
END
ELSE --La Base SÍ es de HAR GROUP, no se eliminan las funciones "Anular Liquidaciones de Tarjetas" ni "Liquidaciones de Tarjetas" en Bancos
BEGIN
    PRINT 'Script corrido sobre HAR GROUP, no se eliminan las funciones "Anular Liquidaciones de Tarjetas" ni "Liquidaciones de Tarjetas" en Bancos'
END
GO
-----------------------------------------------------------------------------------------------------------------------------------
DECLARE @sql NVARCHAR(MAX);
IF dbo.ExisteCampo('Pedidos', 'Validezpresupuesto') = 1
BEGIN
    SET @sql = '
    IF EXISTS (SELECT * FROM Pedidos WHERE validezpresupuesto IS NULL)
    BEGIN
        UPDATE Pedidos
        SET Validezpresupuesto = 7
        WHERE validezpresupuesto IS NULL;
        PRINT ''Se corrigieron Pedidos.''
    END
    ELSE
    BEGIN
        PRINT ''No existían Pedidos por corregir.''
    END
    ';
    EXEC sp_executesql @sql;
END
ELSE
BEGIN
    PRINT 'La columna "Validezpresupuesto" no existe en esta versión de SIGA.'
END
GO
----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Parametros: Producto se puede usar como Devolución'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPERMITEESDEVUELTO'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto se puede usar como Devolución'
	DECLARE @valorParametro VARCHAR(MAX) = '0'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
	;
END
GO

PRINT ''
PRINT '2. Nuevo Campo Producto: EsDevuelto'
IF dbo.ExisteCampo('Productos','EsDevuelto') = 0
BEGIN
	ALTER TABLE Productos ADD EsDevuelto bit NULL
END
GO

PRINT ''
PRINT '3. Nuevo Campo Producto: EsDevuelto'
IF dbo.ExisteCampo('Productos','EsDevuelto') = 1
BEGIN
	UPDATE Productos SET EsDevuelto = 0
	ALTER TABLE Productos ALTER COLUMN EsDevuelto bit NOT NULL
END
GO

PRINT ''
PRINT '4. Nuevo Campo AuditoriaProducto: EsDevuelto'
IF dbo.ExisteCampo('AuditoriaProductos','EsDevuelto') = 0
BEGIN
	ALTER TABLE AuditoriaProductos ADD EsDevuelto bit NULL
END
GO

PRINT ''
PRINT '5. Nuevo Campo AuditoriaProducto: EsDevuelto'
IF dbo.ExisteCampo('AuditoriaProductos','EsDevuelto') = 1
BEGIN
	UPDATE AuditoriaProductos SET EsDevuelto = 0
	ALTER TABLE AuditoriaProductos ALTER COLUMN EsDevuelto bit NOT NULL
END
GO
-----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '6. Nuevo funcion Alerta Salto Numeracion'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo, EsMDIChild)
    VALUES
        ('AlertaSaltoNumeracion', 'Alerta Salto de Numeración', 'Alerta Salto de Numeración', 'False', 'False', 'True', 'False'
        ,'Ventas', 999, 'Eniac.Win', 'AlertaSaltoNumeracion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL, 1)
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AlertaSaltoNumeracion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'AdmSinergia')
END
GO
-----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '7. Cambio en el campo FormulaCalculoKilaje de ProduccionFormas'
BEGIN
	ALTER TABLE ProduccionFormas ALTER COLUMN FormulaCalculoKilaje varchar(2000) NOT NULL
END
GO
-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------
