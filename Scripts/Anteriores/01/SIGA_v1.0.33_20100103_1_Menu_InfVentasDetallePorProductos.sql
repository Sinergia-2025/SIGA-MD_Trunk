--Inserto la pantalla nueva

INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('InfVentasDetallePorProductos','Inf. Ventas Detallada por Productos','Inf. Ventas Detallada por Producto'
           ,'True','False','True','True','Ventas', 115,'Eniac.Win','InfVentasDetallePorProductos'
           ,null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfVentasDetallePorProductos' AS Pantalla FROM dbo.Roles
GO
