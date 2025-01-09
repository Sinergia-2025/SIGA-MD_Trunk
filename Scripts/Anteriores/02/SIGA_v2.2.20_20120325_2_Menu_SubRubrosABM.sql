
--Inserto la pantalla nueva

INSERT INTO Funciones
      (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
      ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
      ('SubRubrosABM', 'SubRubros', 'SubRubros', 'True', 'False', 'True', 'True',
      'Archivos', 160, 'Eniac.Win', 'SubRubrosABM', NULL)
GO

--INSERT INTO RolesFunciones 
--           (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'SubRubrosABM' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
--GO


UPDATE RolesFunciones 
   SET IdFuncion = 'SubRubrosABM'
 WHERE IdFuncion = 'SubRubros'
GO

-- Ajusto la posicion de la pantalla estandar

DELETE Funciones
 WHERE Id = 'SubRubros'
GO
