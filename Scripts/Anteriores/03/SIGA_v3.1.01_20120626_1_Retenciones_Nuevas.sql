
-- NUEVAS RETENCIONES

-- Tipos de Impuestos.

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto, Tipo)
     VALUES ('RDREI', 'Retencion de DREI', 'RETENCION')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto, Tipo)
     VALUES ('RSIJP', 'Retencion de SIJP', 'RETENCION')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto, Tipo)
     VALUES ('RSUSS', 'Retencion de SUSS', 'RETENCION')
GO

--INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
--     VALUES ('RLIMP', 'Retencion de LIMP')
--GO


-- Alicuotas.

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('RDREI', 0, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('RSIJP', 0, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('RSUSS', 0, 'True')
GO

--INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
--     VALUES ('RLIMP', 0, 'True')
--GO
