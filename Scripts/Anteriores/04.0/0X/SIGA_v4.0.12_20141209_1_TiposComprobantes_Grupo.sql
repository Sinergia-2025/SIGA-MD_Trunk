
ALTER TABLE TiposComprobantes ADD Grupo varchar (15) NULL
GO

/* ---------- */

UPDATE TiposComprobantes 
   SET Grupo = Tipo
 WHERE Grupo IS NULL
GO

/* ------------- */

ALTER TABLE TiposComprobantes ALTER COLUMN Grupo varchar (15) NOT NULL
GO
