

--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConsultarPreciosClientes', 'Consultar Precios por Cliente', 'Consultar Precios por Cliente', 
    'True', 'False', 'True', 'True', 'Precios', 22, 'Eniac.Win', 'ConsultarPreciosClientes', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPreciosClientes' AS Pantalla FROM dbo.Roles
GO
