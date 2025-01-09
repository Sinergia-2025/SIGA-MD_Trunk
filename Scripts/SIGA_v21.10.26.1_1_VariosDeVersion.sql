PRINT ''
PRINT 'PE-33005'
BEGIN
    UPDATE Tarjetas SET Acreditacion =  0
	where IdCuentaBancaria IS NULL
END
GO

PRINT ''
PRINT 'E0 Tabla Productos: Nuevo Campo IdListaPrecios'
BEGIN
    ALTER TABLE VentasFormasPago ADD IdListaPrecios INT NULL
    ALTER TABLE VentasFormasPago ADD CONSTRAINT FK_VentasFormasPago_ListasDePrecios_1 FOREIGN KEY (IdListaPrecios) REFERENCES ListasDePrecios(IdListaPrecios)
END
