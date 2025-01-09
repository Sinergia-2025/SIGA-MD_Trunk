IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'ReservasTurismoProductosFacturacion')
BEGIN
	CREATE TABLE [dbo].[ReservasTurismoProductosFacturacion](
		[IdSucursal] [int] NOT NULL,
		[IdTipoReserva] [varchar](15) NOT NULL,
		[Letra] [varchar](1) NOT NULL,
		[CentroEmisor] [smallint] NOT NULL,
		[NumeroReserva] [bigint] NOT NULL,
		[IdProducto] [varchar](15) NOT NULL,
		[Orden] [int] NOT NULL,
		[Cantidad] [decimal](16, 4) NOT NULL,
		[Precio] [decimal](16, 4) NOT NULL,
		[AlicuotaIVA] [decimal](6, 2) NOT NULL,
		[ImporteTotal] [decimal](16, 4) NOT NULL,
		CONSTRAINT [PK_ReservasTurismoProductosFacturacion] PRIMARY KEY CLUSTERED 
		([IdSucursal] ASC, [IdTipoReserva] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroReserva] ASC, [IdProducto] ASC, [Orden] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

		ALTER TABLE [dbo].[ReservasTurismoProductosFacturacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservasTurismoProductosFacturacion_Productos] FOREIGN KEY([IdProducto])
		REFERENCES [dbo].[Productos] ([IdProducto])
		ALTER TABLE [dbo].[ReservasTurismoProductosFacturacion] CHECK CONSTRAINT [FK_ReservasTurismoProductosFacturacion_Productos]

		ALTER TABLE [dbo].[ReservasTurismoProductosFacturacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservasTurismoProductosFacturacion_ReservasTurismo] FOREIGN KEY([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
		REFERENCES [dbo].[ReservasTurismo] ([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
		ALTER TABLE [dbo].[ReservasTurismoProductosFacturacion] CHECK CONSTRAINT [FK_ReservasTurismoProductosFacturacion_ReservasTurismo]
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DELETE ReservasTurismoProductosFacturacion

DECLARE @idProductoGastronimia VARCHAR(MAX) = '1'
DECLARE @idProductoTransporte VARCHAR(MAX) = '2'
DECLARE @unTercio  DECIMAL(10, 9) = CONVERT(DECIMAL(10, 9), 1) / CONVERT(DECIMAL(10, 9),3)
DECLARE @dosTercio DECIMAL(10, 9) = CONVERT(DECIMAL(10, 9), 2) / CONVERT(DECIMAL(10, 9),3)

IF dbo.BaseConCUIT('30714374938') = 1
BEGIN
    INSERT INTO ReservasTurismoProductosFacturacion 
          (IdSucursal, IdTipoReserva, Letra, CentroEmisor, NumeroReserva,   IdProducto,   Orden,  Cantidad, Precio, AlicuotaIVA, ImporteTotal)
    SELECT IdSucursal, IdTipoReserva, Letra, CentroEmisor, NumeroReserva, P.IdProducto, P.Orden, 1 Cantidad,
           ISNULL(CONVERT(DECIMAL(10, 2), ROUND(Costo * P.Porc, 2)), 0) Precio, 
           P.Alicuota AlicuotaIVA, 
           ISNULL(CONVERT(DECIMAL(10, 2), ROUND(Costo * P.Porc, 2)), 0) ImporteTotal --, '', *
      FROM ReservasTurismo
     CROSS JOIN (SELECT --CONVERT(VARCHAR(MAX), CONVERT(INT, P.IdProducto) + 1000 ) IdProducto, 
                        IdProducto,
                        CONVERT(INT, P.IdProducto) Orden,
                        CASE WHEN P.IdProducto = @idProductoGastronimia THEN @unTercio ELSE @dosTercio END Porc,
                        Alicuota
                   FROM Productos P WHERE P.IdProducto IN (@idProductoGastronimia, @idProductoTransporte)) P
     ORDER BY IdSucursal, IdTipoReserva, Letra, CentroEmisor, NumeroReserva, IdProducto, Orden
END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Tabla CuentasCorrientes: Nuevo Campo IdCama'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CuentasCorrientes' AND COLUMN_NAME = 'IdCama')
BEGIN
    ALTER TABLE CuentasCorrientes ADD IdCama bigint NULL;
END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Tabla CuentasCorrientesPagos: Nuevo Campo IdCama'
PRINT ''
PRINT 'B1. Insertar Nuevo Campo: IdCama'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CuentasCorrientesPagos' AND COLUMN_NAME = 'IdCama')
BEGIN
    ALTER TABLE CuentasCorrientesPagos ADD IdCama bigint NULL;
END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '4. Tabla Ventas: Nuevos Campos'
BEGIN 
    PRINT ''
    PRINT '4.1. Tabla Ventas: Nuevo Campo IdCama'
    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'IdCama')
    BEGIN
        ALTER TABLE Ventas ADD IdCama bigint NULL;
        ALTER TABLE Ventas ADD CodigoCama VarChar(10) NULL;
        ALTER TABLE Ventas ADD IdNave smallint NULL;
        ALTER TABLE Ventas ADD NombreNave Varchar(30) NULL;
        ALTER TABLE Ventas ADD IdCategoriaCama int NULL;
        ALTER TABLE Ventas ADD NombreCategoriaCama Varchar(30) NULL;
    END
END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteFuncion('Turismo') = 1 AND dbo.ExisteFuncion('GenerarFacturasDeReservas') = 0
BEGIN
 PRINT ''
    PRINT '1. Menu Turismo: Agregar función'
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
        VALUES
            ('GenerarFacturasDeReservas', 'Generar Facturas de Reservas', 'Generar Facturas de Reservas', 'True', 'False', 'True', 'True'
            ,'Turismo', 25, 'Eniac.Win', 'GenerarFacturasDeReservas', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',1)
    PRINT ''
    PRINT '1.1. Menu Reservas: Agregar roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'GenerarFacturasDeReservas' FROM RolesFunciones WHERE IdFuncion = 'Turismo'

END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ReservasTurismoPasajeros' AND COLUMN_NAME = 'IdSucursalComprobanteFact')
BEGIN
	ALTER TABLE dbo.ReservasTurismoPasajeros ADD
		IdSucursalComprobanteFact int NULL,
		IdTipoComprobanteFact varchar(15) NULL,
		LetraComprobanteFact varchar(1) NULL,
		CentroEmisorComprobanteFact int NULL,
		NumeroComprobanteFact bigint NULL

	ALTER TABLE dbo.ReservasTurismoPasajeros ADD CONSTRAINT FK_ReservasTurismoPasajeros_Ventas_Fact FOREIGN KEY
		(IdTipoComprobanteFact,LetraComprobanteFact,CentroEmisorComprobanteFact,NumeroComprobanteFact,IdSucursalComprobanteFact)
		REFERENCES dbo.Ventas (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
		ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Parametros de Liquidacion por CtaCte SISEN.-'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 
            'CUENTACORRIENTECAMA' AS IdParametro, 
            'False' ValorParametro, 
            'Cargos' CategoriaParametro, 
            'CUENTACORRIENTECAMA' DescripcionParametro FROM Empresas) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId, '1 x Ancho (10 x 15 cm)', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF17.rdlc', 'True'
           ,'', 'False', 1, 'False', 'False'
           ,'True')
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ConcesionarioOperacionesTarjetas')
BEGIN
	CREATE TABLE [dbo].[ConcesionarioOperacionesTarjetas](
		[IdMarca] [int] NOT NULL,
		[AnioOperacion] [int] NOT NULL,
		[NumeroOperacion] [int] NOT NULL,
		[SecuenciaOperacion] [int] NOT NULL,
		[Orden] [int] NOT NULL,
		[IdTarjeta] [int] NOT NULL,
		[IdBanco] [int] NOT NULL,
		[Monto] [decimal](14, 4) NOT NULL,
		[Cuotas] [int] NULL,
		[NumeroCupon] [int] NULL,
		[NumeroLote] [int] NULL,
	 CONSTRAINT [PK_ConcesionarioOperacionesTarjetas] PRIMARY KEY CLUSTERED 
	(
		[IdMarca] ASC,
		[AnioOperacion] ASC,
		[NumeroOperacion] ASC,
		[SecuenciaOperacion] ASC,
		[Orden] ASC,
		[IdTarjeta] ASC,
		[IdBanco] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ConcesionarioOperacionesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesTarjetas_Bancos] FOREIGN KEY([IdBanco])
	REFERENCES [dbo].[Bancos] ([IdBanco])

	ALTER TABLE [dbo].[ConcesionarioOperacionesTarjetas] CHECK CONSTRAINT [FK_ConcesionarioOperacionesTarjetas_Bancos]

	ALTER TABLE [dbo].[ConcesionarioOperacionesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesTarjetas_ConcesionarioOperaciones] FOREIGN KEY([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])
	REFERENCES [dbo].[ConcesionarioOperaciones] ([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])

	ALTER TABLE [dbo].[ConcesionarioOperacionesTarjetas] CHECK CONSTRAINT [FK_ConcesionarioOperacionesTarjetas_ConcesionarioOperaciones]

	ALTER TABLE [dbo].[ConcesionarioOperacionesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesTarjetas_Tarjetas] FOREIGN KEY([IdTarjeta])
	REFERENCES [dbo].[Tarjetas] ([IdTarjeta])

	ALTER TABLE [dbo].[ConcesionarioOperacionesTarjetas] CHECK CONSTRAINT [FK_ConcesionarioOperacionesTarjetas_Tarjetas]

END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ConcesionarioOperaciones' AND COLUMN_NAME = 'ImportePesos')
BEGIN 
	ALTER TABLE dbo.ConcesionarioOperaciones ADD
		ImportePesos decimal(16, 2) NULL,
		ImporteTarjetas decimal(16, 2) NULL,
		ImporteCheques decimal(16, 2) NULL,
		ImporteTransferencia decimal(16, 2) NULL,
		FechaTransferencia datetime NULL,
		IdCuentaBancaria int NULL

	ALTER TABLE dbo.ConcesionarioOperaciones ADD CONSTRAINT FK_ConcesionarioOperaciones_CuentasBancarias
		FOREIGN KEY (IdCuentaBancaria)
		REFERENCES dbo.CuentasBancarias (IdCuentaBancaria)
		ON UPDATE  NO ACTION ON DELETE  NO ACTION 

END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	UPDATE ConcesionarioOperaciones
	   SET ImportePesos = 0
		 , ImporteTarjetas = 0
		 , ImporteCheques = 0
		 , ImporteTransferencia = 0;
	ALTER TABLE dbo.ConcesionarioOperaciones ALTER COLUMN ImportePesos decimal(16, 2) NOT NULL
	ALTER TABLE dbo.ConcesionarioOperaciones ALTER COLUMN ImporteTarjetas decimal(16, 2) NOT NULL
	ALTER TABLE dbo.ConcesionarioOperaciones ALTER COLUMN ImporteCheques decimal(16, 2) NOT NULL
	ALTER TABLE dbo.ConcesionarioOperaciones ALTER COLUMN ImporteTransferencia decimal(16, 2) NOT NULL

