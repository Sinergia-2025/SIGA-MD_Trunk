
INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoBceGral', 'Balance General', 'Balance General', 'True', 'False', 'True', 'True', 
          'Contabilidad', 150, 'Eniac.Win', 'ContabilidadListadoBceGral', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBceGral' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
