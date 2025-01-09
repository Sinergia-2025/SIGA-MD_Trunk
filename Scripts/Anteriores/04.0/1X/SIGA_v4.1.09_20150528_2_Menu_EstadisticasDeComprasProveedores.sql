
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('EstadisticaComprasProveedores', 'Estadistica de Compras por Proveedores', 'Estadistica de Compras por Proveedores', 'True', 'False', 'True', 'True',
      'Estadisticas', 35, 'Eniac.Win', 'EstadisticaDeComprasProveedores', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadisticaComprasProveedores' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
