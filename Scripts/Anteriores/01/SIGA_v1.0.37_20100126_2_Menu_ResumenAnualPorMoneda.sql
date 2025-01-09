
--Miro el Numero de Posicion

SELECT * FROM Funciones 
  WHERE IdPadre = 'Bancos'
  ORDER BY Posicion
GO


--Inserto la pantalla nueva


INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('ResumenAnualPorMoneda','Resumen Anual por Moneda','Resumen Anual por Moneda'
           ,'True','False','True','True','Bancos', 45,'Eniac.Win','ResumenAnualPorMoneda'
           ,null)
GO



INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ResumenAnualPorMoneda' AS Pantalla FROM dbo.Roles
GO
