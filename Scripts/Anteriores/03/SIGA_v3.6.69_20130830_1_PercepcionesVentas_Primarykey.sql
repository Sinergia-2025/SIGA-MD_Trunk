
ALTER TABLE PercepcionVentas
  DROP CONSTRAINT PK_PercepcionVentas_1
GO

ALTER TABLE PercepcionVentas
  ADD CONSTRAINT PK_PercepcionVentas PRIMARY KEY (IdSucursal,IdTipoImpuesto,EmisorPercepcion,NumeroPercepcion)
GO
