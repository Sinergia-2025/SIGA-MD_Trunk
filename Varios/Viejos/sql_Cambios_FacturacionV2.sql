1)

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/

ALTER TABLE dbo.Ventas ADD
	IdEstadoComprobante varchar(10) NULL,
	IdTipoComprobanteFact varchar(10) NULL,
	LetraFact varchar(1) NULL,
	CentroEmisorFact int NULL,
	NumeroComprobanteFact bigint NULL
GO


/* ---------------------------------------------------- */

2) Agregar en Tabla "TiposComprobantes". Registros nuevos:

CANCELA-REMITO
DESHACE-REMITO
FICHAS
PROFORMA

Mirar en TiposComprobantes.xls


/* ---------------------------------------------------- */

3) En Tabla "TiposComprobantes".

   Repasar campos "CoeficientoStock" y "CoeficienteValores"


/* ---------------------------------------------------- */


4) En Tabla "TiposMovimientos". Registro nuevo:


DEVOLUCION

Mirar en TiposMovimientoss.xls


/* ---------------------------------------------------- */


5) Aumentar ancho de campos en Tablas .


Impresoras
----------
ComprobantesHabilitados: varchar(100)



TiposComprobantes / MovimientosCompras / MovimientosVentas
Ventas / VentasProductos / VentasNumeros / Compras / ComprasProductos
----------------------------------------------------------------------
IdTipoComprobante: Varchar(15)


Ventas 
------
IdTipoComprobanteFact: Varchar(15)



/* ---------------------------------------------------- */

6) Nuevos campos en tabla "TiposComprobantes"


ModificaAlFacturar	varchar(15)
EsFacturador		bit

/* ---------------------------------------------------- */

