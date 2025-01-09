
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('CierreX', 'Cierre X', 'Cierre X', 'True', 'False', 'True', 'True', 
      'Ventas', 255, 'Eniac.Win', 'CierreX', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CierreX' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
