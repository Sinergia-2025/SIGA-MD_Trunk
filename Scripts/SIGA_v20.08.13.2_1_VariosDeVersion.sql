PRINT ''
PRINT '1. Correcci�n de comprobantes mal configurados'
UPDATE TiposComprobantes SET 
	Tipo = 'CTACTE'
		WHERE IdTipoComprobante = 'ANTICIPOPRVPROV'   
		OR IdTipoComprobante = 'ANTICIPOPRV'
		OR IdTipoComprobante = 'ANTICIPOPRUNICO'
GO