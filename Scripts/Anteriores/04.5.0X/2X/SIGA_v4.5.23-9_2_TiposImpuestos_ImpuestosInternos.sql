
INSERT INTO TiposImpuestos
  (IdTipoImpuesto, NombreTipoImpuesto, Tipo, IdCuentaDebe, IdCuentaHaber, IdCuentaCaja, CodigoArticuloInciso, ArticuloInciso, AplicativoAfip)
VALUES
  ('IMINT', 'Imp. Internos', 'INTERNO', NULL, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO Impuestos
  (IdTipoImpuesto, Alicuota, Activo, IdCuentaCompras, IdCuentaVentas)
VALUES
  ('IMINT', 0, 1, NULL, NULL)
GO
