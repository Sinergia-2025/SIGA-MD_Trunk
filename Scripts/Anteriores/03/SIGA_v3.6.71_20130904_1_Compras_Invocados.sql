
ALTER TABLE dbo.Compras ADD
	CantidadInvocados int NULL, 
	TipoDocProveedorFact	varchar(5)	NULL,
    NroDocProveedorFact	 bigint	NULL
 GO

UPDATE dbo.Compras  SET
	CantidadInvocados = (SELECT COUNT(*) AS Invoco FROM Compras C 
	                       WHERE C.IdSucursal = Compras.IdSucursal 
	                         AND C.IdTipoComprobanteFact = Compras.IdTipoComprobante 
	                         AND C.LetraFact = Compras.Letra
	                         AND C.CentroEmisorFact = Compras.CentroEmisor
	                         AND C.NumeroComprobanteFact = Compras.NumeroComprobante
	                         AND C.TipoDocProveedorFact = Compras.TipoDocProveedor
	                         AND C.NroDocProveedorFact = Compras.NroDocProveedor
	                     ) 
	
GO

ALTER TABLE dbo.Compras ALTER COLUMN
	CantidadInvocados int NOT NULL
GO

