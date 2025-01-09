
DELETE RolesFunciones WHERE IdFuncion = 'AjusteMasivoStock'
GO

DELETE Funciones WHERE Id = 'AjusteMasivoStock'
GO


INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AjusteMasivoDeStock', 'Ajuste Masivo de Stock', 'Ajuste Masivo de Stock', 'True', 'False', 'True', 'True', 
      'Stock', 45, 'Eniac.Win', 'AjusteMasivoDeStock', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AjusteMasivoDeStock' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
