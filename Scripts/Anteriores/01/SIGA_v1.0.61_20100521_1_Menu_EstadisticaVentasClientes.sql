--Inserto la pantalla nueva

INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('EstadisticaDeVentasClientes','Estadística De Ventas por Clientes','Estadística De Ventas por Clientes'
           ,'True','False','True','True','Ventas', 85,'Eniac.Win','EstadisticaDeVentasClientes'
           ,null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadisticaDeVentasClientes' AS Pantalla FROM dbo.Roles
GO
