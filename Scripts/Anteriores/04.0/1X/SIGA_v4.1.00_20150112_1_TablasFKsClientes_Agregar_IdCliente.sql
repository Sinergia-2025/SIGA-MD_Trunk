
PRINT '1.1 Agregando: Alquileres.IdCliente'
GO
ALTER TABLE Alquileres ADD IdCliente [bigint] NULL
GO

PRINT '1.2 Actualizando: Alquileres.IdCliente'
GO
UPDATE Alquileres 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Alquileres.TipoDocCliente = C.TipoDocumento
              AND Alquileres.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '1.3 Ajustando: Alquileres.IdCliente'
GO
ALTER TABLE Alquileres ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '1.1 Agregando: AuditoriaClientes.IdClienteGarante'
GO
ALTER TABLE AuditoriaClientes ADD IdClienteGarante [bigint] NULL
GO

PRINT '3.2 Actualizando: AuditoriaClientes.IdClienteGarante'
GO
UPDATE AuditoriaClientes 
   SET IdClienteGarante = 
        ( SELECT IdCliente FROM Clientes C
            WHERE AuditoriaClientes.TipoDocumentoGarante = C.TipoDocumento
              AND AuditoriaClientes.NroDocumentoGarante = C.NroDocumento
          )
 WHERE IdClienteGarante IS NULL
GO

--PRINT '1.3 Ajustando: AuditoriaClientes.IdCliente'
--GO
--ALTER TABLE AuditoriaClientes ALTER COLUMN IdClienteGarante [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '2.1 Agregando: CartasAClientes.IdCliente'
GO
ALTER TABLE CartasAClientes ADD IdCliente [bigint] NULL
GO

PRINT '2.2 Actualizando: CartasAClientes.IdCliente'
GO
UPDATE CartasAClientes 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE CartasAClientes.TipoDocumento = C.TipoDocumento
              AND CartasAClientes.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '2.3 Ajustando: CartasAClientes.IdCliente'
GO
ALTER TABLE CartasAClientes ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '3.1 Agregando: CartasAClientes.IdClienteGarante'
GO
ALTER TABLE CartasAClientes ADD IdClienteGarante [bigint] NULL
GO

PRINT '3.2 Actualizando: CartasAClientes.IdClienteGarante'
GO
UPDATE CartasAClientes 
   SET IdClienteGarante = 
        ( SELECT IdCliente FROM Clientes C
            WHERE CartasAClientes.TipoDocumentoGarante = C.TipoDocumento
              AND CartasAClientes.NroDocumentoGarante = C.NroDocumento
          )
 WHERE IdClienteGarante IS NULL
GO

--Puede quedar NULL
--PRINT '3.3 Ajustando: CartasAClientes.IdClienteGarante'
--GO
--ALTER TABLE CartasAClientes ALTER COLUMN IdClienteGarante [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '4.1 Agregando: Cheques.IdCliente'
GO
ALTER TABLE Cheques ADD IdCliente [bigint] NULL
GO

PRINT '4.2 Actualizando: Cheques.IdCliente'
GO
UPDATE Cheques 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Cheques.TipoDocCliente = C.TipoDocumento
              AND Cheques.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

--Puede quedar NULL
--PRINT '4.3 Ajustando: Cheques.IdCliente'
--GO
--ALTER TABLE Cheques ALTER COLUMN IdCliente [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '5.1 Agregando: ChequesHistorial.IdCliente'
GO
ALTER TABLE ChequesHistorial ADD IdCliente [bigint] NULL
GO

PRINT '5.2 Actualizando: ChequesHistorial.IdCliente'
GO
UPDATE ChequesHistorial 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE ChequesHistorial.TipoDocCliente = C.TipoDocumento
              AND ChequesHistorial.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

--Puede quedar NULL
--PRINT '5.3 Ajustando: ChequesHistorial.IdCliente'
--GO
--ALTER TABLE ChequesHistorial ALTER COLUMN IdCliente [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '6.1 Agregando: Clientes.IdClienteGarante'
GO
ALTER TABLE Clientes ADD IdClienteGarante [bigint] NULL
GO

PRINT '6.2 Actualizando: CartasAClientes.IdClienteGarante'
GO
UPDATE Clientes 
   SET IdClienteGarante = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Clientes.TipoDocumentoGarante = C.TipoDocumento
              AND Clientes.NroDocumentoGarante = C.NroDocumento
          )
 WHERE IdClienteGarante IS NULL
GO

--Puede quedar NULL
--PRINT '6.3 Ajustando: Clientes.IdClienteGarante'
--GO
--ALTER TABLE Clientes ALTER COLUMN IdClienteGarante [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '7.1 Agregando: ClientesActividades.IdCliente'
GO
ALTER TABLE ClientesActividades ADD IdCliente [bigint] NULL
GO

PRINT '7.2 Actualizando: ClientesActividades.IdCliente'
GO
UPDATE ClientesActividades 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE ClientesActividades.TipoDocumento = C.TipoDocumento
              AND ClientesActividades.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '7.3 Ajustando: ClientesActividades.IdCliente'
GO
ALTER TABLE ClientesActividades ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '8.1 Agregando: ClientesDescuentosMarcas.IdCliente'
GO
ALTER TABLE ClientesDescuentosMarcas ADD IdCliente [bigint] NULL
GO

PRINT '8.2 Actualizando: ClientesDescuentosMarcas.IdCliente'
GO
UPDATE ClientesDescuentosMarcas 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE ClientesDescuentosMarcas.TipoDocumento = C.TipoDocumento
              AND ClientesDescuentosMarcas.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '8.3 Ajustando: ClientesDescuentosMarcas.IdCliente'
GO
ALTER TABLE ClientesDescuentosMarcas ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '9.1 Agregando: ClientesDescuentosSubRubros.IdCliente'
GO
ALTER TABLE ClientesDescuentosSubRubros ADD IdCliente [bigint] NULL
GO

PRINT '9.2 Actualizando: ClientesDescuentosSubRubros.IdCliente'
GO
UPDATE ClientesDescuentosSubRubros 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE ClientesDescuentosSubRubros.TipoDocumento = C.TipoDocumento
              AND ClientesDescuentosSubRubros.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '9.3 Ajustando: ClientesDescuentosSubRubros.IdCliente'
GO
ALTER TABLE ClientesDescuentosSubRubros ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '10.1 Agregando: ClientesMarcasListasDePrecios.IdCliente'
GO
ALTER TABLE ClientesMarcasListasDePrecios ADD IdCliente [bigint] NULL
GO

PRINT '10.2 Actualizando: ClientesMarcasListasDePrecios.IdCliente'
GO
UPDATE ClientesMarcasListasDePrecios 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE ClientesMarcasListasDePrecios.TipoDocumento = C.TipoDocumento
              AND ClientesMarcasListasDePrecios.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '10.3 Ajustando: ClientesMarcasListasDePrecios.IdCliente'
GO
ALTER TABLE ClientesMarcasListasDePrecios ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '11.1 Agregando: ClientesSucursales.IdCliente'
GO
ALTER TABLE ClientesSucursales ADD IdCliente [bigint] NULL
GO

PRINT '11.2 Actualizando: ClientesSucursales.IdCliente'
GO
UPDATE ClientesSucursales 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE ClientesSucursales.TipoDocumento = C.TipoDocumento
              AND ClientesSucursales.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '11.3 Ajustando: ClientesSucursales.IdCliente'
GO
ALTER TABLE ClientesSucursales ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '12.1 Agregando: CuentasCorrientes.IdCliente'
GO
ALTER TABLE CuentasCorrientes ADD IdCliente [bigint] NULL
GO

PRINT '12.2 Actualizando: CuentasCorrientes.IdCliente'
GO
UPDATE CuentasCorrientes 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE CuentasCorrientes.TipoDocCliente = C.TipoDocumento
              AND CuentasCorrientes.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '12.3 Ajustando: CuentasCorrientes.IdCliente'
GO
ALTER TABLE CuentasCorrientes ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '13.1 Agregando: CuentasCorrientesRetenciones.IdCliente'
GO
ALTER TABLE CuentasCorrientesRetenciones ADD IdCliente [bigint] NULL
GO

PRINT '13.2 Actualizando: CuentasCorrientesRetenciones.IdCliente'
GO
UPDATE CuentasCorrientesRetenciones 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE CuentasCorrientesRetenciones.TipoDocCliente = C.TipoDocumento
              AND CuentasCorrientesRetenciones.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '13.3 Ajustando: CuentasCorrientesRetenciones.IdCliente'
GO
ALTER TABLE CuentasCorrientesRetenciones ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '14.1 Agregando: Fichas.IdCliente'
GO
ALTER TABLE Fichas ADD IdCliente [bigint] NULL
GO

PRINT '14.2 Actualizando: Fichas.IdCliente'
GO
UPDATE Fichas 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Fichas.TipoDocumento = C.TipoDocumento
              AND Fichas.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '14.3 Ajustando: Fichas.IdCliente'
GO
ALTER TABLE Fichas ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '15.1 Agregando: FichasPagos.IdCliente'
GO
ALTER TABLE FichasPagos ADD IdCliente [bigint] NULL
GO

PRINT '15.2 Actualizando: FichasPagos.IdCliente'
GO
UPDATE FichasPagos 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE FichasPagos.TipoDocumento = C.TipoDocumento
              AND FichasPagos.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '15.3 Ajustando: FichasPagos.IdCliente'
GO
ALTER TABLE FichasPagos ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '16.1 Agregando: FichasPagosAjustes.IdCliente'
GO
ALTER TABLE FichasPagosAjustes ADD IdCliente [bigint] NULL
GO

PRINT '16.2 Actualizando: FichasPagosAjustes.IdCliente'
GO
UPDATE FichasPagosAjustes 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE FichasPagosAjustes.TipoDocumento = C.TipoDocumento
              AND FichasPagosAjustes.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '16.3 Ajustando: FichasPagosAjustes.IdCliente'
GO
ALTER TABLE FichasPagosAjustes ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '17.1 Agregando: FichasPagosDetalle.IdCliente'
GO
ALTER TABLE FichasPagosDetalle ADD IdCliente [bigint] NULL
GO

PRINT '17.2 Actualizando: FichasPagosDetalle.IdCliente'
GO
UPDATE FichasPagosDetalle 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE FichasPagosDetalle.TipoDocumento = C.TipoDocumento
              AND FichasPagosDetalle.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '17.3 Ajustando: FichasPagosDetalle.IdCliente'
GO
ALTER TABLE FichasPagosDetalle ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '18.1 Agregando: FichasProductos.IdCliente'
GO
ALTER TABLE FichasProductos ADD IdCliente [bigint] NULL
GO

PRINT '18.2 Actualizando: FichasProductos.IdCliente'
GO
UPDATE FichasProductos 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE FichasProductos.TipoDocumento = C.TipoDocumento
              AND FichasProductos.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '18.3 Ajustando: FichasProductos.IdCliente'
GO
ALTER TABLE FichasProductos ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '19.1 Agregando: MovimientosVentas.IdCliente'
GO
ALTER TABLE MovimientosVentas ADD IdCliente [bigint] NULL
GO

PRINT '19.2 Actualizando: MovimientosVentas.IdCliente'
GO
UPDATE MovimientosVentas 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE MovimientosVentas.TipoDocCliente = C.TipoDocumento
              AND MovimientosVentas.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

--Puede quedar NULL
--PRINT '1.3 Ajustando: MovimientosVentas.IdCliente'
--GO
--ALTER TABLE MovimientosVentas ALTER COLUMN IdCliente [bigint] NOT NULL
--GO

/* -------------------------*/

PRINT '20.1 Agregando: Pedidos.IdCliente'
GO
ALTER TABLE Pedidos ADD IdCliente [bigint] NULL
GO

PRINT '20.2 Actualizando: Pedidos.IdCliente'
GO
UPDATE Pedidos 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Pedidos.TipoDocumento = C.TipoDocumento
              AND Pedidos.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '20.3 Ajustando: Pedidos.IdCliente'
GO
ALTER TABLE Pedidos ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '21.1 Agregando: PercepcionVentas.IdCliente'
GO
ALTER TABLE PercepcionVentas ADD IdCliente [bigint] NULL
GO

PRINT '21.2 Actualizando: PercepcionVentas.IdCliente'
GO
UPDATE PercepcionVentas 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE PercepcionVentas.TipoDocCliente = C.TipoDocumento
              AND PercepcionVentas.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '21.3 Ajustando: PercepcionVentas.IdCliente'
GO
ALTER TABLE PercepcionVentas ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '22.1 Agregando: RecepcionNotas.IdCliente'
GO
ALTER TABLE RecepcionNotas ADD IdCliente [bigint] NULL
GO

PRINT '22.2 Actualizando: RecepcionNotas.IdCliente'
GO
UPDATE RecepcionNotas 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE RecepcionNotas.TipoDocumento = C.TipoDocumento
              AND RecepcionNotas.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '22.3 Ajustando: RecepcionNotas.IdCliente'
GO
ALTER TABLE RecepcionNotas ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '23.1 Agregando: RecepcionNotasF.IdCliente'
GO
ALTER TABLE RecepcionNotasF ADD IdCliente [bigint] NULL
GO

PRINT '23.2 Actualizando: RecepcionNotasF.IdCliente'
GO
UPDATE RecepcionNotasF 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE RecepcionNotasF.TipoDocumento = C.TipoDocumento
              AND RecepcionNotasF.NroDocumento = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '23.3 Ajustando: RecepcionNotasF.IdCliente'
GO
ALTER TABLE RecepcionNotasF ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/


PRINT '24.1 Agregando: Retenciones.IdCliente'
GO
ALTER TABLE Retenciones ADD IdCliente [bigint] NULL
GO

PRINT '24.2 Actualizando: Retenciones.IdCliente'
GO
UPDATE Retenciones 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Retenciones.TipoDocCliente = C.TipoDocumento
              AND Retenciones.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '24.3 Ajustando: Retenciones.IdCliente'
GO
ALTER TABLE Retenciones ALTER COLUMN IdCliente [bigint] NOT NULL
GO

/* -------------------------*/

PRINT '25.1 Agregando: Ventas.IdCliente'
GO
ALTER TABLE Ventas ADD IdCliente [bigint] NULL
GO

PRINT '25.2 Actualizando: Ventas.IdCliente'
GO
UPDATE Ventas 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes C
            WHERE Ventas.TipoDocCliente = C.TipoDocumento
              AND Ventas.NroDocCliente = C.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

PRINT '25.3 Ajustando: Ventas.IdCliente'
GO
ALTER TABLE Ventas ALTER COLUMN IdCliente [bigint] NOT NULL
GO

