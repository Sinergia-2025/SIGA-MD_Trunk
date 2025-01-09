
UPDATE Ventas 
  SET LetraFact = 'X'
 WHERE IdTipoComprobanteFact = 'REMITO' OR  IdTipoComprobanteFact = 'REMITOTRANSP'
GO
