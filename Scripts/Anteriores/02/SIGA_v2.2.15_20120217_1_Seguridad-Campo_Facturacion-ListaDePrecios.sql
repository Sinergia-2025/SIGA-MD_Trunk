
--DELETE RolesFunciones WHERE IdFuncion = 'Facturacion-ListaDePrecios'
--GO

--DELETE Funciones WHERE Id = 'Facturacion-ListaDePrecios'
--GO

--Inserto el Campo de Pantalla

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Facturacion-ListaDePrecios', 'Facturacion - Modifica la Lista de Precios', 'Facturacion - Modifica la Lista de Precios', 
    'False', 'False', 'True', 'True', 'FacturacionV2', 20, 'Eniac.Win', 'Facturacion-ListaDePrecios', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Facturacion-ListaDePrecios' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
