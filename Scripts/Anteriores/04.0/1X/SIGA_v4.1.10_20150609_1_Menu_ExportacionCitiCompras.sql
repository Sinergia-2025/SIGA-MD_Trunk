
--Inserto la Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ExportacionCitiCompras', 'Exportación para CITI Compras', 'Exportación para CITI Compras', 
    'True', 'False', 'True', 'True', 'AFIP', 5, 'Eniac.Win', 'ExportacionCitiCompras', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExportacionCitiCompras' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO

