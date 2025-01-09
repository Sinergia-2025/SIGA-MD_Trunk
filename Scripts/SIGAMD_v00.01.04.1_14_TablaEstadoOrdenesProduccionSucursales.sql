PRINT ''
PRINT '1. Nuevo Tabla EstadosOrdenesProduccionSucursales'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'EstadosOrdenesProduccionSucursales')
BEGIN
	CREATE TABLE EstadosOrdenesProduccionSucursales(
		IdEstado varchar(10) NOT NULL,
		IdSucursal int NOT NULL,
		IdDeposito int NULL,
		IdUbicacion int NULL,
	 CONSTRAINT [PK_EstadosOPSucursales] PRIMARY KEY CLUSTERED 
	(
		[IdEstado] ASC,
		[IdSucursal] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[EstadosOrdenesProduccionSucursales]  WITH CHECK ADD  CONSTRAINT [FK_EstadosOPSucursales_EstadosOrdenesProduccion] 
		FOREIGN KEY([IdEstado]) REFERENCES [dbo].[EstadosOrdenesProduccion] ([IdEstado])

	ALTER TABLE [dbo].[EstadosOrdenesProduccionSucursales] CHECK CONSTRAINT [FK_EstadosOPSucursales_EstadosOrdenesProduccion]

END
GO

