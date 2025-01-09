
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ComisionesVendedorLista', 'ABM de Comisiones de Vendedores por Lista', 'ABM de Comisiones de Vendedores por Lista', 
      'True', 'False', 'True', 'True',
      'ComisionesVendedores', 200, 'Eniac.Win', 'ComisionesVendedorLista', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ComisionesVendedorLista' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
