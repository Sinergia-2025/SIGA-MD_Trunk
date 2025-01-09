
UPDATE TiposMovimientos 
   SET ComprobantesAsociados =  Replace(ComprobantesAsociados, ',NDEBCHEQRECHCOM', '') 
WHERE IdTipoMovimiento = 'VARIOS'
GO

--- Lo paso al lugar que correspondia.
UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',NDEBCHEQRECHCOM'
  WHERE IdTipoMovimiento = 'COMPRA'
GO
