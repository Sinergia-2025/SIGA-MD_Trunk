
delete RolesFunciones 
 where IdFuncion = 'EliminarRecibosAClientes'
GO

delete Funciones
 where ID = 'EliminarRecibosAClientes'
GO

  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('EliminarRecibosDeClientes', 'Eliminar Recibos Anulados', 'Eliminar Recibos Anulados', 
    'True', 'False', 'True', 'True', 'CuentasCorrientes', 25, 'Eniac.Win', 'EliminarRecibosDeClientes', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EliminarRecibosDeClientes' AS Pantalla FROM dbo.Roles
GO
