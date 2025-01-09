
PRINT ''
PRINT '1. Nuevo Parametro: Calculo Pesos al cargar monto Tarjeta'
GO

DECLARE @ValorParametro varchar(max)
SET @ValorParametro = 'False';

-- EXXA S.A.
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('50000000024', '30709591912'))
BEGIN
    SET @ValorParametro = 'True';
END

MERGE INTO Parametros AS P
     USING (SELECT 'FACTURACIONRAPIDARECALCULAREFECTIVOALCARGARTARJETA' AS IdParametro, @ValorParametro  ValorParametro, 'Facturación Rápida recalcular Efectivo al cargar Tarjeta' AS DescripcionParametro
            ) AS PT ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL , PT.DescripcionParametro)
;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro = 'FACTURACIONRAPIDARECALCULAREFECTIVOALCARGARTARJETA'
--;


PRINT ''
PRINT '2. Tabla VentasNumero: Creo el registro de REMITOTRANSP si no existe.'
GO

IF NOT EXISTS (SELECT IdTipoComprobante FROM VentasNumeros WHERE IdTipoComprobante = 'REMITOTRANSP')
BEGIN
    INSERT INTO VentasNumeros
               (IdTipoComprobante,LetraFiscal,CentroEmisor,IdSucursal,Numero,IdTipoComprobanteRelacionado,Fecha)
         SELECT TC.IdTipoComprobante, TC.LetrasHabilitadas, I.CentroEmisor, I.IdSucursal, 0, NULL, '19000101'
           FROM TiposComprobantes TC
          INNER JOIN Impresoras I ON I.ComprobantesHabilitados LIKE '%' + TC.IdTipoComprobante + '%'
          WHERE TC.IdTipoComprobante = 'REMITOTRANSP';
END

-- Si no existe porque no esta vinculado, pongo fijo Sucursal 1 y Emisor 1.

IF NOT EXISTS (SELECT IdTipoComprobante FROM VentasNumeros WHERE IdTipoComprobante = 'REMITOTRANSP')
BEGIN
    INSERT INTO VentasNumeros
               (IdTipoComprobante,LetraFiscal,CentroEmisor,IdSucursal,Numero,IdTipoComprobanteRelacionado,Fecha)
         SELECT TC.IdTipoComprobante, TC.LetrasHabilitadas, 1 AS xxCentroEmisor, 1 AS xxIdSucursal, 0, NULL, '19000101'
           FROM TiposComprobantes TC
          WHERE TC.IdTipoComprobante = 'REMITOTRANSP';
END


PRINT ''
PRINT '3. Tabla VentasNumero: Vinculo REMITOTRANSP y REMITOCOMTRANSP.'
GO

UPDATE VentasNumeros
   SET IdTipoComprobanteRelacionado = 'REMITOCOMTRANSP'
 WHERE IdTipoComprobante = 'REMITOTRANSP'
;

INSERT INTO VentasNumeros
           (IdTipoComprobante,LetraFiscal,CentroEmisor,IdSucursal,Numero,IdTipoComprobanteRelacionado,Fecha)

     SELECT 'REMITOCOMTRANSP',LetraFiscal,CentroEmisor,IdSucursal,Numero,'REMITOTRANSP',Fecha
       FROM VentasNumeros
      WHERE IdTipoComprobante = 'REMITOTRANSP'
;

PRINT ''
PRINT '4. Tabla CRMNovedades: Nuevo campo TiempoEstimado.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CRMNovedades ADD
	TiempoEstimado decimal(12, 2) NULL
GO
ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

UPDATE dbo.CRMNovedades SET TiempoEstimado = 0
GO
