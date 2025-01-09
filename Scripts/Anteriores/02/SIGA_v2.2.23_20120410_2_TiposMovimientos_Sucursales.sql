
--En caso de no tener sucursales le oculto los Movimientos de Stock relacionados.

IF NOT EXISTS(SELECT IdSucursal, COUNT(IdSucursal) FROM Sucursales
               GROUP BY IdSucursal
               HAVING IdSucursal > 1)

       UPDATE TiposMovimientos 
          SET MuestraCombo = 'False'
        WHERE IdTipoMovimiento IN ('ENV-SUC', 'REC-SUC')
        
GO
