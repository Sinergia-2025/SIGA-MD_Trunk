PRINT ''
PRINT '1. Nuevo Informe personalizado para E+'
IF dbo.BaseConCuit('30712079459') = 1
BEGIN
	PRINT ''
	PRINT '1.1. Nuevo Informe: Reportes\300_SaldosCtaCteClientes.rdlc'
	INSERT INTO PersonalizacionDeInformes (IdInforme, NombreArchivo, Embebido) 
		VALUES ('SaldosCtaCteClientes', 'Reportes\300_SaldosCtaCteClientes.rdlc', 0)

	PRINT ''
	PRINT '1.2. Nuevo Informe: Reportes\300_SaldosCtaCteClientesPorVendedor.rdlc'
	INSERT INTO PersonalizacionDeInformes (IdInforme, NombreArchivo, Embebido) 
		VALUES ('SaldosCtaCteClientesPorVendedor', 'Reportes\300_SaldosCtaCteClientesPorVendedor.rdlc', 0)
END


PRINT ''
PRINT '2. Actualización de Comprobantes Secundarios'
UPDATE TC SET TC.IdTipoComprobanteSecundario = 'ANTIDEV' FROM TiposComprobantes TC WHERE TC.IdTipoComprobante = 'DEVOLUCION'
UPDATE TC SET TC.IdTipoComprobanteSecundario = 'ANTIDEVPROV' FROM TiposComprobantes TC WHERE TC.IdTipoComprobante = 'DEVOLUCIONPROV'
UPDATE TC SET TC.IdTipoComprobanteSecundario = 'ANTIDEVUNICO' FROM TiposComprobantes TC WHERE TC.IdTipoComprobante = 'DEVOLUCIONUNICO'
UPDATE TC SET TC.IdTipoComprobanteSecundario = 'DEVOLUCION' FROM TiposComprobantes TC WHERE TC.IdTipoComprobante = 'ANTIDEV'
UPDATE TC SET TC.IdTipoComprobanteSecundario = 'DEVOLUCIONPROV' FROM TiposComprobantes TC WHERE TC.IdTipoComprobante = 'ANTIDEVPROV'
UPDATE TC SET TC.IdTipoComprobanteSecundario = 'DEVOLUCIONUNICO' FROM TiposComprobantes TC WHERE TC.IdTipoComprobante = 'ANTIDEVUNICO'
GO

PRINT ''
PRINT '3. Tabla RetencionesCompras: Nuevos campos AjusteManual, BaseImponibleCalculada, ImporteTotalCalculado'
ALTER TABLE RetencionesCompras ADD AjusteManual BIT NULL
ALTER TABLE RetencionesCompras ADD BaseImponibleCalculada DECIMAL(12,2) NULL
ALTER TABLE RetencionesCompras ADD ImporteTotalCalculado DECIMAL(12,2) NULL
GO

PRINT ''
PRINT '3.1. Tabla RetencionesCompras: Actualización de registros pre-existentes'
UPDATE RetencionesCompras SET AjusteManual = 'False', BaseImponibleCalculada = BaseImponible, ImporteTotalCalculado = ImporteTotal

PRINT ''
PRINT '3.2. Tabla RetencionesCompras: Cambio lo campo a NOT NULL AjusteManual, BaseImponibleCalculada, ImporteTotalCalculado'
ALTER TABLE RetencionesCompras ALTER COLUMN AjusteManual BIT NOT NULL
ALTER TABLE RetencionesCompras ALTER COLUMN BaseImponibleCalculada DECIMAL(12,2) NOT NULL
ALTER TABLE RetencionesCompras ALTER COLUMN ImporteTotalCalculado DECIMAL(12,2) NOT NULL

