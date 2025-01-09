PRINT ''
PRINT '1. Tabla Productos: Nuevos Campos TipoBonificacion, UHListaPrecios1, UHListaPrecios2, UHListaPrecios3, UHListaPrecios4 y UHListaPrecios5'
ALTER TABLE Productos ADD TipoBonificacion VARCHAR(15) NULL
ALTER TABLE Productos ADD UHListaPrecios1 INT NULL
ALTER TABLE Productos ADD UHListaPrecios2 INT NULL
ALTER TABLE Productos ADD UHListaPrecios3 INT NULL
ALTER TABLE Productos ADD UHListaPrecios4 INT NULL
ALTER TABLE Productos ADD UHListaPrecios5 INT NULL
GO

PRINT ''
PRINT '1.1. Tabla Productos: Campo Tipo de Bonificación inicial: DESCUENTO'
UPDATE P SET P.TipoBonificacion = 'DESCUENTO' FROM Productos P
GO

PRINT ''
PRINT '1.2. Tabla Productos: Campo Tipo de Bonificación NOT NULL'
ALTER TABLE Productos ALTER COLUMN TipoBonificacion VARCHAR(15) NOT NULL
GO


ALTER TABLE Productos ADD CONSTRAINT FK_Productos_ListasDePrecios_1 FOREIGN KEY (UHListaPrecios1) REFERENCES ListasDePrecios(IdListaPrecios)
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_ListasDePrecios_2 FOREIGN KEY (UHListaPrecios2) REFERENCES ListasDePrecios(IdListaPrecios)
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_ListasDePrecios_3 FOREIGN KEY (UHListaPrecios3)REFERENCES ListasDePrecios(IdListaPrecios)
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_ListasDePrecios_4 FOREIGN KEY (UHListaPrecios4) REFERENCES ListasDePrecios(IdListaPrecios)
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_ListasDePrecios_5 FOREIGN KEY (UHListaPrecios5) REFERENCES ListasDePrecios(IdListaPrecios)
GO

PRINT ''
PRINT '2. Tabla AuditoriaProductos: Nuevos Campos TipoBonificacion, UHListaPrecios1, UHListaPrecios2, UHListaPrecios3, UHListaPrecios4 y UHListaPrecios5'
ALTER TABLE AuditoriaProductos ADD TipoBonificacion VARCHAR(15) NULL
ALTER TABLE AuditoriaProductos ADD UHListaPrecios1 INT NULL
ALTER TABLE AuditoriaProductos ADD UHListaPrecios2 INT NULL
ALTER TABLE AuditoriaProductos ADD UHListaPrecios3 INT NULL
ALTER TABLE AuditoriaProductos ADD UHListaPrecios4 INT NULL
ALTER TABLE AuditoriaProductos ADD UHListaPrecios5 INT NULL
GO

/*Informe de Ordenes Talleres Externos*/
IF dbo.ExisteFuncion('CRM') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('InfOrdenesTalleresExternos', 'Informe de Ordenes Talleres Externos', 'Informe de Ordenes Talleres Externos', 'True', 'False', 'True', 'True'
        ,'CRM', 255, 'Eniac.Win', 'InfOrdenesTalleresExternos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL,'True')


	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfOrdenesTalleresExternos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END
