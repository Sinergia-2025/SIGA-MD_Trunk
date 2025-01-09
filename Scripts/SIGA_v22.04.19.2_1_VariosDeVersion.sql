PRINT ''
PRINT '1. Tabla Nueva: AFIPConceptosCM05'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AFIPConceptosCM05')
BEGIN
    CREATE TABLE [dbo].[AFIPConceptosCM05](
        [IdConceptoCM05] [int] NOT NULL,
        [DescripcionConceptoCM05] [varchar](50) NOT NULL,
        [TipoConceptoCM05] [varchar](10) NOT NULL,
     CONSTRAINT [PK_AFIPConceptosCM05] PRIMARY KEY CLUSTERED ([IdConceptoCM05] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END

PRINT ''
PRINT '2. Tabla Clientes: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.Clientes ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT FK_Clientes_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '2.1. Tabla AuditoriaClientes: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.AuditoriaClientes ADD IdConceptoCM05 int NULL
GO

PRINT ''
PRINT '3. Tabla Prospectos: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.Prospectos ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT FK_Prospectos_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '3.1. Tabla AuditoriaProspectos: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.AuditoriaProspectos ADD IdConceptoCM05 int NULL
GO

PRINT ''
PRINT '4. Tabla Proveedores: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.Proveedores ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT FK_Proveedores_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '5. Tabla CuentasBancos: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.CuentasBancos ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.CuentasBancos ADD CONSTRAINT FK_CuentasBancos_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '6. Tabla CuentasDeCajas: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.CuentasDeCajas ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.CuentasDeCajas ADD CONSTRAINT FK_CuentasDeCajas_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '7. Tabla Ventas: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.Ventas ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '8. Tabla Compras: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.Compras ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.Compras ADD CONSTRAINT FK_Compras_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '9. Tabla CajasDetalle: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.CajasDetalle ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.CajasDetalle ADD CONSTRAINT FK_CajasDetalle_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '10. Tabla LibrosBancos: Nuevo campo IdConceptoCM05'
ALTER TABLE dbo.LibrosBancos ADD IdConceptoCM05 int NULL
GO
ALTER TABLE dbo.LibrosBancos ADD CONSTRAINT FK_LibrosBancos_AFIPConceptosCM05 
    FOREIGN KEY (IdConceptoCM05)
    REFERENCES dbo.AFIPConceptosCM05 (IdConceptoCM05)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '11. Tabla Productos: Cambiar campo Observacion y ObservacionCompras a VARCHAR(2000)'
ALTER TABLE Productos ALTER COLUMN Observacion VARCHAR(2000)
ALTER TABLE Productos ALTER COLUMN ObservacionCompras VARCHAR(2000)

PRINT ''
PRINT '11.1. Tabla AuditoriaProductos: Cambiar campo Observacion y ObservacionCompras a VARCHAR(2000)'
ALTER TABLE AuditoriaProductos ALTER COLUMN Observacion VARCHAR(2000)
ALTER TABLE AuditoriaProductos ALTER COLUMN ObservacionCompras VARCHAR(2000)

PRINT ''
PRINT '12. Tabla HistorialPrecios: Nuevo campo IdHistorialPrecios'
ALTER TABLE dbo.HistorialPrecios ADD IdHistorialPrecios bigint IDENTITY(1, 1)
GO
ALTER TABLE dbo.HistorialPrecios DROP CONSTRAINT PK_HistorialPrecios
GO
ALTER TABLE dbo.HistorialPrecios ADD CONSTRAINT PK_HistorialPrecios PRIMARY KEY CLUSTERED 
	(IdProducto, IdSucursal, IdListaPrecios, FechaHora, IdHistorialPrecios ) 
    WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '13. Tabla PedidosEstados: Nuevo campo IdHistorialPrecios'
ALTER TABLE dbo.PedidosEstados ADD AnulacionPorModificacion bit NULL
GO
UPDATE PedidosEstados SET AnulacionPorModificacion = 'False'
ALTER TABLE dbo.PedidosEstados ALTER COLUMN AnulacionPorModificacion bit NOT NULL
GO


