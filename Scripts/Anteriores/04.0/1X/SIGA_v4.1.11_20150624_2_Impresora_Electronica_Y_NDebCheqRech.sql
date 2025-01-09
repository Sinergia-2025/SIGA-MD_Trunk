

-- Borro las Vinculaciones entre tablas 

PRINT '1. Creo la Impresora ELECTRONICA en caso de NO Existir'
GO

IF NOT EXISTS (SELECT IdImpresora FROM Impresoras
                WHERE IdImpresora = 'ELECTRONICA')


	 INSERT Impresoras 
		(IdSucursal, IdImpresora, TipoImpresora, CentroEmisor, ComprobantesHabilitados
	     ,Puerto, Velocidad, EsProtocoloExtendido, Modelo, OrigenPapel, CantidadCopias, TipoFormulario, TamanioLetra, Marca, Metodo, AbrirCajonDinero, GrabarLOGs, ImprimirLineaALinea, CierreFiscalEstandar, PorCtaOrden) 
	VALUES (1, 'ELECTRONICA', 'NORMAL', 55, 'ePRE-FACT,ePRE-NCRED,ePRE-NDEB,eFACT,eNCRED,eNDEB'
		 ,'0', 0, 0, NULL, NULL, 0, NULL, 0, NULL, NULL, 0, 0, 0, 0, 0)
     
GO


PRINT '2. Le Agrego la NDEB de Cheque Rechazado'
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = ComprobantesHabilitados + ',ePRE-NDEBCHEQR,eNDEBCHEQRECH'
  WHERE IdImpresora = 'ELECTRONICA'
GO

-- (CHR 39 es la comilla simple que no la puedo asignar manualmente)
PRINT '3. Vinculo la NDEB de Cheque Rechazado a los Recibos en Blanco'

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'eNDEBCHEQRECH' + CHAR(39)
 WHERE IdTipoComprobante IN ('RECIBO','RECIBOe','MINUTA')
GO

--- Utilizo el Emisor de la Impresora ELECTRONICA
PRINT '4. Vinculo en el VentasNumeros la NDEB de Cheque Rechazado a la NDEB'


IF EXISTS (SELECT ValorParametro FROM Parametros
            WHERE IdParametro = 'CATEGORIAFISCALEMPRESA'
              AND ValorParametro = '2')
    BEGIN

		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'ePRE-NDEB', 'A', CentroEmisor, IdSucursal, 0, 'ePRE-NDEBCHEQR', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;
		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'ePRE-NDEBCHEQR', 'A', CentroEmisor, IdSucursal, 0, 'ePRE-NDEB', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;

		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'ePRE-NDEB', 'B', CentroEmisor, IdSucursal, 0, 'ePRE-NDEBCHEQR', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;
		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'ePRE-NDEBCHEQR', 'B', CentroEmisor, IdSucursal, 0, 'ePRE-NDEB', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;

		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'eNDEB', 'A', CentroEmisor, IdSucursal, 0, 'eNDEBCHEQR', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;
		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'eNDEBCHEQRECH', 'A', CentroEmisor, IdSucursal, 0, 'eNDEB', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;

		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'eNDEB', 'B', CentroEmisor, IdSucursal, 0, 'eNDEBCHEQR', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;
		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'eNDEBCHEQRECH', 'B', CentroEmisor, IdSucursal, 0, 'eNDEB', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;

    END
ELSE
    BEGIN

		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'ePRE-NDEB', 'C', CentroEmisor, IdSucursal, 0, 'ePRE-NDEBCHEQR', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;
		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'ePRE-NDEBCHEQR', 'C', CentroEmisor, IdSucursal, 0, 'ePRE-NDEB', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;

		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'eNDEB', 'C', CentroEmisor, IdSucursal, 0, 'eNDEBCHEQR', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;
		INSERT INTO VentasNumeros
			 (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero
			 ,IdTipoComprobanteRelacionado, Fecha)
		SELECT 'eNDEBCHEQRECH', 'C', CentroEmisor, IdSucursal, 0, 'eNDEB', '1900-01-01' FROM Impresoras WHERE IdImpresora = 'ELECTRONICA'
		;

    END
GO
