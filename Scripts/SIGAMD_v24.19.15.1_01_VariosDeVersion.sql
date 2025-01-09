
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPProductos') = 1
BEGIN
UPDATE funciones SET Nombre = 'Inf. Detalle Operaciones de Orden Producción', 
				     Descripcion = 'Inf. Detalle Operaciones de Orden Producción'
where id = 'InfOrdenProduccionMRPProductos'
END

ALTER TABLE TarjetasCupones ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE TarjetasCuponesHistorial ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE CuentasCorrientesTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE VentasTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

IF dbo.ExisteCampo('Proveedores', 'IdClienteVinculado') = 0
BEGIN
    ALTER TABLE dbo.Proveedores ADD IdClienteVinculado bigint NULL
END
GO
IF dbo.ExisteFK('FK_Proveedores_Clientes') = 0
BEGIN
    ALTER TABLE dbo.Proveedores ADD CONSTRAINT FK_Proveedores_Clientes
        FOREIGN KEY (IdClienteVinculado)
        REFERENCES dbo.Clientes (IdCliente)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO