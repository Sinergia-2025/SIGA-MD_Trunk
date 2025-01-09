
--Inserto el Campo de Pantalla
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Facturacion-ClaveDescRecProd', 'Facturacion: Pide Clave Desc/Recargo del Producto', 'Facturacion: Pide Clave Desc/Recargo del Producto', 
    'False', 'False', 'True', 'True', 'FacturacionV2', 10, 'Eniac.Win', 'Facturacion-ClaveDescRecProd', NULL)
;

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT IdRol, 'Facturacion-ClaveDescRecProd'
  FROM RolesFunciones
 WHERE IdFuncion = 'Facturacion-ModifDescRecProd'
;

SELECT * FROM RolesFunciones
 WHERE IdFuncion IN ('Facturacion-ModifDescRecProd', 'Facturacion-ClaveDescRecProd')
 ORDER BY IdRol
;
