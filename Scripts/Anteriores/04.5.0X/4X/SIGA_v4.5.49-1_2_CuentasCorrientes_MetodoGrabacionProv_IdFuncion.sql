
/* ----- Agrego el Campo y coloco X para el Historial ----- */
/* ----- Lo nuevo sera "A" Automatico o "M" Manual ----- */

ALTER TABLE CuentasCorrientesProv ADD MetodoGrabacion char(1) NULL
GO
ALTER TABLE CuentasCorrientesProv ADD IdFuncion varchar(30) NULL
GO

UPDATE CuentasCorrientesProv
   SET MetodoGrabacion = 'X'
      ,IdFuncion = 'PagosAProveedores'
 WHERE IdTipoComprobante IN ('PAGO', 'PAGOPROV', 'ANTICIPO', 'ANTICIPOPROV')
GO

UPDATE CuentasCorrientesProv
   SET MetodoGrabacion = 'X'
      ,IdFuncion = 'MovimientosDeCompras'
  WHERE MetodoGrabacion IS NULL
GO

UPDATE CuentasCorrientesProv
   SET MetodoGrabacion = 'M'
     , IdFuncion = 'RegistrarMovCtaCteProveedores'
 WHERE IdFuncion = 'MovimientosDeCompras'
   AND NOT EXISTS 
     (SELECT * FROM Compras C
       WHERE C.IdSucursal = CuentasCorrientesProv.IdSucursal
         AND C.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
         AND C.Letra = CuentasCorrientesProv.Letra
         AND C.CentroEmisor = CuentasCorrientesProv.CentroEmisor
         AND C.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante
         AND C.IdProveedor = CuentasCorrientesProv.IdProveedor)
GO

ALTER TABLE CuentasCorrientesProv ALTER COLUMN MetodoGrabacion char(1) NOT NULL
GO
ALTER TABLE CuentasCorrientesProv ALTER COLUMN IdFuncion varchar(30) NOT NULL
GO

/* ------------- */

ALTER TABLE dbo.CuentasCorrientesProv ADD CONSTRAINT
	FK_CuentasCorrientesProv_IdFuncion FOREIGN KEY
	(
	IdFuncion
	) REFERENCES dbo.Funciones
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
