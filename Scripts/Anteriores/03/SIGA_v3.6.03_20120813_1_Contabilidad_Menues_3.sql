
DELETE RolesFunciones
 WHERE IdFuncion = 'ContabilidadListadoBceGral'
GO

DELETE Funciones
 WHERE Id = 'ContabilidadListadoBceGral'
GO

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoBceGral', 'Balance General', 'Balance General', 'True', 'False', 'True', 'True', 
          'Contabilidad', 240, 'Eniac.Win', 'ContabilidadListadoBceGral', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBceGral' AS Pantalla FROM Roles
GO

---------------------------------------------------

UPDATE Funciones
   SET Posicion = 300
 WHERE Id = 'ContabilidadListadoAsientos'
GO

