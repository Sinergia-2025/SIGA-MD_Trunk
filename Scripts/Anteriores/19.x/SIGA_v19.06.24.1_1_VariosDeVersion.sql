
IF dbo.ExisteFuncion('TableroDeComando') = 'True'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TableroDeComandox1', 'Tablero de Comando (1 panel)', 'Tablero de Comando (1 panel)', 'True', 'False', 'True', 'True'
        ,'Estadisticas', 50, 'Eniac.Win', 'TableroDeComandox1', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComandox1' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando'
END

ALTER TABLE dbo.Clientes ADD NroVersionWebmovilPropio varchar(50) NULL
ALTER TABLE dbo.Clientes ADD NroVersionWebmovilAdminPropio varchar(50) NULL
ALTER TABLE dbo.Clientes ADD NroVersionSimovilGestionPropio varchar(50) NULL
GO

ALTER TABLE dbo.AuditoriaClientes ADD NroVersionWebmovilPropio varchar(50) NULL
ALTER TABLE dbo.AuditoriaClientes ADD NroVersionWebmovilAdminPropio varchar(50) NULL
ALTER TABLE dbo.AuditoriaClientes ADD NroVersionSimovilGestionPropio varchar(50) NULL
GO

ALTER TABLE dbo.AuditoriaProspectos ADD NroVersionWebmovilPropio varchar(50) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD NroVersionWebmovilAdminPropio varchar(50) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD NroVersionSimovilGestionPropio varchar(50) NULL
GO

ALTER TABLE dbo.Prospectos ADD NroVersionWebmovilPropio varchar(50) NULL
ALTER TABLE dbo.Prospectos ADD NroVersionWebmovilAdminPropio varchar(50) NULL
ALTER TABLE dbo.Prospectos ADD NroVersionSimovilGestionPropio varchar(50) NULL
GO


ALTER TABLE dbo.ClientesAdjuntos ADD NivelAutorizacion smallint null;
ALTER TABLE dbo.VentasAdjuntos ADD NivelAutorizacion smallint null;
GO

UPDATE dbo.ClientesAdjuntos SET NivelAutorizacion  = 0;
UPDATE dbo.VentasAdjuntos SET NivelAutorizacion  = 0;

ALTER TABLE dbo.ClientesAdjuntos ALTER COLUMN NivelAutorizacion smallint not null
ALTER TABLE dbo.VentasAdjuntos ALTER COLUMN NivelAutorizacion smallint not null
GO
