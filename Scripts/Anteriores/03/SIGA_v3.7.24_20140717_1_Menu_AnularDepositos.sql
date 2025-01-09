
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AnularDepositos', 'Anular Depósitos Bancarios', 'Anular Depósitos Bancarios', 'True', 'False', 'True', 'True', 
      'Bancos', 120, 'Eniac.Win', 'AnularDepositos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnularDepositos' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
