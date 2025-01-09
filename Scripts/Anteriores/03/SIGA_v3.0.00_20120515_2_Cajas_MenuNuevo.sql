
--Inserto la pantalla nueva
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('PlanillaDeCaja', 'Planilla de Caja', 'Planilla de Caja', 
    'True', 'True', 'True', 'True', 'Caja', 10, 'Eniac.Win', 'PlanillaDeCaja', null)
GO


--INSERT INTO (IdRol,IdFuncion)
--  SELECT DISTINCT Id AS Rol, 'PlanillaDeCaja' AS Pantalla FROM dbo.Roles
UPDATE RolesFunciones 
   SET IdFuncion = 'PlanillaDeCaja'
 WHERE IdFuncion = 'MoviCaja'
GO

UPDATE Funciones
   SET [Enabled] = 'False'
 WHERE Id = 'MoviCaja'
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('CajasNombresABM', 'Administracion de Cajas', 'Administracion de Cajas'
           ,'True','False', 'True', 'True', 'Caja', 15, 'Eniac.Win', 'CajasNombresABM', null)
GO

--INSERT INTO RolesFunciones (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'CajasNombresABM' AS Pantalla FROM dbo.Roles
--GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT IdRol, 'CajasNombresABM' AS Pantalla FROM dbo.RolesFunciones
  WHERE IdFuncion = 'PlanillaDeCaja'
GO
