
PRINT '1.0 Borrando Trigger: Cheques.ChequesActualizaHistorial'
GO
IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[ChequesActualizaHistorial]'))
DROP TRIGGER [dbo].[ChequesActualizaHistorial]
GO

PRINT '1.1 Agregando: Cheques.IdProveedor'
GO
ALTER TABLE Cheques ADD IdProveedor [bigint] NULL
GO

PRINT '1.2 Actualizando: Cheques.IdProveedor'
GO
UPDATE Cheques 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE Cheques.TipoDocProveedor = P.TipoDocProveedor
              AND Cheques.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '4.3 Ajustando: Cheques.IdProveedor'
--GO
--ALTER TABLE Cheques ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '2.1 Agregando: ChequesHistorial.IdProveedor'
GO
ALTER TABLE ChequesHistorial ADD IdProveedor [bigint] NULL
GO

PRINT '2.2 Actualizando: ChequesHistorial.IdProveedor'
GO
UPDATE ChequesHistorial 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE ChequesHistorial.TipoDocProveedor = P.TipoDocProveedor
              AND ChequesHistorial.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '5.3 Ajustando: ChequesHistorial.IdProveedor'
--GO
--ALTER TABLE ChequesHistorial ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '3.1 Agregando: Compras.IdProveedor'
GO
ALTER TABLE Compras ADD IdProveedor [bigint] NULL
GO

PRINT '3.2 Actualizando: Compras.IdProveedor'
GO
UPDATE Compras 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE Compras.TipoDocProveedor = P.TipoDocProveedor
              AND Compras.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '3.3 Ajustando: Compras.IdProveedor'
GO
ALTER TABLE Compras ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '4.1 Agregando: Compras.IdProveedorFact'
GO
ALTER TABLE Compras ADD IdProveedorFact [bigint] NULL
GO

PRINT '4.2 Actualizando: Compras.IdProveedorFact'
GO
UPDATE Compras 
   SET IdProveedorFact = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE Compras.TipoDocProveedorFact = P.TipoDocProveedor
              AND Compras.NroDocProveedorFact  = P.NroDocProveedor
          )
 WHERE IdProveedorFact IS NULL
GO

--Puede quedar NULL
--PRINT '4.3 Ajustando: Compras.IdProveedorFact'
--GO
--ALTER TABLE Compras ALTER COLUMN IdProveedorFact [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '5.1 Agregando: ComprasCheques.IdProveedor'
GO
ALTER TABLE ComprasCheques ADD IdProveedor [bigint] NULL
GO

PRINT '5.2 Actualizando: ComprasCheques.IdProveedor'
GO
UPDATE ComprasCheques 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE ComprasCheques.TipoDocProveedor = P.TipoDocProveedor
              AND ComprasCheques.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '5.3 Ajustando: ComprasCheques.IdProveedor'
GO
ALTER TABLE ComprasCheques ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '6.1 Agregando: ComprasObservaciones.IdProveedor'
GO
ALTER TABLE ComprasObservaciones ADD IdProveedor [bigint] NULL
GO

PRINT '6.2 Actualizando: ComprasObservaciones.IdProveedor'
GO
UPDATE ComprasObservaciones 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE ComprasObservaciones.TipoDocProveedor = P.TipoDocProveedor
              AND ComprasObservaciones.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '6.3 Ajustando: ComprasObservaciones.IdProveedor'
GO
ALTER TABLE ComprasObservaciones ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '7.1 Agregando: ComprasProductos.IdProveedor'
GO
ALTER TABLE ComprasProductos ADD IdProveedor [bigint] NULL
GO

PRINT '7.2 Actualizando: ComprasProductos.IdProveedor'
GO
UPDATE ComprasProductos 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE ComprasProductos.TipoDocProveedor = P.TipoDocProveedor
              AND ComprasProductos.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '7.3 Ajustando: ComprasProductos.IdProveedor'
GO
ALTER TABLE ComprasProductos ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '8.1 Agregando: CuentasCorrientesProv.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProv ADD IdProveedor [bigint] NULL
GO

PRINT '8.2 Actualizando: CuentasCorrientesProv.IdProveedor'
GO
UPDATE CuentasCorrientesProv 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE CuentasCorrientesProv.TipoDocProveedor = P.TipoDocProveedor
              AND CuentasCorrientesProv.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '8.3 Ajustando: CuentasCorrientesProv.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProv ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '9.1 Agregando: CuentasCorrientesProvCheques.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProvCheques ADD IdProveedor [bigint] NULL
GO

PRINT '9.2 Actualizando: CuentasCorrientesProvCheques.IdProveedor'
GO
UPDATE CuentasCorrientesProvCheques 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE CuentasCorrientesProvCheques.TipoDocProveedor = P.TipoDocProveedor
              AND CuentasCorrientesProvCheques.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '9.3 Ajustando: CuentasCorrientesProvCheques.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProvCheques ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '10.1 Agregando: CuentasCorrientesProvPagos.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProvPagos ADD IdProveedor [bigint] NULL
GO

PRINT '10.2 Actualizando: CuentasCorrientesProvPagos.IdProveedor'
GO
UPDATE CuentasCorrientesProvPagos 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE CuentasCorrientesProvPagos.TipoDocProveedor = P.TipoDocProveedor
              AND CuentasCorrientesProvPagos.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '10.3 Ajustando: CuentasCorrientesProvPagos.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '11.1 Agregando: CuentasCorrientesProvRetenciones.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProvRetenciones ADD IdProveedor [bigint] NULL
GO

PRINT '11.2 Actualizando: CuentasCorrientesProvRetenciones.IdProveedor'
GO
UPDATE CuentasCorrientesProvRetenciones 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE CuentasCorrientesProvRetenciones.TipoDocProveedor = P.TipoDocProveedor
              AND CuentasCorrientesProvRetenciones.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '11.3 Ajustando: CuentasCorrientesProvRetenciones.IdProveedor'
GO
ALTER TABLE CuentasCorrientesProvRetenciones ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '12.1 Agregando: FichasProductos.IdProveedor'
GO
ALTER TABLE FichasProductos ADD IdProveedor [bigint] NULL
GO

PRINT '12.2 Actualizando: FichasProductos.IdProveedor'
GO
UPDATE FichasProductos 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE FichasProductos.TipoDocProveedor = P.TipoDocProveedor
              AND FichasProductos.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '12.3 Ajustando: FichasProductos.IdProveedor'
--GO
--ALTER TABLE FichasProductos ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '13.1 Agregando: MovimientosCompras.IdProveedor'
GO
ALTER TABLE MovimientosCompras ADD IdProveedor [bigint] NULL
GO

PRINT '13.2 Actualizando: MovimientosCompras.IdProveedor'
GO
UPDATE MovimientosCompras 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE MovimientosCompras.TipoDocProveedor = P.TipoDocProveedor
              AND MovimientosCompras.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '13.3 Ajustando: MovimientosCompras.IdProveedor'
--GO
--ALTER TABLE MovimientosCompras ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '14.1 Agregando: PedidosEstadosProveedores.IdProveedor'
GO
ALTER TABLE PedidosEstadosProveedores ADD IdProveedor [bigint] NULL
GO

PRINT '14.2 Actualizando: PedidosEstadosProveedores.IdProveedor'
GO
UPDATE PedidosEstadosProveedores 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE PedidosEstadosProveedores.TipoDocProveedor = P.TipoDocProveedor
              AND PedidosEstadosProveedores.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '14.3 Ajustando: PedidosEstadosProveedores.IdProveedor'
--GO
--ALTER TABLE PedidosEstadosProveedores ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '15.1 Agregando: PedidosProveedores.IdProveedor'
GO
ALTER TABLE PedidosProveedores ADD IdProveedor [bigint] NULL
GO

PRINT '15.2 Actualizando: PedidosProveedores.IdProveedor'
GO
UPDATE PedidosProveedores 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE PedidosProveedores.TipoDocProveedor = P.TipoDocProveedor
              AND PedidosProveedores.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '15.3 Ajustando: PedidosProveedores.IdProveedor'
GO
ALTER TABLE PedidosProveedores ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '16.1 Agregando: ProductosNrosSerie.IdProveedor'
GO
ALTER TABLE ProductosNrosSerie ADD IdProveedor [bigint] NULL
GO

PRINT '16.2 Actualizando: ProductosNrosSerie.IdProveedor'
GO
UPDATE ProductosNrosSerie 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE ProductosNrosSerie.TipoDocProveedor = P.TipoDocProveedor
              AND ProductosNrosSerie.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '16.3 Ajustando: ProductosNrosSerie.IdProveedor'
--GO
--ALTER TABLE ProductosNrosSerie ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '17.1 Agregando: ProductosProveedores.IdProveedor'
GO
ALTER TABLE ProductosProveedores ADD IdProveedor [bigint] NULL
GO

PRINT '17.2 Actualizando: ProductosProveedores.IdProveedor'
GO
UPDATE ProductosProveedores 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE ProductosProveedores.TipoDocProveedor = P.TipoDocProveedor
              AND ProductosProveedores.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '17.3 Ajustando: ProductosProveedores.IdProveedor'
GO
ALTER TABLE ProductosProveedores ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '18.1 Agregando: RecepcionNotasProveedores.IdProveedor'
GO
ALTER TABLE RecepcionNotasProveedores ADD IdProveedor [bigint] NULL
GO

PRINT '18.2 Actualizando: RecepcionNotasProveedores.IdProveedor'
GO
UPDATE RecepcionNotasProveedores 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE RecepcionNotasProveedores.TipoDocProveedor = P.TipoDocProveedor
              AND RecepcionNotasProveedores.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '18.3 Ajustando: RecepcionNotasProveedores.IdProveedor'
GO
ALTER TABLE RecepcionNotasProveedores ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '19.1 Agregando: RecepcionNotasProveedoresF.IdProveedor'
GO
ALTER TABLE RecepcionNotasProveedoresF ADD IdProveedor [bigint] NULL
GO

PRINT '19.2 Actualizando: RecepcionNotasProveedoresF.IdProveedor'
GO
UPDATE RecepcionNotasProveedoresF 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE RecepcionNotasProveedoresF.TipoDocProveedor = P.TipoDocProveedor
              AND RecepcionNotasProveedoresF.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '19.3 Ajustando: RecepcionNotasProveedoresF.IdProveedor'
GO
ALTER TABLE RecepcionNotasProveedoresF ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '20.1 Agregando: RetencionesCompras.IdProveedor'
GO
ALTER TABLE RetencionesCompras ADD IdProveedor [bigint] NULL
GO

PRINT '20.2 Actualizando: RetencionesCompras.IdProveedor'
GO
UPDATE RetencionesCompras 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE RetencionesCompras.TipoDocProveedor = P.TipoDocProveedor
              AND RetencionesCompras.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

PRINT '20.3 Ajustando: RetencionesCompras.IdProveedor'
GO
ALTER TABLE RetencionesCompras ALTER COLUMN IdProveedor [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '21.1 Agregando: Ventas.IdProveedor'
GO
ALTER TABLE Ventas ADD IdProveedor [bigint] NULL
GO

PRINT '21.2 Actualizando: Ventas.IdProveedor'
GO
UPDATE Ventas 
   SET IdProveedor = 
        ( SELECT IdProveedor FROM Proveedores P
            WHERE Ventas.TipoDocProveedor = P.TipoDocProveedor
              AND Ventas.NroDocProveedor  = P.NroDocProveedor
          )
 WHERE IdProveedor IS NULL
GO

--Puede quedar NULL
--PRINT '21.3 Ajustando: Ventas.IdProveedor'
--GO
--ALTER TABLE Ventas ALTER COLUMN IdProveedor [bigint] NOT NULL
--GO

/* -------------------------*/
