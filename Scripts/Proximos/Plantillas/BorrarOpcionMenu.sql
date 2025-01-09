IF dbo.SoyHAR() = 0
BEGIN
    DECLARE @idFuncion VARCHAR(MAX) = 'LiquidacionesTarjeta'

    DELETE FROM Bitacora WHERE IdFuncion = @idFuncion
    DELETE FROM RolesFunciones WHERE IdFuncion = @idFuncion
    DELETE FROM Funciones WHERE Id = @idFuncion
END
