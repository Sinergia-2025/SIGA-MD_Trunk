PRINT ''
PRINT '1. Menu: Eliminar función InfPedidosFacturados'
IF dbo.SoyHAR() = 'False'
BEGIN
    DELETE Bitacora WHERE IdFuncion = 'InfPedidosFacturados'
    DELETE RolesFunciones WHERE IdFuncion = 'InfPedidosFacturados'
    DELETE Funciones WHERE Id = 'InfPedidosFacturados'
END

PRINT ''
PRINT '2. Tabla Ventas: Nueva columna NroVersionAplicacion'
ALTER TABLE dbo.Ventas ADD NroVersionAplicacion varchar(50) NULL
