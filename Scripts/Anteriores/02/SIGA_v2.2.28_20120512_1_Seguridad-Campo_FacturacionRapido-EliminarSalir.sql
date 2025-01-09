DELETE RolesFunciones 
 WHERE IdFuncion = 'FacturacionRapidaSuper'
GO


DELETE Funciones
 WHERE Id = 'FacturacionRapidaSuper'
GO


--Inserto el Campo de Pantalla

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FacturacionRapidaSuper', 'Facturacion Rapida - Nuevo, Eliminar y Salida', 'Facturacion Rapida - Nuevo, Eliminar y Salida', 
    'False', 'False', 'True', 'True', 'FacturacionRapida', 10, 'Eniac.Win', 'FacturacionRapidaSuper', NULL)
GO

/* SOLO PARA SUPERMERCADOS */

--INSERT INTO RolesFunciones
--    (IdRol, IdFuncion)
-- VALUES
--    ('Adm', 'FacturacionRapidaSuper'),
--    ('Supervisor', 'FacturacionRapidaSuper')
--GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT IdRol, 'FacturacionRapidaSuper' FROM RolesFunciones WHERE IdFuncion = 'FacturacionRapida'
GO
