
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('DespacharMercaderia', 'Despachar Mercaderia', 'Despachar Mercaderia', 
    'True', 'False', 'True', 'True', 'Ventas', 19, 'Eniac.Win', 'DespacharMercaderia', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'DespacharMercaderia' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
