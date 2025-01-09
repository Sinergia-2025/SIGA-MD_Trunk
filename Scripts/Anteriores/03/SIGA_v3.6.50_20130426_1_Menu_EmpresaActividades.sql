--Inserto la pantalla nueva

INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('EmpresaActividades','Empresa - Asignación de Actividades','Empresa - Asignación de Actividades'
           ,'True','False','True','True','Archivos', 45,'Eniac.Win','EmpresaActividades'
           ,null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EmpresaActividades' AS Pantalla FROM dbo.Roles
GO
