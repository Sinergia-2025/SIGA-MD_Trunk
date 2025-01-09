
DELETE RolesFunciones WHERE IdFuncion = 'ConsultaLotes'
GO

DELETE Funciones WHERE Id = 'ConsultaLotes'
GO

--Inserto la pantalla nueva

INSERT INTO Funciones
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono])
     VALUES
           ('ConsultarLotesDeProductos','Consultar Lotes de Productos','Consultar Lotes de Productos'
           ,'True','False','True','True','Stock', 60,'Eniac.Win','ConsultarLotesDeProductos'
           ,null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarLotesDeProductos' AS Pantalla FROM dbo.Roles
GO

