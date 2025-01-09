PRINT ''
PRINT '1. Tabla Nueva de Plazos de Entrega.-'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'PlazosEntregas')
BEGIN
	CREATE TABLE [dbo].[PlazosEntregas](
                       [IdPlazoEntrega] [int] NOT NULL,
                       [DescripcionPlazoEntrega] [varchar](50) NOT NULL,
                       [ActivoPlazoEntrega] [bit] NOT NULL,
		CONSTRAINT [PK_PlazoEntrega] PRIMARY KEY CLUSTERED ([IdPlazoEntrega] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

PRINT ''
PRINT '3. Nuevo Campo Plazo de Entrega: Pedidos.'
IF NOT EXISTS(SELECT * FROM PlazosEntregas  WHERE IdPlazoEntrega = 1)
BEGIN
	INSERT INTO PlazosEntregas(IdPlazoEntrega, DescripcionPlazoEntrega, ActivoPlazoEntrega) VALUES (1,'Plazo de Entrega Inicial', 1)  
END
GO

PRINT ''
PRINT '2. Nueva Función: ABM de Plazos de Entrega.'
IF dbo.ExisteFuncion('ABMPlazosEntrega') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ABMPlazosEntrega', 'Plazos de Entrega', 'Plazos de Entrega', 'True', 'False', 'True', 'True'
        ,'Archivos', 97, 'Eniac.Win', 'PlazosEntregaABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ABMPlazosEntrega' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '3. Nuevo Campo Plazo de Entrega: Pedidos.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdPlazoEntrega' AND TABLE_NAME = 'Pedidos')
BEGIN
	ALTER TABLE Pedidos ADD IdPlazoEntrega Int NULL
END
GO

PRINT ''
PRINT '4. Nuevo Campo Plazo de Entrega: Pedidos.'
BEGIN
	UPDATE Pedidos SET IdPlazoEntrega = (SELECT MAX(IdPlazoEntrega) FROM PlazosEntregas) 
	ALTER TABLE Pedidos ALTER COLUMN IdPlazoEntrega Int NOT NULL
END
GO


PRINT ''
PRINT '5. Nuevo Campo ValidezPresupuesto: Presupuestos.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'ValidezPresupuesto' AND TABLE_NAME = 'Pedidos')
BEGIN
	ALTER TABLE Pedidos ADD ValidezPresupuesto Int NULL
END
GO

PRINT ''
PRINT '6. Nuevo Campo ValidezPresupuesto: Presupuestos.'
BEGIN
	UPDATE Pedidos SET ValidezPresupuesto = (SELECT ValorParametro FROM Parametros where IdParametro like '%DIASVALIDEZPRESUPUESTO%' and IdEmpresa = 1) WHERE IdTipoComprobante = 'PRESUPCLIE'
END
GO
