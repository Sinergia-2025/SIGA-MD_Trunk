
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CategoriasFiscalesABM', 'ABM de Categorias Fiscales', 'ABM de Categorias Fiscales', 'True', 'False', 'True', 'True',
      'AFIP', 100, 'Eniac.Win', 'CategoriasFiscalesABM', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CategoriasFiscalesABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO


--Inserto el registro de Exportacion

INSERT INTO CategoriasFiscales
    (IdCategoriaFiscal, NombreCategoriaFiscal, LetraFiscal, IvaDiscriminado
    ,CondicionIvaImpresoraFiscal, NombreCategoriaFiscalAbrev, LetraFiscalCompra, UtilizaImpuestos, Activo)
  VALUES
    (7, 'Exportacion', 'E', 'True'
    ,'X', 'Exportac.', 'E', 'False', 'True')
GO

