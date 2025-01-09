
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('TransferenciasEntreCuentas', 'Transferencias Entre Cuentas', 'Transferencias Entre Cuentas', 
	 'True', 'False', 'True', 'True',
      'Bancos', 145, 'Eniac.Win', 'TransferenciasEntreCuentas', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'TransferenciasEntreCuentas' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-- Modificar el Menu para que tenga el nuevo titulo
UPDATE Funciones
   SET Nombre = 'Consultar Depositos/Extracciones/Transferencias Bancarias'
      ,Descripcion = 'Consultar Depositos/Extracciones/Transferencias Bancarias'
 WHERE ID = 'ConsultarDepositos'
GO
