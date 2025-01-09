
ALTER TABLE CLientes ADD LimiteDiasVtoFactura int null
GO

UPDATE Clientes SET LimiteDiasVtoFactura = 0
GO

ALTER TABLE CLientes ALTER COLUMN LimiteDiasVtoFactura int not null
GO

/* --------- */

ALTER TABLE AuditoriaCLientes ADD LimiteDiasVtoFactura int null
GO

UPDATE AuditoriaCLientes SET LimiteDiasVtoFactura = 0
GO
