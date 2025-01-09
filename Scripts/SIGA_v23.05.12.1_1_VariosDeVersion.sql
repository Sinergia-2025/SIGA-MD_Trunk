IF dbo.ExisteFuncion('AlertasSistemaABM') = 0 AND dbo.ExisteFuncion('Configuraciones') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AlertasSistemaABM', 'ABM Alertas del sistema', 'ABM Alertas del sistema', 'True', 'False', 'True', 'True'
        ,'Configuraciones', 95, 'Eniac.Win', 'AlertasSistemaABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AlertasSistemaABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteCampo('AlertasSistema', 'UtilizaConsultaGenerica') = 0
BEGIN
    ALTER TABLE AlertasSistema ADD UtilizaConsultaGenerica bit NULL
END
GO
UPDATE AlertasSistema SET UtilizaConsultaGenerica = 'False'
ALTER TABLE AlertasSistema ALTER COLUMN UtilizaConsultaGenerica bit NOT NULL
GO

