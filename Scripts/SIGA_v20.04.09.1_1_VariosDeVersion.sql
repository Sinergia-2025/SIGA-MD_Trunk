PRINT ''
PRINT '1. Tabla Cliente: Nuevos campos para calculo de Estrellas'
ALTER TABLE dbo.Clientes ADD ValorizacionFacturacionMensual decimal(12, 2) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionCoeficienteFacturacion decimal(5, 2) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionFacturacion decimal(18, 4) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionImporteAdeudado decimal(12, 2) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionCoeficienteDeuda decimal(5, 2) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionDeuda decimal(18, 4) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionProyecto decimal(18, 4) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionCliente decimal(18, 4) NULL
ALTER TABLE dbo.Clientes ADD ValorizacionEstrellas decimal(5, 2) NULL

PRINT ''
PRINT '2. Tabla AuditoriaClientes: Nuevos campos para calculo de Estrellas'
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionFacturacionMensual decimal(12, 2) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionCoeficienteFacturacion decimal(5, 2) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionFacturacion decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionImporteAdeudado decimal(12, 2) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionCoeficienteDeuda decimal(5, 2) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionDeuda decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionProyecto decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionCliente decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionEstrellas decimal(5, 2) NULL


PRINT ''
PRINT '3. Tabla Prospectos: Nuevos campos para calculo de Estrellas'
ALTER TABLE dbo.Prospectos ADD ValorizacionFacturacionMensual decimal(12, 2) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionCoeficienteFacturacion decimal(5, 2) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionFacturacion decimal(18, 4) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionImporteAdeudado decimal(12, 2) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionCoeficienteDeuda decimal(5, 2) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionDeuda decimal(18, 4) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionProyecto decimal(18, 4) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionProspecto decimal(18, 4) NULL
ALTER TABLE dbo.Prospectos ADD ValorizacionEstrellas decimal(5, 2) NULL

PRINT ''
PRINT '4. Tabla AuditoriaProspectos: Nuevos campos para calculo de Estrellas'
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionFacturacionMensual decimal(12, 2) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionCoeficienteFacturacion decimal(5, 2) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionFacturacion decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionImporteAdeudado decimal(12, 2) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionCoeficienteDeuda decimal(5, 2) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionDeuda decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionProyecto decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionProspecto decimal(18, 4) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionEstrellas decimal(5, 2) NULL

GO

PRINT ''
PRINT '5. Tabla Cliente: Valores por defecto para campos para calculo de Estrellas'
UPDATE Clientes
   SET ValorizacionFacturacionMensual       = 0
     , ValorizacionCoeficienteFacturacion   = 0
     , ValorizacionFacturacion              = 0
     , ValorizacionImporteAdeudado          = 0
     , ValorizacionCoeficienteDeuda         = 0
     , ValorizacionDeuda                    = 0
     , ValorizacionProyecto                 = 0
     , ValorizacionCliente                  = 0
     , ValorizacionEstrellas                = 0;

PRINT ''
PRINT '6. Tabla Prospectos: Valores por defecto para campos para calculo de Estrellas'
UPDATE Prospectos
   SET ValorizacionFacturacionMensual       = 0
     , ValorizacionCoeficienteFacturacion   = 0
     , ValorizacionFacturacion              = 0
     , ValorizacionImporteAdeudado          = 0
     , ValorizacionCoeficienteDeuda         = 0
     , ValorizacionDeuda                    = 0
     , ValorizacionProyecto                 = 0
     , ValorizacionProspecto                = 0
     , ValorizacionEstrellas                = 0;

PRINT ''
PRINT '7. Tabla Cliente: NOT NULL para campos para calculo de Estrellas'
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionFacturacionMensual decimal(12, 2) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionCoeficienteFacturacion decimal(5, 2) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionFacturacion decimal(18, 4) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionImporteAdeudado decimal(12, 2) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionCoeficienteDeuda decimal(5, 2) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionDeuda decimal(18, 4) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionProyecto decimal(18, 4) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionCliente decimal(18, 4) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionEstrellas decimal(5, 2) NOT NULL

PRINT ''
PRINT '8. Tabla Prospectos: NOT NULL para campos para calculo de Estrellas'
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionFacturacionMensual decimal(12, 2) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionCoeficienteFacturacion decimal(5, 2) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionFacturacion decimal(18, 4) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionImporteAdeudado decimal(12, 2) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionCoeficienteDeuda decimal(5, 2) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionDeuda decimal(18, 4) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionProyecto decimal(18, 4) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionProspecto decimal(18, 4) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionEstrellas decimal(5, 2) NOT NULL


PRINT ''
PRINT '9. Menu: Creo opción de seguridad para que no se vea el detalle de estrellas'
IF dbo.SoyHAR() = 'True'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('PuedeVerDetalleEstrellas', 'Puede Ver Detalle Valoracion Estrellas', 'Puede Ver Detalle Valoracion Estrellas', 'True', 'False', 'True', 'True'
        ,'Clientes', 99, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PuedeVerDetalleEstrellas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm')
END


