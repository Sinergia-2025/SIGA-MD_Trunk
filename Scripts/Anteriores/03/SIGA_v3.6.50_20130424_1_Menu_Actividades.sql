--Inserto la pantalla nueva

INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('ActividadesABM','Actividades','Actividades'
           ,'True','False','True','True','Archivos', 5,'Eniac.Win','ActividadesABM'
           ,null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ActividadesABM' AS Pantalla FROM dbo.Roles
GO
