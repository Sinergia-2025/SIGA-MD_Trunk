
ALTER TABLE dbo.LibrosBancos ADD EsModificable bit NULL
GO

UPDATE LibrosBancos SET EsModificable = 'True'
GO

UPDATE LibrosBancos SET EsModificable = 'False'
 WHERE IdCuentaBanco IN (SELECT ValorParametro from Parametros
                          WHERE IdParametro IN ('CTABANCOACREDTARJETA', 'CTABANCODEPOSITO', 'CTABANCOPAGO', 'CTABANCOTRANSFBANCARIA'))
GO

ALTER TABLE dbo.LibrosBancos ALTER COLUMN EsModificable bit NOT NULL
GO
