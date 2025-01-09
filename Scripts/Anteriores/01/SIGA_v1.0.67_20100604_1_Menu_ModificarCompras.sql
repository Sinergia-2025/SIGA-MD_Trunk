DELETE RolesFunciones WHERE IdFuncion in ('ModificacionCompras', 'ModificarCompras')
GO

DELETE Funciones WHERE Id in ('ModificacionCompras', 'ModificarCompras')
GO

--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ModificarCompras', 'Modificar Compras', 'Modificar Compras', 
    'True', 'False','True','True','Compras', 35,'Eniac.Win', 'ModificarCompras', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ModificarCompras' AS Pantalla FROM dbo.Roles
GO
