DELETE RolesFunciones WHERE IdFuncion = 'AjustarStock'
GO

DELETE Funciones WHERE Id = 'AjustarStock'
GO

--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('AjustarStock', 'Ajustar Stock de Productos', 'Ajustar Stock de Productos', 
    'True', 'False', 'True', 'True', 'Stock', 45, 'Eniac.Win', 'AjustarStock', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AjustarStock' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

/* ------------------- */

UPDATE Funciones 
   SET Nombre = 'Blanquear Stock de Productos'
      ,Descripcion = 'Blanquear Stock de Productos'
 WHERE Id = 'BlanquearStock'
GO
