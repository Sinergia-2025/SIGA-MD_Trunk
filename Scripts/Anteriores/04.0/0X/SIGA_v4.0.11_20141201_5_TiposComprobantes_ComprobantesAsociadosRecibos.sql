
ALTER TABLE TiposComprobantes ALTER COLUMN ComprobantesAsociados varchar(200) NULL
GO

SET QUOTED_IDENTIFIER OFF
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = "'ANTICIPO','FACT','NCRED','eFACT','eNCRED','eNDEB','FACT-F','NCRED-F','NDEB','NDEBCHEQRECH','NDEB-F','TCK-FACT-F','TICKET-F'"                       
 WHERE IdTipoComprobante IN ('RECIBO','MINUTA')
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = "'ANTICIPOPROV','COTIZACION','DEV-COTIZACION','COTIZCHEQRECH','NDEB-COTIZACION','TICKET-NOFISCAL','SALDOINICIAL+','SALDOINICIAL-'"
 WHERE IdTipoComprobante IN ('RECIBOPROV','MINUTAPROV')
GO

SET QUOTED_IDENTIFIER ON
GO