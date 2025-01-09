
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CopiarComprobantes', 'Reemplazar/Copiar Comprobantes', 'Reemplazar/Copiar Comprobantes', 
      'True', 'False', 'True', 'True',
      'Ventas', 340, 'Eniac.Win', 'CopiarComprobantes', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CopiarComprobantes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
