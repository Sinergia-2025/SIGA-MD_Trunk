
--Inserto el Campo de Pantalla

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Facturacion-ModifDescRecProd', 'Facturacion: Modifica el Desc/Recargo del Producto', 'Facturacion: Modifica el Desc/Recargo del Producto', 
    'False', 'False', 'True', 'True', 'FacturacionV2', 10, 'Eniac.Win', 'Facturacion-ModifDescRecProd', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT IdRol, 'Facturacion-ModifDescRecProd' AS Pantalla FROM dbo.RolesFunciones
    WHERE IdFuncion = 'Facturacion-ModifPrecioProd'
GO

/* --------- */

UPDATE Funciones
   SET Nombre = 'Facturacion: Modifica el Precio del Producto.'
      ,Descripcion = 'Facturacion: Modifica el Precio del Producto.'
    WHERE Id = 'Facturacion-ModifPrecioProd'
GO

/* ---- */

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
SELECT 'FACTURACIONMODIFICADESCRECPRODUCTO', ValorParametro, NULL, 'Indica si permite modificar el Desc/Recargo del Producto.' FROM Parametros 
 WHERE IdParametro = 'FACTURACIONMODIFICAPRECIOPRODUCTO'
GO
