PRINT ''
PRINT '1. Tabla Monedas: Cambiar tamaño de FactorConversion a decimal(7,3)'
--cambiamos el ancho del campo por si en el futuro usamos 3 decimales!
ALTER TABLE Monedas ALTER COLUMN FactorConversion decimal(7,3) NOT NULL;


PRINT ''
PRINT '2. Tabla CuentasCorrientes: Agrego Campo Direccion y Localidad'
ALTER TABLE dbo.CuentasCorrientes ADD Direccion varchar(100) null;
ALTER TABLE dbo.CuentasCorrientes ADD IdLocalidad int null;
ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_Localidad] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] (IdLocalidad)
GO
PRINT '2.1. Tabla CuentasCorrientes: Valores por defecto para Direccion y Localidad (desde Ventas)'
UPDATE CuentasCorrientes
   SET Direccion    = V.Direccion
     , IdLocalidad  = V.IdLocalidad
  FROM CuentasCorrientes CC
 INNER JOIN Ventas V ON CC.IdSucursal = V.IdSucursal
                    AND CC.IdTipoComprobante = V.IdTipoComprobante
                    AND CC.Letra = V.Letra
                    AND CC.CentroEmisor = V.CentroEmisor 
                    AND CC.NumeroComprobante = V.NumeroComprobante;

PRINT '2.2. Tabla CuentasCorrientes: Valores por defecto para Direccion y Localidad (desde Clientes)'
UPDATE CuentasCorrientes
   SET Direccion    = C.Direccion
     , IdLocalidad  = C.IdLocalidad
  FROM CuentasCorrientes CC
 INNER JOIN Clientes AS C ON  CC.IdCliente = C.IdCliente
 WHERE  CC.Direccion  IS NULL

PRINT '2.3. Tabla CuentasCorrientes: NOT NULL para Direccion y Localidad'
ALTER TABLE dbo.CuentasCorrientes ALTER COLUMN Direccion varchar(100) not null;
ALTER TABLE dbo.CuentasCorrientes ALTER COLUMN IdLocalidad int not null;
