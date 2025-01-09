
/* ---- Deja de estar disponible para Movimientos de Stock */

DELETE TiposMovimientos WHERE IdTipoMovimiento IN ('PRODUCCION', 'COMPROD')
GO

INSERT INTO TiposMovimientos
    (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal
    ,MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio, IdContraTipoMovimiento)
  VALUES
    ('PRODUCCION', 'Produccion', 1, NULL, 'False',  
     'False',  'False',  'False', 'True', 'NO', NULL)
GO

INSERT INTO TiposMovimientos
    (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal
    ,MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio, IdContraTipoMovimiento)
  VALUES
    ('COMPROD', 'Prod. (Comp.)', -1, NULL, 'False',  
     'False',  'False',  'False', 'True', 'NO', NULL)
GO
