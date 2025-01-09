
/* ----- Agrego el Campo y coloco X para el Historial ----- */
/* ----- Lo nuevo sera "A" Automatico o "M" Manual ----- */

ALTER TABLE CuentasCorrientes ADD MetodoGrabacion char(1) NULL
GO
ALTER TABLE CuentasCorrientes ADD IdFuncion varchar(30) NULL
GO

UPDATE CuentasCorrientes
   SET MetodoGrabacion = 'X'
      ,IdFuncion = 'RecibosNuevos'
  FROM CuentasCorrientes CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
GO

UPDATE CuentasCorrientes
   SET MetodoGrabacion = 'X'
      ,IdFuncion = 'FacturacionV2'
  WHERE MetodoGrabacion IS NULL
GO

UPDATE CuentasCorrientes
   SET MetodoGrabacion = 'A'
     , IdFuncion = 'RegistrarMovCtaCteClientes'
 WHERE IdFuncion = 'FacturacionV2'
   AND NOT EXISTS 
     (SELECT * FROM Ventas V
       WHERE V.IdSucursal = CuentasCorrientes.IdSucursal
         AND V.IdTipoComprobante = CuentasCorrientes.IdTipoComprobante
         AND V.Letra = CuentasCorrientes.Letra
         AND V.CentroEmisor = CuentasCorrientes.CentroEmisor
         AND V.NumeroComprobante = CuentasCorrientes.NumeroComprobante)
GO

ALTER TABLE CuentasCorrientes ALTER COLUMN MetodoGrabacion char(1) NOT NULL
GO
ALTER TABLE CuentasCorrientes ALTER COLUMN IdFuncion varchar(30) NOT NULL
GO

/* ------------- */

ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	FK_CuentasCorrientes_IdFuncion FOREIGN KEY
	(
	IdFuncion
	) REFERENCES dbo.Funciones
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
