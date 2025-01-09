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

---------------------------------------------------------------------------------------------------------------------------------
/* Script para corregir Pedidos viejos */

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

----------------------------------------------------------------------------------------------------------------------------------
