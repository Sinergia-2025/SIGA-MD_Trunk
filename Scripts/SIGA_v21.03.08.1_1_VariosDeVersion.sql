IF dbo.BaseConCuit('23278908704') = 1
BEGIN
	PRINT ''
    PRINT '1. Nuevo Informe Personalizado para ResumenDetallado: 299_ResumenDetallado.rdlc'
    INSERT INTO PersonalizacionDeInformes (IdInforme, NombreArchivo, Embebido) VALUES
		('RegistracionPagosResumenDetallado','Reportes\299_RegistracionPagosResumenDetallado.rdlc', 0)
END

PRINT ''
PRINT '2. Nuevo Informe personalizado para Distribuidora JC'
IF dbo.BaseConCuit('30714646539') = 1
BEGIN
	INSERT INTO PersonalizacionDeInformes(IdInforme, NombreArchivo, Embebido)
		VALUES ('SiLIVE_ListadoDeClientes', 'Reportes\173_ListadoDeClientesConEnvases.rdlc', 0)
END
