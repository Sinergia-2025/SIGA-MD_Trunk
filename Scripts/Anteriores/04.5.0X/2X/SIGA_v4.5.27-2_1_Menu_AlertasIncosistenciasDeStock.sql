
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InconsistStockVsStockLotes', 'Alerta Inconsistencia Stock Vs Stock Lotes', 'Alerta Inconsistencia Stock Vs Stock Lotes', 'False', 'False', 'True', 'False', 
      'Stock', 999, 'Eniac.Win', 'InconsistenciaStockVsStockLotes', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InconsistStockVsStockLotes' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InconsistStockVsMovDeStock', 'Alerta Inconsistencia Stock Vs Movimientos De Stock', 'Alerta Inconsistencia Stock Vs Movimientos De Stock', 'False', 'False', 'True', 'False', 
      'Stock', 999, 'Eniac.Win', 'InconsistenciaStockVsMovimientosDeStock', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InconsistStockVsMovDeStock' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO