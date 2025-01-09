  
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
     IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('TiposMovimientosABM', 'Tipos de Movimientos', 'Tipos de Movimientos', 'True', 'False', 'True', 'True', 
      'Archivos', 195, 'Eniac.Win', 'TiposMovimientosABM', NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposMovimientosABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO


/* --- AJUSTE REGISTROS INCONSISTENTES ---*/ 

UPDATE TiposMovimientos
   SET CargaPrecio = 'NO'
 WHERE CargaPrecio IS NULL OR CargaPrecio NOT IN ('NO', 'PrecioFabrica', 'PrecioCosto', 'PrecioVenta')
GO
