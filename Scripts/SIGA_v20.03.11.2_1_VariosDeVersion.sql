IF dbo.ExisteFuncion('CuentasCorrientes') = 1
BEGIN

	PRINT ''
	PRINT '1.1. Agregar opción de Menu: Impresión Masiva de Cuotas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ImpresionMasivaDeCuotas', 'Impresion Masiva De Cuotas', 'Impresion Masiva De Cuotas', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 19, 'Eniac.Win', 'ImpresionMasivaDeCuotas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImpresionMasivaDeCuotas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END


PRINT ''
PRINT '2. Tabla ReservasPasajeros: Campo CentroEmisorComprobante como int'
ALTER TABLE ReservasPasajeros ALTER COLUMN CentroEmisorComprobante int null
GO


PRINT ''
PRINT '2. Tabla ReservasPasajeros: FK a Ventas'
ALTER TABLE [dbo].[ReservasPasajeros]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPasajeros_Ventas] FOREIGN KEY([IdTipoComprobante], [LetraComprobante], [CentroEmisorComprobante], [NumeroComprobante], [IdSucursalComprobante])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[ReservasPasajeros] CHECK CONSTRAINT [FK_ReservasPasajeros_Ventas]
GO

