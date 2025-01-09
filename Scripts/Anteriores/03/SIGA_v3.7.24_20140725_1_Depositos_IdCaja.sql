
ALTER TABLE Depositos ADD IdCaja int null
GO

--SELECT * FROM CajasNombres
--GO

--SELECT IdCaja, COUNT(*) FROM CajasDetalle
-- GROUP BY IdCaja
--GO

--SELECT * FROM CajasDetalle
-- WHERE IdCaja <> 1
--GO

UPDATE Depositos SET IdCaja = 1
GO
