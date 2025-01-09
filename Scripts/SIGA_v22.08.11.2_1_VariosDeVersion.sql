IF dbo.SoyHAR() = 0
BEGIN
	-- PARAMETROS.- --
	PRINT ''
	PRINT '1. Corregir Ortograf�a - ParametrosDelUsuario'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Par�metros del Sistema',
				Descripcion = 'Par�metros del Sistema'
		 WHERE Id = 'ParametrosDelUsuario'
	END
	PRINT ''
	PRINT '2. Corregir Ortograf�a - InfAuditoriaParametros'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Auditor�a de Par�metros',
				Descripcion = 'Auditor�a de Par�metros'
		 WHERE Id = 'InfAuditoriaParametros'
	END
	-- CRM.- --
	PRINT ''
	PRINT '3. Corregir Ortograf�a - CRMClientesGestion'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Gesti�n de Clientes',
				Descripcion = 'Gesti�n de Clientes'
		 WHERE Id = 'CRMClientesGestion'
	END
	PRINT ''
	PRINT '4. Corregir Ortograf�a - InfOrdenesReparacion'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Informe de Ordenes de Reparaci�n',
				Descripcion = 'Informe de Ordenes de Reparaci�n'
		 WHERE Id = 'InfOrdenesReparacion'
	END
	PRINT ''
	PRINT '5. Corregir Ortograf�a - CRMMetodosResolucionesABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM de Metodos Resoluci�n',
				Descripcion = 'ABM de Metodos Resoluci�n'
		 WHERE Id = 'CRMMetodosResolucionesABM'
	END
	-- PROCESOS.- --
	PRINT ''
	PRINT '6. Corregir Ortograf�a - ProductoCambiarCod'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Producto - Cambiar C�digo',
				Descripcion = 'Producto - Cambiar C�digo'
		 WHERE Id = 'ProductoCambiarCod'
	END
	PRINT ''
	PRINT '7. Corregir Ortograf�a - ProductoCopiarCod'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Producto - Copiar C�digo',
				Descripcion = 'Producto - Copiar C�digo'
		 WHERE Id = 'ProductoCopiarCod'
	END
	PRINT ''
	PRINT '8. Corregir Ortograf�a - ProductoUnificarCodigos'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Producto - Unificar C�digo',
				Descripcion = 'Producto - Unificar C�digo'
		 WHERE Id = 'ProductoUnificarCodigos'
	END
	-- ARCHIVOS.- --
	PRINT ''
	PRINT '9. Corregir Ortograf�a - Categorias'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Categor�as',
				Descripcion = 'Categor�as'
		 WHERE Id = 'Categorias'
	END
	PRINT ''
	PRINT '10. Corregir Ortograf�a - CategoriasProveedoresABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Categor�as Proveedores',
				Descripcion = 'Categor�as Proveedores'
		 WHERE Id = 'CategoriasProveedoresABM'
	END
	PRINT ''
	PRINT '11. Corregir Ortograf�a - ZonasGeograficas'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Zonas Geogr�ficas',
				Descripcion = 'Zonas Geogr�ficas'
		 WHERE Id = 'ZonasGeograficas'
	END
	-- PRODUCCION.- --
	PRINT ''
	PRINT '12. Corregir Ortograf�a - Produccion'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Producci�n',
				Descripcion = 'Producci�n'
		 WHERE Id = 'Produccion'
	END
	PRINT ''
	PRINT '13. Corregir Ortograf�a - MovimientosDeProduccion'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Movimientos de Producci�n',
				Descripcion = 'Movimientos de Producci�n'
		 WHERE Id = 'MovimientosDeProduccion'
	END
	PRINT ''
	PRINT '14. Corregir Ortograf�a - InfProduccion'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Informe de Producci�n',
				Descripcion = 'Informe de Producci�n'
		 WHERE Id = 'InfProduccion'
	END
	PRINT ''
	PRINT '15. Corregir Ortograf�a - InfProduccionTotalPorProducto'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Informe de Producci�n Total por Producto',
				Descripcion = 'Informe de Producci�n Total por Producto'
		 WHERE Id = 'InfProduccionTotalPorProducto'
	END
	PRINT ''
	PRINT '16. Corregir Ortograf�a - CalculoProduccion'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'C�lculo de Producci�n',
				Descripcion = 'C�lculo de Producci�n'
		 WHERE Id = 'CalculoProduccion'
	END
	PRINT ''
	PRINT '17. Corregir Ortograf�a - FormulasABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM de F�rmulas / Componentes de Productos',
				Descripcion = 'ABM de F�rmulas / Componentes de Productos'
		 WHERE Id = 'FormulasABM'
	END
	PRINT ''
	PRINT '18. Corregir Ortograf�a - ImportarFormulasExcel'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Importar F�rmulas desde Excel',
				Descripcion = 'Importar F�rmulas desde Excel'
		 WHERE Id = 'ImportarFormulasExcel'
	END
	-- BANCOS.- --
	PRINT ''
	PRINT '19. Corregir Ortograf�a - DepositosBancarios'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Dep�sitos Bancarios',
				Descripcion = 'Dep�sitos Bancarios'
		 WHERE Id = 'DepositosBancarios'
	END
	-- CAJA.- --
	PRINT ''
	PRINT '20. Corregir Ortograf�a - CajasNombresABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Administraci�n de Cajas',
				Descripcion = 'Administraci�n de Cajas'
		 WHERE Id = 'CajasNombresABM'
	END
	PRINT ''
	PRINT '21. Corregir Ortograf�a - SituacionCuponesABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM Situaci�n de Cupones',
				Descripcion = 'ABM Situaci�n de Cupones'
		 WHERE Id = 'SituacionCuponesABM'
	END
	-- CUENTAS CORRIENTES.- --
	PRINT ''
	PRINT '22. Corregir Ortograf�a - ConsultaNumeracionCtaCte'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Consulta Numeraci�n',
				Descripcion = 'Consulta Numeraci�n'
		 WHERE Id = 'ConsultaNumeracionCtaCte'
	END
	PRINT ''
	PRINT '23. Corregir Ortograf�a - ModificarNumeracionCtaCte'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Modificar Numeraci�n de C.C. Cliente',
				Descripcion = 'Modificar Numeraci�n de C.C. Cliente'
		 WHERE Id = 'ModificarNumeracionCtaCte'
	END
	PRINT ''
	PRINT '24. Corregir Ortograf�a - AntiguedadesSaldosConfigABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM de Rangos Antig�edad de Saldo',
				Descripcion = 'ABM de Rangos Antig�edad de Saldo'
		 WHERE Id = 'AntiguedadesSaldosConfigABM'
	END
	-- AFIP.- --
	PRINT ''
	PRINT '25. Corregir Ortograf�a - PosicionDeIVA'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'Posici�n de IVA',
				Descripcion = 'Posici�n de IVA'
		 WHERE Id = 'PosicionDeIVA'
	END
	PRINT ''
	PRINT '26. Corregir Ortograf�a - EscalasRetGananciasABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM Escalas Retenci�n Ganancias',
				Descripcion = 'ABM Escalas Retenci�n Ganancias'
		 WHERE Id = 'EscalasRetGananciasABM'
	END
	PRINT ''
	PRINT '27. Corregir Ortograf�a - CategoriasFiscalesABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM de Categor�as Fiscales',
				Descripcion = 'ABM de Categor�as Fiscales'
		 WHERE Id = 'CategoriasFiscalesABM'
	END
	-- PRODUCCION.- --
	PRINT ''
	PRINT '28. Corregir Ortograf�a - ProduccionProcesosABM'
	BEGIN
		UPDATE Funciones 
			SET Nombre = 'ABM de Procesos de Producci�n',
				Descripcion = 'ABM de Procesos de Producci�n'
		 WHERE Id = 'ProduccionProcesosABM'
	END
END
GO
------------------------------------------------------------------------------
IF dbo.ExisteFuncion('ModificarRecibosAClientes') = 0 AND dbo.ExisteFuncion('CuentasCorrientes') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ModificarRecibosAClientes', 'Modificar Recibo de Cliente', 'Modificar Recibo de Cliente', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 70, 'Eniac.Win', 'ConsultarRecibosAClientes', NULL, 'MODIFICAR'
        ,'True', 'S', 'N', 'N', 'N','True')
END
IF NOT EXISTS (SELECT * FROM RolesFunciones WHERE IdFuncion = 'ModificarRecibosAClientes')
BEGIN
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ModificarRecibosAClientes' FROM RolesFunciones WHERE IdFuncion = 'RecibosNuevos'
END
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'VehiculosClientes')
BEGIN
    CREATE TABLE [dbo].[VehiculosClientes](
	    [PatenteVehiculo] [varchar](8) NOT NULL,
	    [IdCliente] [bigint] NOT NULL,
     CONSTRAINT [PK_VehiculosClientes] PRIMARY KEY CLUSTERED ([PatenteVehiculo] ASC,[IdCliente] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

    ALTER TABLE [dbo].[VehiculosClientes]  WITH CHECK ADD  CONSTRAINT [FK_VehiculosClientes_Clientes] FOREIGN KEY([IdCliente])
    REFERENCES [dbo].[Clientes] ([IdCliente])
    ALTER TABLE [dbo].[VehiculosClientes] CHECK CONSTRAINT [FK_VehiculosClientes_Clientes]

    ALTER TABLE [dbo].[VehiculosClientes]  WITH CHECK ADD  CONSTRAINT [FK_VehiculosClientes_Vehiculos] FOREIGN KEY([PatenteVehiculo])
    REFERENCES [dbo].[Vehiculos] ([PatenteVehiculo])
    ALTER TABLE [dbo].[VehiculosClientes] CHECK CONSTRAINT [FK_VehiculosClientes_Vehiculos]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Vehiculos' AND COLUMN_NAME = 'IdCliente')
BEGIN
    DELETE VehiculosClientes;
    INSERT INTO VehiculosClientes (PatenteVehiculo, IdCliente)
    SELECT PatenteVehiculo, IdCliente FROM Vehiculos WHERE IdCliente IS NOT NULL;
END


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Vehiculos_Clientes')
    ALTER TABLE dbo.Vehiculos DROP CONSTRAINT FK_Vehiculos_Clientes
GO
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Vehiculos' AND COLUMN_NAME = 'IdCliente')
    ALTER TABLE dbo.Vehiculos DROP COLUMN IdCliente
GO
------------------------------------------------------------------------------
DECLARE @id INT = (SELECT IdBuscador FROM Buscadores WHERE Titulo = 'Vehiculos')
DELETE BuscadoresCampos
 WHERE IdBuscador = @id
   AND IdBuscadorNombreCampo = 'IdCliente'
GO
------------------------------------------------------------------------------
IF dbo.ExisteFuncion('EstadoSituacionCrediticia') = 0 AND dbo.ExisteFuncion('CuentasCorrientes') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('EstadoSituacionCrediticia', 'Estado de Situaci�n Crediticia', 'Estado de Situaci�n Crediticia', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 65, 'Eniac.Win', 'EstadoSituacionCrediticia', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EstadoSituacionCrediticia' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------
UPDATE CC
   SET IdClienteCtaCte = ISNULL(C.IdCliente, C.IdClienteCtaCte)
  FROM CuentasCorrientes CC
 INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente
 WHERE CC.IdClienteCtaCte = 0
 ------------------------------------------------------------------------------
 DELETE [BuscadoresCampos] WHERE [IdBuscador] = 50
DELETE [Buscadores] WHERE [IdBuscador] = 50

PRINT ''
PRINT '6. Buscadores - Comprobantes de Venta Pendientes.'
INSERT INTO [dbo].[Buscadores]
           ([IdBuscador], [Titulo], [AnchoAyuda], [IniciaConFocoEn], [ColumaBusquedaInicial])
     VALUES
           (50, 'Cuentas Bancarias', 780, 'Grilla', '')
GO


INSERT INTO [dbo].[BuscadoresCampos]
           ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila])
     VALUES
   (50, 'NombreCuenta',              1, 'Nombre',           16, 180, '', NULL, NULL, NULL),
   (50, 'NombreCuentaBancariaClase', 2, 'Clase',            16, 100, '', NULL, NULL, NULL),
   (50, 'NombreMoneda',              3, 'Moneda',           16,  70, '', NULL, NULL, NULL),
   (50, 'NombreBanco',               4, 'Nombre Banco',     16, 130, '', NULL, NULL, NULL),
   (50, 'NombreLocalidad',           5, 'Localidad',        16, 110, '', NULL, NULL, NULL),
   (50, 'CodigoBancario',            6, 'Codigo',           16, 130, '', NULL, NULL, NULL)
GO
------------------------------------------------------------------------------
UPDATE PP
   SET CantPendiente = PE.CantPendiente
     , CantEnProceso = PE.CantEnProceso
     , CantEntregada = PE.CantEntregada
     , CantAnulada   = PE.CantAnulada  
  FROM (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden
             , SUM(CASE WHEN  EP.IdTipoEstado = 'PENDIENTE' THEN PE.CantEstado ELSE 0 END) CantPendiente
             , SUM(CASE WHEN  EP.IdTipoEstado = 'ENPROCESO' THEN PE.CantEstado ELSE 0 END) CantEnProceso
             , SUM(CASE WHEN  EP.IdTipoEstado = 'ENTREGADO' THEN PE.CantEstado ELSE 0 END) CantEntregada
             , SUM(CASE WHEN (EP.IdTipoEstado = 'ANULADO' AND PE.AnulacionPorModificacion = 0)
                          OR  EP.IdTipoEstado = 'RECHAZADO' THEN PE.CantEstado ELSE 0 END) CantAnulada
          FROM PedidosEstados PE
         INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido
         GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden) PE
 INNER JOIN PedidosProductos PP ON PP.IdSucursal = PE.IdSucursal
                               AND PP.IdTipoComprobante = PE.IdTipoComprobante
                               AND PP.Letra = PE.Letra
                               AND PP.CentroEmisor = PE.CentroEmisor
                               AND PP.NumeroPedido = PE.NumeroPedido
                               AND PP.IdProducto = PE.IdProducto
                               AND PP.Orden = PE.Orden
GO
------------------------------------------------------------------------------
UPDATE Funciones
   SET Parametros = 'ModoFechas=PORVENCIMIENTO;ReportesCtaCte=CTACTE'
 WHERE Id = 'EnvioMasivoDeCompVenc'
   AND Parametros LIKE '%ReportesCtaCte=CTACTEDET'
UPDATE Funciones
   SET Parametros = 'ReportesCtaCte=CTACTE'
 WHERE Id = 'EnvioMasivoDeComprobantes'
   AND Parametros LIKE '%ReportesCtaCte=CTACTEDET'
GO
------------------------------------------------------------------------------
/****** Object:  Table [dbo].[ConcesionarioOperaciones]    Script Date: 10/8/2022 10:06:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ConcesionarioOperaciones')
BEGIN
	CREATE TABLE [dbo].[ConcesionarioOperaciones](
		[IdMarca] [int] NOT NULL,
		[AnioOperacion] [int] NOT NULL,
		[NumeroOperacion] [int] NOT NULL,
		[SecuenciaOperacion] [int] NOT NULL,
		[FechaOperacion] [datetime] NOT NULL,
		[CotizacionDolar] [decimal](10, 4) NOT NULL,
		[IdCliente] [bigint] NOT NULL,
		[TipoOperacion] [varchar](30) NOT NULL,
		[IdProductoCeroKilometro] [varchar](15) NULL,
		[CantidadCeroKilometro] [decimal](16, 4) NULL,
		[PrecioCeroKilometro] [decimal](16, 4) NULL,
		[ImporteCeroKilometro] [decimal](16, 4) NULL,
		[IdTipoUnidadCeroKilometro] [int] NULL,
		[IdSubTipoUnidadCeroKilometro] [int] NULL,
		[CaracteristicaAdicionalCeroKilometro] [varchar](150) NULL,
		[LargoCeroKilometro] [varchar](50) NULL,
		[AltoCargaCeroKilometro] [varchar](50) NULL,
		[AltoPuertaLateralCeroKilometro] [varchar](50) NULL,
		[ColorCarroceriaCeroKilometro] [varchar](50) NULL,
		[ColorZocaloCeroKilometro] [varchar](50) NULL,
		[ColorBaseCeroKilometro] [varchar](50) NULL,
		[PuertaTraseraCeroKilometro] [varchar](50) NULL,
		[ParanteCeroKilometro] [varchar](50) NULL,
		[PisoCeroKilometro] [varchar](50) NULL,
		[MarcoCeroKilometro] [varchar](50) NULL,
		[HerrajeCeroKilometro] [varchar](50) NULL,
		[OtrasObservacionesCeroKilometro] [varchar](1000) NULL,
		[ImporteTotalAdicionales] [decimal](16, 4) NOT NULL,
		[ImporteTotalCaracteristicas] [decimal](16, 4) NOT NULL,
		[ImporteTotal] [decimal](16, 4) NOT NULL,
	 CONSTRAINT [PK_ConcesionarioOperaciones] PRIMARY KEY CLUSTERED 
	(
		[IdMarca] ASC,
		[AnioOperacion] ASC,
		[NumeroOperacion] ASC,
		[SecuenciaOperacion] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperaciones_Clientes')
ALTER TABLE [dbo].[ConcesionarioOperaciones]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperaciones_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ConcesionarioOperaciones] CHECK CONSTRAINT [FK_ConcesionarioOperaciones_Clientes]
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperaciones_Marcas')
ALTER TABLE [dbo].[ConcesionarioOperaciones]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperaciones_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO
ALTER TABLE [dbo].[ConcesionarioOperaciones] CHECK CONSTRAINT [FK_ConcesionarioOperaciones_Marcas]
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperaciones_Productos')
ALTER TABLE [dbo].[ConcesionarioOperaciones]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperaciones_Productos] FOREIGN KEY([IdProductoCeroKilometro])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ConcesionarioOperaciones] CHECK CONSTRAINT [FK_ConcesionarioOperaciones_Productos]
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperaciones_ConcesionarioTiposUnidades')
ALTER TABLE dbo.ConcesionarioOperaciones ADD CONSTRAINT	FK_ConcesionarioOperaciones_ConcesionarioTiposUnidades 
    FOREIGN KEY (IdTipoUnidadCeroKilometro)
    REFERENCES dbo.ConcesionarioTiposUnidades (IdTipoUnidad) ON UPDATE  NO ACTION ON DELETE NO ACTION 
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperaciones_ConcesionarioSubTiposUnidades')
ALTER TABLE dbo.ConcesionarioOperaciones ADD CONSTRAINT FK_ConcesionarioOperaciones_ConcesionarioSubTiposUnidades
    FOREIGN KEY (IdSubTipoUnidadCeroKilometro)
    REFERENCES dbo.ConcesionarioSubTiposUnidades (IdSubTipoUnidad) ON UPDATE  NO ACTION ON DELETE  NO ACTION 	
GO
------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ConcesionarioOperacionesAdicionales')
CREATE TABLE [dbo].[ConcesionarioOperacionesAdicionales](
	[IdMarca] [int] NOT NULL,
	[AnioOperacion] [int] NOT NULL,
	[NumeroOperacion] [int] NOT NULL,
	[SecuenciaOperacion] [int] NOT NULL,
	[IdAdicional] [int] NOT NULL,
	[DetalleAdicional] [varchar](150) NOT NULL,
	[PrecioAdicional] [decimal](14, 2) NOT NULL,
	CONSTRAINT [PK_ConcesionarioOperacionesAdicionales] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC,
	[AnioOperacion] ASC,
	[NumeroOperacion] ASC,
	[SecuenciaOperacion] ASC,
	[IdAdicional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperacionesAdicionales_ConcesionarioOperaciones')
ALTER TABLE [dbo].[ConcesionarioOperacionesAdicionales]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesAdicionales_ConcesionarioOperaciones] FOREIGN KEY([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])
REFERENCES [dbo].[ConcesionarioOperaciones] ([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperacionesAdicionales_ConcesionarioOperaciones')
ALTER TABLE [dbo].[ConcesionarioOperacionesAdicionales] CHECK CONSTRAINT [FK_ConcesionarioOperacionesAdicionales_ConcesionarioOperaciones]
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperacionesAdicionales_ConcesionariosAdicionales')
ALTER TABLE [dbo].[ConcesionarioOperacionesAdicionales]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesAdicionales_ConcesionariosAdicionales] FOREIGN KEY([IdAdicional])
REFERENCES [dbo].[ConcesionariosAdicionales] ([IdAdicional])
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ConcesionarioOperacionesAdicionales_ConcesionariosAdicionales')
ALTER TABLE [dbo].[ConcesionarioOperacionesAdicionales] CHECK CONSTRAINT [FK_ConcesionarioOperacionesAdicionales_ConcesionariosAdicionales]
GO