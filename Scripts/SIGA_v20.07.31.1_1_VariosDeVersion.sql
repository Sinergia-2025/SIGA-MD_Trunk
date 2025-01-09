
PRINT ''
PRINT '0. Tabla TiposComprobantes: ComprobantesAsociados al Máximo de caracteres.'
PRINT '   Se Normaliza porque en algunas bases el campo está bien y en otros mal.'
GO
ALTER TABLE dbo.TiposComprobantes  ALTER COLUMN ComprobantesAsociados varchar(MAX) NULL
GO

PRINT ''
PRINT '1. Parametros: Inicializar parámetros'
DECLARE @idParametro VARCHAR(MAX)
DECLARE @descripcionParametro VARCHAR(MAX)
DECLARE @valorParametro VARCHAR(MAX)

SET @idParametro = 'MODIFICARPRECIOPORDEBAJOPL'
SET @descripcionParametro = 'Facturacion: Modificar precio por debajo de Precio de Lista'
SET @valorParametro = 'PERMITIR'

PRINT ''
PRINT '1.1. Parametros: Modificar precio por debajo de Precio de Listas = PERMITIR'
MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

SET @idParametro = 'MODIFICARPRECIOPORARRIBAPL'
SET @descripcionParametro = 'Facturacion: Modificar precio por arriba de Precio de Lista'
SET @valorParametro = 'PERMITIR'

PRINT ''
PRINT '1.2. Parametros: Modificar precio por arriba de Precio de Lista = PERMITIR'
MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

SET @idParametro = 'PORCENTAJEPORDEBAJOPL'
SET @descripcionParametro = 'Porcentaje permitido por debajo de Precio de Lista'
SET @valorParametro = '100'

PRINT ''
PRINT '1.3. Parametros: Modificar precio por arriba de Precio de Lista = PERMITIR'
MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

	SET @idParametro = 'PORCENTAJEPORARRIBAPL'
SET @descripcionParametro = 'Modificar precio por arriba de Precio de Lista'
SET @valorParametro = '100000'

PRINT ''
PRINT '1.4. Parametros: Modificar precio por arriba de Precio de Lista = PERMITIR'
MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '2. Nueva Función: Importar Productos desde Plantillas Excel para Comparar'
GO
IF dbo.ExisteFuncion('Precios') = 'True'
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
		('ImportarProdPlantillaExcelPC', 'Importar Productos desde Plantillas Excel para Comparar', 'Importar Productos desde Plantillas Excel para Comparar', 'True', 'False', 'True', 'True'
		,'Precios', 294, 'Eniac.Win', 'ImportarProductosPlantillaExcel', NULL, 'COMPARARPROD'
		,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarProdPlantillaExcelPC' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END 
GO


PRINT ''
PRINT '3. Nueva Tabla: ProveedoresComparar'
CREATE TABLE ProveedoresComparar(
	IdProveedor BIGINT NOT NULL,
	IdPlantilla INT NOT NULL,
	FechaActualizacion DATETIME NOT NULL
	PRIMARY KEY (IdProveedor)
)
GO

PRINT ''
PRINT '3.1. FK ProveedoresComparar'
ALTER TABLE ProveedoresComparar
	ADD CONSTRAINT FK_ProveedoresComparar_Proveedores
	FOREIGN KEY (IdProveedor) REFERENCES Proveedores (IdProveedor)
GO
ALTER TABLE ProveedoresComparar
	ADD CONSTRAINT FK_ProveedoresComparar_Plantillas
	FOREIGN KEY (IdPlantilla) REFERENCES Plantillas (IdPlantilla)
GO

PRINT ''
PRINT '4. Nueva Tabla: ProveedoresProductosComparar'
CREATE TABLE ProveedoresProductosComparar (
	IdProducto VARCHAR(15) NOT NULL,
	Linea INT NOT NULL,
	IdProveedor BIGINT NOT NULL,
	CodigoProductoProveedor VARCHAR(30) NULL,
	PrecioCompraAnterior DECIMAL(14,4) NULL,
	PorcVarCompra DECIMAL(14,4) NULL,
	PrecioCompra DECIMAL(14,4) NULL,
	DescRec1 DECIMAL(5,2) NULL,
	DescRec2 DECIMAL(5,2) NULL,
	DescRec3 DECIMAL(5,2) NULL,
	DescRec4 DECIMAL(5,2) NULL,
	PrecioCostoAnterior DECIMAL(14,4) NULL,
	PorcVarCosto DECIMAL(14,4) NULL,
	PrecioCosto DECIMAL(14,4) NULL
		
	PRIMARY KEY (IdProducto, IdProveedor, Linea)
)
GO

PRINT ''
PRINT '4.1. FK_ProveedoresProductosComparar_Productos'
ALTER TABLE ProveedoresProductosComparar
	ADD CONSTRAINT FK_ProveedoresProductosComparar_Productos
	FOREIGN KEY (IdProducto) REFERENCES Productos (IdProducto)
GO

PRINT ''
PRINT '4.2. FK_ProveedoresProductosComparar_ProveedoresComparar'
ALTER TABLE ProveedoresProductosComparar
	ADD CONSTRAINT FK_ProveedoresProductosComparar_ProveedoresComparar
	FOREIGN KEY (IdProveedor) REFERENCES ProveedoresComparar (IdProveedor)
GO

PRINT ''
PRINT '5. Nueva Función: Comparar Productos Plantillas Excel'
GO
IF dbo.ExisteFuncion('Precios') = 'True'
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
		('CompararProdPlantillaExcel','Comparar Productos Plantillas Excel','Comparar Productos Plantillas Excel', 'True', 'False', 'True', 'True'
		,'Precios', 295, 'Eniac.Win', 'CompararProdPlantillaExcel', NULL, NULL
		,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CompararProdPlantillaExcel' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END 
GO


PRINT '';
PRINT '6. Nueva función= "Facturacion Rapida: Oculta Desc/Recargo General"';
IF dbo.ExisteFuncion('Fact-RapidOcultaDescRecGral') = 0 AND dbo.ExisteFuncion('FacturacionRapida') = 1
BEGIN
    PRINT '6.1. Crea Función'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion
		 ,EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo)
    VALUES
        ('Fact-RapidOcultaDescRecGral', 'Facturacion Rapida: Oculta el Desc/Recargo General', 'Facturacion Rapida: Oculta el Desc/Recargo General','False', 'False', 'True', 'True'
        ,'FacturacionRapida', 999, 'Eniac.Win', 'Fact-RapidOcultaDescRecGral', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL);
   -- PRINT '2.2. Crea RolesFunciones'
    --INSERT INTO RolesFunciones (IdRol,IdFuncion)
    --SELECT IdRol, 'Fact-RapidModifDescRecGral' FROM RolesFunciones WHERE IdFuncion = 'FacturacionRapida'
END


/****** Object:  Table [dbo].[FuncionesFiltros]    Script Date: 14/07/2020 20:45:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FuncionesFiltros](
	[IdFuncion] [varchar](30) NOT NULL,
	[IdFiltro] [int] NOT NULL,
	[IdSucursal] [int] NULL,
	[IdUsuario] [varchar](10) NULL,
	[NombreFiltro] [varchar](30) NULL,
 CONSTRAINT [PK_FuncionesFiltros] PRIMARY KEY CLUSTERED 
(
	[IdFuncion] ASC,
	[IdFiltro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FuncionesFiltros]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltros_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[FuncionesFiltros] CHECK CONSTRAINT [FK_FuncionesFiltros_Funciones]
GO

ALTER TABLE [dbo].[FuncionesFiltros]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltros_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[FuncionesFiltros] CHECK CONSTRAINT [FK_FuncionesFiltros_Sucursales]
GO

ALTER TABLE [dbo].[FuncionesFiltros]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltros_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[FuncionesFiltros] CHECK CONSTRAINT [FK_FuncionesFiltros_Usuarios]
GO


/****** Object:  Table [dbo].[FuncionesFiltrosControles]    Script Date: 14/07/2020 20:46:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FuncionesFiltrosControles](
	[IdFuncion] [varchar](30) NOT NULL,
	[IdFiltro] [int] NOT NULL,
	[NombreControl] [varchar](100) NOT NULL,
	[ValorControl] [varchar](max) NULL,
 CONSTRAINT [PK_FuncionesFiltrosControles] PRIMARY KEY CLUSTERED 
(
	[IdFuncion] ASC,
	[IdFiltro] ASC,
	[NombreControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FuncionesFiltrosControles]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosControles_FuncionesFiltrosControles] FOREIGN KEY([IdFuncion], [IdFiltro])
REFERENCES [dbo].[FuncionesFiltros] ([IdFuncion], [IdFiltro])
GO

ALTER TABLE [dbo].[FuncionesFiltrosControles] CHECK CONSTRAINT [FK_FuncionesFiltrosControles_FuncionesFiltrosControles]
GO


/****** Object:  Table [dbo].[FuncionesFiltrosSucursales]    Script Date: 14/07/2020 20:46:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FuncionesFiltrosSucursales](
	[IdFuncion] [varchar](30) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdFiltro] [int] NOT NULL,
 CONSTRAINT [PK_FuncionesFiltrosSucursales] PRIMARY KEY CLUSTERED 
(
	[IdFuncion] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FuncionesFiltrosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosSucursales_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[FuncionesFiltrosSucursales] CHECK CONSTRAINT [FK_FuncionesFiltrosSucursales_Funciones]
GO

ALTER TABLE [dbo].[FuncionesFiltrosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosSucursales_FuncionesFiltros] FOREIGN KEY([IdFuncion], [IdFiltro])
REFERENCES [dbo].[FuncionesFiltros] ([IdFuncion], [IdFiltro])
GO

ALTER TABLE [dbo].[FuncionesFiltrosSucursales] CHECK CONSTRAINT [FK_FuncionesFiltrosSucursales_FuncionesFiltros]
GO

ALTER TABLE [dbo].[FuncionesFiltrosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosSucursales_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[FuncionesFiltrosSucursales] CHECK CONSTRAINT [FK_FuncionesFiltrosSucursales_Sucursales]
GO


/****** Object:  Table [dbo].[FuncionesFiltrosUsuarios]    Script Date: 14/07/2020 20:46:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FuncionesFiltrosUsuarios](
	[IdFuncion] [varchar](30) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdFiltro] [int] NOT NULL,
 CONSTRAINT [PK_FuncionesFiltrosUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdFuncion] ASC,
	[IdUsuario] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosUsuarios_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios] CHECK CONSTRAINT [FK_FuncionesFiltrosUsuarios_Funciones]
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosUsuarios_FuncionesFiltros] FOREIGN KEY([IdFuncion], [IdFiltro])
REFERENCES [dbo].[FuncionesFiltros] ([IdFuncion], [IdFiltro])
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios] CHECK CONSTRAINT [FK_FuncionesFiltrosUsuarios_FuncionesFiltros]
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosUsuarios_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios] CHECK CONSTRAINT [FK_FuncionesFiltrosUsuarios_Sucursales]
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_FuncionesFiltrosUsuarios_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[FuncionesFiltrosUsuarios] CHECK CONSTRAINT [FK_FuncionesFiltrosUsuarios_Usuarios]
GO


PRINT ''
PRINT '7. Nuevo Parámetro en Cargos: Permitir generar liquidación sin clientes'
DECLARE @idParametro VARCHAR(MAX) = 'CARGOSPERMITEGENERARLIQUIDACIONSINCLIENTES'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Cargos: Permitir generar liquidación sin clientes'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


SET QUOTED_IDENTIFIER OFF


UPDATE TiposComprobantes 
   SET tipo = 'CTACTEPROV' 
 where IdTipoComprobante IN ('ANTICIPOPRV','ANTICIPOPRVPROV','ANTICIPOPRUNICO')
GO


UPDATE TiposComprobantes SET ComprobantesAsociados = '' 
--SELECT IdTipoComprobante, ComprobantesAsociados FROM TiposComprobantes
where IdTipoComprobante = 'PAGO' or IdTipoComprobante = 'MINUTAPRV' or IdTipoComprobante = 'PAGOPROV' or IdTipoComprobante = 'MINUTAPRVPROV'

															 or IdTipoComprobante = 'PAGOUNICO' or IdTipoComprobante = 'MINUTAPRUNICA'
GO


UPDATE TiposComprobantes
   SET ComprobantesAsociados = (select STUFF(
(SELECT CAST(',' AS varchar(MAX)) + "'" + IdTipoComprobante + "'"
FROM TiposComprobantes
 where (tipo = 'CTACTEPROV' or tipo = 'COMPRAS') and GrabaLibro = 1 and EsRecibo = 0
ORDER BY IdTipoComprobante
FOR XML PATH('')
), 1, 1, '') as CadenaCodigos)                   
 WHERE IdTipoComprobante IN ('PAGO','MINUTAPRV')
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = (select STUFF(
(SELECT CAST(',' AS varchar(MAX)) + "'" + IdTipoComprobante + "'"
FROM TiposComprobantes
 where (tipo = 'CTACTEPROV' or tipo = 'COMPRAS') and GrabaLibro = 0 and EsRecibo = 0
ORDER BY IdTipoComprobante
FOR XML PATH('')
), 1, 1, '') as CadenaCodigos)       
 WHERE IdTipoComprobante IN ('PAGOPROV','MINUTAPRVPROV')
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados =   (select STUFF(
(SELECT CAST(',' AS varchar(MAX)) + "'" + IdTipoComprobante + "'"
FROM TiposComprobantes
 where (tipo = 'CTACTEPROV' or tipo = 'COMPRAS') and EsRecibo = 0
ORDER BY IdTipoComprobante
FOR XML PATH('')
), 1, 1, '') as CadenaCodigos)                 
 WHERE IdTipoComprobante IN ('PAGOUNICO','MINUTAPRUNICA')
GO

PRINT ''
PRINT '8. Nueva Función: ExportacionLibIvaDigVentas'
GO
IF dbo.ExisteFuncion('AFIP') = 'True'
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
		('ExportacionLibIvaDigVentas', 'Exportación para Libro IVA Digital Ventas', 'Exportación para Libro IVA Digital Ventas', 'True', 'False', 'True', 'True'
		,'AFIP', 15, 'Eniac.Win', 'ExportacionLibIvaDigVentas', NULL, NULL
		,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ExportacionLibIvaDigVentas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	PRINT ''
	PRINT '9. Nueva Función: ExportacionLibIvaDigCompras'
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
		('ExportacionLibIvaDigCompras', 'Exportación para Libro IVA Digital Compras', 'Exportación para Libro IVA Digital Compras', 'True', 'False', 'True', 'True'
		,'AFIP', 14, 'Eniac.Win', 'ExportacionLibIvaDigCompras', NULL, NULL
		,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ExportacionLibIvaDigCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END 
GO



PRINT ''
PRINT '10. Cambio de Tipo de Dato en las columnas decimal de la tabla Cajas'
PRINT ''
PRINT '10.1 PesosSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN PesosSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.2 PesosSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN PesosSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.3 DolaresSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN DolaresSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.4 DolaresSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN DolaresSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.5 EurosSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN EurosSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.6 EurosSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN EurosSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.7 ChequesSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN ChequesSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.8 ChequesSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN ChequesSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.9 TarjetasSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN TarjetasSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.10 TarjetasSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN TarjetasSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.11 TicketsSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN TicketsSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.12 TicketsSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN TicketsSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.13 PesosSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN PesosSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.14 DolaresSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN DolaresSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.15 ChequesSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN ChequesSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.16 TarjetasSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN TarjetasSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.17 TicketsSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN TicketsSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.18 BancosSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN BancosSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.19 BancosSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN BancosSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.20 BancosSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN BancosSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.21 RetencionesSaldoInicial DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN RetencionesSaldoInicial DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.22 RetencionesSaldoFinal DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN RetencionesSaldoFinal DECIMAL(16,2) NOT NULL
GO

PRINT ''
PRINT '10.23 RetencionesSaldoFinalDigit DECIMAL(16,2)'
ALTER TABLE Cajas 
	ALTER COLUMN RetencionesSaldoFinalDigit DECIMAL(16,2) NOT NULL
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[CtaCtePorcDescRecSaldo]
(
	@idCategoria int,				-- Categoría del cliente
	@fechaComprobante datetime,		-- Fecha de emisión del comprobante
	@fechaVencimiento datetime,		-- Fecha de vencimiento del comprobante
	@fechaRecibo datetime,			-- Fecha Recibo
	@importeTotal decimal,          -- Importe del comprobante
	@saldo decimal                  -- Saldo del comprobante
)
	RETURNS decimal(12, 2)
AS
BEGIN
    DECLARE @interes decimal(10,2) = 0
    --VARIABLES
    DECLARE @idInteres int = (SELECT MAX(IdInteres) FROM Categorias WHERE IdCategoria = @idCategoria)
    DECLARE @interesSoloPrimerPago bit
    SELECT @interesSoloPrimerPago = ValorParametro FROM Parametros WHERE IdParametro = 'INTERESESCALCULOCOMPLETOPRIMERPAGO'

    DECLARE @interesAdicional decimal(7,2) = ISNULL((SELECT AdicionalProporcinalDias FROM Intereses WHERE IdInteres = @idInteres), 0)

    IF @saldo > 0 AND CONVERT(DATE, @fechaComprobante) <> CONVERT(DATE, @fechaRecibo) AND (Not @interesSoloPrimerPago = 1 Or @importeTotal = @saldo)
    BEGIN
        DECLARE @tipoMetodo nvarchar(30)
		SELECT @tipoMetodo = MetodoParaDeterminarRango FROM Intereses WHERE IdInteres = @idInteres

		--Para los casos de DIAMES y DIAMESVENCIMIENTO tengo una lógica
        IF @tipoMetodo = 'DIAMES' OR @tipoMetodo = 'DIAMESVENCIMIENTO'
        BEGIN
			--Si el método es DIAMESVENCIMIENTO tomo la fecha de vencimiento como valor de referencia
			IF @tipoMetodo = 'DIAMESVENCIMIENTO'
				SET @fechaComprobante = @fechaVencimiento
            DECLARE @diaUltimoInteres datetime
            SET @diaUltimoInteres = ISNULL((SELECT TOP 1 MAX(DateAdd(yyyy, YEAR(@fechaComprobante) - 1900,DateAdd(m,  MONTH(@fechaComprobante) - 1, DiasHasta - 1))) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC),
                                           @fechaComprobante)
            IF @diaUltimoInteres < @fechaRecibo
            BEGIN
                DECLARE @diasTranscurridos int = DATEDIFF(D, @diaUltimoInteres, @fechaRecibo)
                SET @interes = ISNULL((SELECT TOP 1 MAX(Interes) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC), 0) +
                               (@interesAdicional * @diasTranscurridos / 30)
            END
            ELSE
            BEGIN
                SET @interes = (SELECT Interes FROM InteresesDias WHERE IdInteres = @idInteres AND DiasDesde <= DAY(@fechaRecibo) AND DiasHasta >= DAY(@fechaRecibo))
            END
        END
		--Para los casos de DIASCORRIDOSEMISION y DIASCORRIDOSVENCIMIENTO tengo otra lógica
        ELSE
        BEGIN
			--Si el método es DIASCORRIDOSVENCIMIENTO tomo la fecha de vencimiento como valor de referencia
            IF @tipoMetodo = 'DIASCORRIDOSVENCIMIENTO'
                SET @fechaComprobante = @fechaVencimiento
            SET @interes = (SELECT Interes FROM InteresesDias WHERE IdInteres = @idInteres AND DATEADD(d, DiasDesde, @fechaComprobante) <= @fechaRecibo AND DATEADD(d, DiasHasta + 1, @fechaComprobante) > @fechaRecibo)
            
            IF @interes IS NULL
            BEGIN
                SET @diaUltimoInteres = ISNULL((SELECT TOP 1 DATEADD(D, DiasHasta, @fechaComprobante) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC),
                                               @fechaComprobante)
                IF @diaUltimoInteres < @fechaRecibo
                BEGIN
                    SET @diasTranscurridos = DATEDIFF(D, @diaUltimoInteres, @fechaRecibo)
                    SET @interes = ISNULL((SELECT TOP 1 MAX(Interes) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC), 0) +
                                   (@interesAdicional * @diasTranscurridos / 30)
                END
            END
        END
    END
    -- Return the result of the function
    RETURN ISNULL(@interes, 0)
END

