
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton
    ,[Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
    ('ConsultarFacturablesDetalle','Consultar Facturables Detalle','Consultar Facturables Detalle', 'True', 'False'
    ,'True', 'True', 'Ventas', 28, 'Eniac.Win', 'ConsultarFacturablesDetalle', NULL)
GO
    

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarFacturablesDetalle' AS Pantalla FROM dbo.Roles
GO

