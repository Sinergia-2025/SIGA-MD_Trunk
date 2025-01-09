IF dbo.ExisteFuncion('Ayuda') = 1 AND dbo.ExisteFuncion('SolicitarSoporteConsulta') = 0
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('SolicitarSoporteConsulta', 'Consulta Estado Soporte', 'Consulta Estado Soporte', 'True', 'False', 'True', 'True'
        ,'Ayuda', 110, 'Eniac.Win', 'SolicitarSoporteConsulta', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SolicitarSoporteConsulta' AS Pantalla FROM dbo.Roles
END
GO

IF dbo.ExisteCampo('TiposComprobantes', 'SimulaPercepciones') = 0
BEGIN
    ALTER TABLE TiposComprobantes ADD SimulaPercepciones bit NULL
END
GO
UPDATE TiposComprobantes SET SimulaPercepciones = 'False';
ALTER TABLE TiposComprobantes ALTER COLUMN SimulaPercepciones bit NOT NULL
GO

PRINT ''
PRINT '1. Tabla CuentasCorrientesPagos: Nuevo campo CodigoDeBarraSirplus'
IF dbo.ExisteCampo('CuentasCorrientesPagos', 'CodigoDeBarraSirplus') = 0
BEGIN  
ALTER TABLE CuentasCorrientesPagos ADD CodigoDeBarraSirplus	varchar(100) NULL 
END
GO
