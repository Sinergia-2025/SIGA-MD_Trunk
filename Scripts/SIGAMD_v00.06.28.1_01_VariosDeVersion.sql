PRINT ''
PRINT 'T1. Tabla OrdenesProduccionMRP: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRP', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRP.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT 'T2. Tabla OrdenesProduccionMRPOperacion: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRPOperaciones', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRPOperaciones.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT 'T3. Tabla OrdenesProduccionMRPProductos: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRPProductos.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT 'T4. Tabla OrdenesProduccionMRPCategoriasEmpleados: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRPCategoriasEmpleados', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRPCategoriasEmpleados.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT 'T2. Tabla MRPProcesosProductivosOperaciones: Nuevos campos'
BEGIN
    ALTER TABLE OrdenesProduccionMRP ALTER COLUMN DescripcionProceso varchar(MAX) NOT NULL
END
GO
UPDATE EstadosPedidosProveedores
   SET IdTipoComprobante = NULL
 WHERE TipoEstadoPedido = 'PEDIDOSPROV'
   AND IdEstado = 'ENTREGADO'
UPDATE EstadosPedidosProveedores
   SET IdTipoComprobante = 'COTIZACIONCOM'
 WHERE TipoEstadoPedido = 'PEDIDOSPROV'
   AND IdEstado = 'ENTREGADO'


PRINT ''
PRINT 'T1. Tabla MRPProcesosProductivosProductos: Nuevos campos Deposito-Ubicacion'
IF dbo.ExisteCampo('MRPProcesosProductivosProductos', 'IdDepositoOrigen') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosProductos ADD IdSucursalOrigen int NULL
    ALTER TABLE MRPProcesosProductivosProductos ADD IdDepositoOrigen int NULL
    ALTER TABLE MRPProcesosProductivosProductos ADD IDUbicacionOrigen int NULL

	ALTER TABLE MRPProcesosProductivosProductos  WITH CHECK ADD FOREIGN KEY(IdSucursalOrigen) REFERENCES Sucursales(IdSucursal)
	ALTER TABLE MRPProcesosProductivosProductos  WITH CHECK ADD FOREIGN KEY(IdDepositoOrigen, IdSucursalOrigen)  REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)
	ALTER TABLE MRPProcesosProductivosProductos  WITH CHECK ADD FOREIGN KEY(IdDepositoOrigen, IdSucursalOrigen, IdUbicacionOrigen) REFERENCES SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)


END
GO


PRINT ''
PRINT 'T2. Tabla OrdenesProduccionMRPProductos: Nuevos campos Deposito-Ubicacion'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'IdDepositoOrigen') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdSucursalOrigen int NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdDepositoOrigen int NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD IDUbicacionOrigen int NULL

	ALTER TABLE OrdenesProduccionMRPProductos  WITH CHECK ADD FOREIGN KEY(IdSucursalOrigen) REFERENCES Sucursales(IdSucursal)
	ALTER TABLE OrdenesProduccionMRPProductos  WITH CHECK ADD FOREIGN KEY(IdDepositoOrigen, IdSucursalOrigen)  REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)
	ALTER TABLE OrdenesProduccionMRPProductos  WITH CHECK ADD FOREIGN KEY(IdDepositoOrigen, IdSucursalOrigen, IdUbicacionOrigen) REFERENCES SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)


END
GO

ALTER TABLE Dispositivos ALTER COLUMN NumeroSerieMotherboard VARCHAR(100) NOT NULL
ALTER TABLE Dispositivos ALTER COLUMN NumeroSerieDiscoPrimario VARCHAR(100) NOT NULL

ALTER TABLE Dispositivos ALTER COLUMN ResolucionPantalla VARCHAR(20) NOT NULL
ALTER TABLE Dispositivos ALTER COLUMN VersionFramework VARCHAR(20) NOT NULL



CREATE TABLE MRPCentrosProductoresCategoriasEmpleados(
	[IdCentroProductor] [int] NOT NULL,
	[IdCategoriaEmpleado] [int] NOT NULL,
	[CantidadCategoria] [decimal](16, 2) NOT NULL,
	[ValorHoraCategoria] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_MRPCentrosProductoresCategoriasEmpleados] PRIMARY KEY CLUSTERED 
(
    IdCentroProductor ASC,
    IdCategoriaEmpleado ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE MRPCentrosProductoresCategoriasEmpleados  WITH CHECK ADD  CONSTRAINT FK_CentrosProductores_Categorias FOREIGN KEY(IdCategoriaEmpleado)
REFERENCES MRPCategoriasEmpleados (IdCategoriaEmpleado)
GO
ALTER TABLE MRPCentrosProductoresCategoriasEmpleados CHECK CONSTRAINT FK_CentrosProductores_Categorias
GO
---------------------------------------------------------------------------------------------------------------------------------------------------
ALTER TABLE MRPCentrosProductoresCategoriasEmpleados  WITH CHECK ADD  CONSTRAINT FK_CentrosProductores_Centros FOREIGN KEY(IdCentroProductor)
REFERENCES MRPCentrosProductores (IdCentroProductor)
GO
ALTER TABLE MRPCentrosProductoresCategoriasEmpleados CHECK CONSTRAINT FK_CentrosProductores_Centros
GO
---------------------------------------------------------------------------------------------------------------------------------------------------


PRINT ''
PRINT '1. Parametros: Pedido Genera Una orden por Poducto seleccionado'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOGENERAORDENPRODUCCIONPORPRODUCTO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedido Genera Una orden por Poducto seleccionado'
DECLARE @valorParametro VARCHAR(MAX) = 'False'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


