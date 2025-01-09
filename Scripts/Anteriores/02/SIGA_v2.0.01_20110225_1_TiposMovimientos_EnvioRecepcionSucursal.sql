
INSERT INTO TiposMovimientos
    (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal
    ,MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio)
  VALUES
    ('ENV-SUC', 'Envio a Sucursal', -1, NULL, 'True'
    ,'True', 'False', 'False', 'True', 'PrecioCosto')
GO


INSERT INTO TiposMovimientos
    (IdTipoMovimiento, Descripcion, CoeficienteStock, ComprobantesAsociados, AsociaSucursal
    ,MuestraCombo, HabilitaDestinatario, HabilitaRubro, Imprime, CargaPrecio)
  VALUES
    ('REC-SUC', 'Recepción de Sucursal', 1, NULL, 'True'
    ,'True', 'False', 'False', 'True', 'PrecioCosto')
GO

