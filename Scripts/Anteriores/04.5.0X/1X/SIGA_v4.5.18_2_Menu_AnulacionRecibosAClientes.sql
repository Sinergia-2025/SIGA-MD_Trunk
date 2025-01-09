
--Inserto la Pantalla Nueva y luego piso la anterior porque cambio la funcionalidad.

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AnulacionRecibosAClientes', 'Anular Recibos a Clientes', 'Anular Recibos a Clientes', 
      'True', 'False', 'True', 'True',
      'CuentasCorrientes', 22, 'Eniac.Win', 'AnulacionRecibosAClientes', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnulacionRecibosAClientes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


-- Cambio el nombre de la anterior para evitar que se lean similares.

UPDATE Funciones
   SET Nombre = 'Anular Recibos'
      ,Descripcion = 'Anular Recibos'
 WHERE Id = 'AnularRecibos'
GO
