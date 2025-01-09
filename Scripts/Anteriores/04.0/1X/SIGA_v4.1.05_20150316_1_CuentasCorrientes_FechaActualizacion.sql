
ALTER TABLE CuentasCorrientes ADD FechaActualizacion datetime NULL
GO

UPDATE CuentasCorrientes 
   SET FechaActualizacion = Fecha
GO

ALTER TABLE CuentasCorrientes ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
