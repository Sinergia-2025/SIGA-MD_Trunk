
DELETE RolesFunciones WHERE IdFuncion = 'Facturacion-ModifPrecioProd'
GO

DELETE Funciones WHERE Id = 'Facturacion-ModifPrecioProd'
GO

--Inserto el Campo de Pantalla

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Facturacion-ModifPrecioProd', 'Facturacion - Modifica el Precio del Producto', 'Facturacion - Modifica el Precio del Producto', 
    'False', 'False', 'True', 'True', 'FacturacionV2', 10, 'Eniac.Win', 'Facturacion-ModifPrecioProd', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Facturacion-ModifPrecioProd' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
