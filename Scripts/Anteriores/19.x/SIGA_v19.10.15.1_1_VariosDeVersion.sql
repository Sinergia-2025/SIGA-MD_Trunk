PRINT ''
PRINT '1.Tabla CalidadListasControl: Actualiza check Controla 5S por defecto en True.'
UPDATE CalidadListasControl SET Controla5SCalidad = 'True' , Controla5SProduccion = 'True'

PRINT ''
PRINT '2. Menu Permisos - Listas de Control por Productos '
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN

    PRINT ''
    PRINT '. Menu ListasControlProductos-CabProducto'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-CP', 'Ejecución de Listas de Control por Productos-Cab. Producto', 'Ejecución de Listas de Control por Productos-Cab. Producto', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-CP', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
  
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT IdRol, 'ListasControlProductos-CP' AS Pantalla FROM dbo.RolesFunciones
         WHERE IdRol IN ('Adm')

END


PRINT ''
PRINT '3.Tabla CalidadListasControl: Actualiza check Controla 5S por defecto en True.'

ALTER TABLE CalidadListasControl ADD ModificaFechaEgreso bit null
GO

UPDATE CalidadListasControl SET ModificaFechaEgreso = 'False'
GO

ALTER TABLE CalidadListasControl ALTER COLUMN ModificaFechaEgreso bit not null
GO


ALTER TABLE CalidadListasControl ADD ModificaFechaPreEntrega bit null
GO

UPDATE CalidadListasControl SET ModificaFechaPreEntrega = 'False'
GO

ALTER TABLE CalidadListasControl ALTER COLUMN ModificaFechaPreEntrega bit not null
GO

UPDATE CalidadListasControl SET ModificaFechaEgreso = 'True' WHERE IdListaControl = 21
UPDATE CalidadListasControl SET ModificaFechaPreEntrega = 'True' WHERE IdListaControl = 10
