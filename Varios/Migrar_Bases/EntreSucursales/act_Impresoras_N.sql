DECLARE @IdSucOrigen INT = 2
DECLARE @IdSucDestino INT = 3
;

PRINT ''
PRINT '1. Elimino ImpresorasPCs.'
;

DELETE SIGA_Separada.dbo.ImpresorasPCs
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '2. Elimino Impresoras.'
;
DELETE SIGA_Separada.dbo.Impresoras
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '3. Inserto Impresoras.'
;
INSERT INTO SIGA_Separada.dbo.Impresoras
           (IdSucursal
           ,IdImpresora
           ,TipoImpresora
           ,CentroEmisor
           ,ComprobantesHabilitados
           ,Puerto
           ,Velocidad
           ,EsProtocoloExtendido
           ,Modelo
           ,OrigenPapel
           ,CantidadCopias
           ,TipoFormulario
           ,TamanioLetra
           ,Marca
           ,Metodo
           ,AbrirCajonDinero
           ,GrabarLOGs
           ,ImprimirLineaALinea
           ,CierreFiscalEstandar
           ,PorCtaOrden)
SELECT @IdSucDestino AS IdSucursal
           ,IdImpresora
           ,TipoImpresora
           ,CentroEmisor
           ,ComprobantesHabilitados
           ,Puerto
           ,Velocidad
           ,EsProtocoloExtendido
           ,Modelo
           ,OrigenPapel
           ,CantidadCopias
           ,TipoFormulario
           ,TamanioLetra
           ,Marca
           ,Metodo
           ,AbrirCajonDinero
           ,GrabarLOGs
           ,ImprimirLineaALinea
           ,CierreFiscalEstandar
           ,PorCtaOrden
  FROM SIGA.dbo.Impresoras I 
  WHERE I.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '4. Inserto ImpresorasPCs.'
;
INSERT INTO SIGA_Separada.dbo.ImpresorasPCs
           (IdSucursal
           ,IdImpresora
           ,NombrePC)
SELECT @IdSucDestino AS IdSucursal
           ,IdImpresora
           ,NombrePC
  FROM SIGA.dbo.ImpresorasPCs IP
  WHERE IP.IdSucursal = @IdSucOrigen
;
