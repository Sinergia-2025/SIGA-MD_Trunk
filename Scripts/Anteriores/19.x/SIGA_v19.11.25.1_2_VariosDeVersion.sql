
PRINT ''
PRINT '1. Impresoras: Creo la Impresora LIQUIDO y asocios los comprobantes.'
GO

INSERT INTO Impresoras
           (IdSucursal, IdImpresora, TipoImpresora, CentroEmisor, ComprobantesHabilitados
           ,Puerto, Velocidad, EsProtocoloExtendido, Modelo, OrigenPapel, CantidadCopias, TipoFormulario
           ,TamanioLetra, Marca, Metodo, AbrirCajonDinero, GrabarLOGs, ImprimirLineaALinea, CierreFiscalEstandar
           ,PorCtaOrden, DireccionCentroEmisor, IdLocalidadCentroEmisor)
     VALUES
           (1, 'LIQUIDO', 'NORMAL', 5554, 'LIQUIDO,LIQUIDO-NC,DESEMBOLSO,ANTICIPODES,MINUTADESEMB'
			,0, 0, 'False', NULL, NULL, 0, NULL	
			,0, NULL, NULL, 'False', 'False', 'False', 'False'
           ,'False', NULL, NULL)
GO
