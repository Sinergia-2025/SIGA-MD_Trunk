
ALTER TABLE CuentasCorrientesProv ADD FechaActualizacion datetime NULL
GO

UPDATE CuentasCorrientesProv 
   SET FechaActualizacion = Fecha
GO

ALTER TABLE CuentasCorrientesProv ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
