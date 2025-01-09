
DELETE Bitacora
GO

DELETE HistorialConsultaProductos
GO

DELETE HistorialPrecios
GO

DELETE AuditoriaProductos
GO

DELETE ProductosSucursalesPrecios
GO

DELETE ProductosSucursales
GO

DELETE ProductosWeb
GO

DELETE ProductosConceptos
GO

DELETE ProductosLotes
GO

UPDATE Productos
 SET IdFormula = NULL
GO


DELETE ProductosFormulas
GO

DELETE ProductosProveedores
GO

DELETE EmpleadosComisionesProductos
GO

DELETE ClientesDescuentosProductos
GO

DELETE Productos
GO


DELETE MovilRutasListasDePrecios
GO
DELETE MovilRutas
GO

DELETE MovilRutasClientes
GO

DELETE AuditoriaClientes
GO

DELETE ClientesDescuentosMarcas
GO

DELETE ClientesDescuentosRubros
GO

DELETE ClientesActividades
GO

DELETE Clientes
GO

--DELETE ListasDePrecios
--GO

DELETE Proveedores
GO

UPDATE Categorias
 set IdInteres = NULL
GO

DELETE InteresesDias
GO

DELETE Intereses
GO

DELETE AuditoriaMonedas
GO

INSERT INTO [dbo].[AuditoriaMonedas] (
        [FechaAuditoria], [OperacionAuditoria], [UsuarioAuditoria]
    , [IdMoneda], [NombreMoneda], [IdTipoMoneda], [OperadorConversion]
    , [FactorConversion], [IdBanco], [Simbolo])
SELECT GETDATE(), 'A', 'admin'
        , [IdMoneda], [NombreMoneda], [IdTipoMoneda], [OperadorConversion]
        , [FactorConversion], [IdBanco], [Simbolo]
    FROM Monedas
