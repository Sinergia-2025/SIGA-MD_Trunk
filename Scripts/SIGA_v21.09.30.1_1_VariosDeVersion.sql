PRINT ''
PRINT '1. Nueva Tabla ProspectoAplicacionesModulos'
CREATE TABLE [dbo].[ProspectosAplicacionesModulos](
	[IdProspecto] [bigint] NOT NULL,
	[IdModulo] [int] NOT NULL,
 CONSTRAINT [PK_ProspectosAplicacionesModulos] PRIMARY KEY CLUSTERED 
(
	[IdProspecto] ASC,
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.ProspectosAplicacionesModulos ADD CONSTRAINT FK_ProspectosAplicacionesModulos_Prospectos 
    FOREIGN KEY (IdProspecto)
    REFERENCES dbo.Prospectos (IdProspecto) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.ProspectosAplicacionesModulos ADD CONSTRAINT FK_ProspectosAplicacionesModulos_AplicacionesModulos
    FOREIGN KEY (IdModulo)
    REFERENCES dbo.AplicacionesModulos (IdModulo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '2. Nueva Función de menu: Informe de Ordenes de Reparacion'
/*Informe de Ordenes de Reparacion*/
IF dbo.ExisteFuncion('CRM') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('InfOrdenesReparacion', 'Informe de Ordenes de Reparacion', 'Informe de Ordenes de Reparacion', 'True', 'False', 'True', 'True'
        ,'CRM', 250, 'Eniac.Win', 'InfOrdenesReparacion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL,'True')


	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfOrdenesReparacion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END

PRINT ''
PRINT '3. Nueva Función de menu: Informe de Retiros y Entregas a Domicilio'
/*Informe de Retiros y Entregas a Domicilio*/
IF dbo.ExisteFuncion('CRM') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('InfRetirosEntregasADomicilio', 'Informe de Retiros Y Enrtregas a Domicilio', 'Informe de Retiros Y Enrtregas a Domicilio', 'True', 'False', 'True', 'True'
        ,'CRM', 260, 'Eniac.Win', 'InfRetirosEntregasADomicilio', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL,'True')


	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfRetirosEntregasADomicilio' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END
