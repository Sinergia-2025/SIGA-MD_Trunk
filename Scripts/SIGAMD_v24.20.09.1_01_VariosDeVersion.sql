PRINT ''
PRINT '1. Parametros: Configurar visivilidad de opcion Modelo Forma solo para Asa'

IF dbo.BaseConCuit('30676889376') = 1
BEGIN
    Update Parametros 
		SET ValorParametro = 'True' 
	WHERE Idparametro = 'ORDPRODMOSTRARPRODUCTOMODELOFORMA'
END
GO

--Verificación de que la Base no sea la de HAR GROUP
IF dbo.SoyHAR() = 0
BEGIN
	--Al NO ser la Base de HAR GROUP, comienza la sentencia
	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'ConsultarCAE'))
	BEGIN
		DELETE RolesFunciones WHERE IdFuncion = 'ConsultarCAE'
		DELETE Funciones WHERE Id = 'ConsultarCAE'
		PRINT 'Se eliminó la función "ConsultarCAE"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "ConsultarCAE"'
	END
END
ELSE --La Base SÍ es de HAR GROUP, no se elimina la función de Administrador
BEGIN
    PRINT 'Script corrido sobre HAR GROUP, no se elimina la función "ConsultarCAE"'
END
