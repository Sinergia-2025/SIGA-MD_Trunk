
--ALTER TABLE dbo.Ventas DROP COLUMN ComisionVendedor
--GO

--ALTER TABLE dbo.VentasProductos DROP COLUMN ComisionVendedorPorc
--GO

--ALTER TABLE dbo.VentasProductos DROP COLUMN ComisionVendedor
--GO


/* --- Creo el Campo Ventas.ComisionVendedor --- */

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD
	ComisionVendedor decimal(10, 4) NULL
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* --- Creo el Campo VentasProductos.ComisionVendedor --- */

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasProductos ADD
	ComisionVendedorPorc decimal(5, 2) NULL,
	ComisionVendedor decimal(10, 4) NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* --- Actualizo los Campo VentasProductos.ComisionVendedor y Ventas.ComisionVendedor --- */

UPDATE Ventas SET ComisionVendedor = 0
GO

UPDATE VentasProductos SET 
    ComisionVendedorPorc = 0
   ,ComisionVendedor = 0
GO

UPDATE VentasProductos
 SET VentasProductos.ComisionVendedorPorc = 
(          
SELECT M.ComisionPorVenta
   FROM Productos P, Marcas M
   WHERE VentasProductos.IdProducto = P.IdProducto
     AND P.IdMarca = M.IdMarca
)
GO

UPDATE VentasProductos
 SET VentasProductos.ComisionVendedor = 
(          
SELECT ROUND(VentasProductos.ImporteTotalNeto*M.ComisionPorVenta/100,4)
   FROM Productos P, Marcas M
   WHERE VentasProductos.IdProducto = P.IdProducto
     AND P.IdMarca = M.IdMarca
)
GO

UPDATE Ventas
 SET Ventas.ComisionVendedor = 
       ( select sum(ComisionVendedor) from VentasProductos b
           where Ventas.IdSucursal = b.IdSucursal
             AND Ventas.IdTipoComprobante = b.IdTipoComprobante
             AND Ventas.Letra = b.Letra
             AND Ventas.CentroEmisor = b.CentroEmisor
             AND Ventas.NumeroComprobante = b.NumeroComprobante
         )
 WHERE IdEstadoComprobante IS NULL
    OR IdEstadoComprobante <> 'ANULADO'
GO

/* --- Altero los Campos "ComisionVendedor" para que NO aceptes nulos --- */

ALTER TABLE dbo.Ventas ALTER COLUMN ComisionVendedor decimal(10, 4) NOT NULL
GO

ALTER TABLE dbo.VentasProductos ALTER COLUMN ComisionVendedorPorc decimal(5, 2) NOT NULL
GO

ALTER TABLE dbo.VentasProductos ALTER COLUMN ComisionVendedor decimal(10, 4) NOT NULL
GO

