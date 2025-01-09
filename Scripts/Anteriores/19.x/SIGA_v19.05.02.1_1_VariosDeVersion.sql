PRINT ''
PRINT '1. Agregar columna PrecioCosto a ProductosLotes'
ALTER TABLE ProductosLotes ADD PrecioCosto decimal(14,4) null
GO
UPDATE ProductosLotes 
   SET PrecioCosto = PS.PrecioCosto
  FROM ProductosLotes PL
 INNER JOIN ProductosSucursales PS ON PS.IdSucursal = PL.IdSucursal AND PS.IdProducto = PL.IdProducto
GO
ALTER TABLE ProductosLotes ALTER COLUMN PrecioCosto decimal(14,4) not null
GO


PRINT ''
PRINT '2. Nueva Función: Inf. Utilidades por Lista de Precios'
IF dbo.ExisteFuncion('VentasUtilidades') = 1
BEGIN
    PRINT ''
    PRINT '2.1. Crea Función'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfUtilidadesPorListaDePrecios', 'Inf. Utilidades por Lista de Precios', 'Inf. Utilidades por Lista de Precios', 'True', 'False', 'True', 'True'
        ,'VentasUtilidades', 15, 'Eniac.Win', 'InfUtilidadesPorListaDePrecios', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '2.2. Crea RolesFunciones'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfUtilidadesPorListaDePrecios' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '3. Corrige NombreListaPrecios de VentasProductos'
UPDATE VentasProductos
   SET NombreListaPrecios = LP.NombreListaPrecios
  FROM VentasProductos VP
 INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = VP.IdListaPrecios
 WHERE VP.IdListaPrecios IS NOT NULL
   AND VP.NombreListaPrecios = ''
