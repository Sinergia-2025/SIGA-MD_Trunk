
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('ContabilidadProcesos', 'Importar Informacion desde la Gestion', 'Importar Informacion desde la Gestion', 'True', 'False', 'True', 'True', 
      'Contabilidad', 360, 'Eniac.Win', 'ContabilidadProcesos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadProcesos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

-------------------------------------

DELETE [dbo].RolesFunciones 
 WHERE IdFuncion = 'ContabilidadReportesAdmin'
GO

DELETE [dbo].Funciones 
 WHERE Id = 'ContabilidadReportesAdmin'
GO


