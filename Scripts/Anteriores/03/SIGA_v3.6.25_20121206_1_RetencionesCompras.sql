
CREATE TABLE RetencionesCompras(
	[IdSucursal] [int] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[EmisorRetencion] [int] NOT NULL,
	[NumeroRetencion] [bigint] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[BaseImponible] [decimal](14, 4) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[ImporteTotal] [decimal](14, 4) NULL,
	[IdCajaIngreso] [int] NULL,
	[NroPlanillaIngreso] [int] NULL,
	[NroMovimientoIngreso] [int] NULL,
	[IdEstado] [varchar](10) NOT NULL,
	[IdRegimen] [int] NULL,
 CONSTRAINT [PK_RetencionesCompras] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RetencionesCompras]  WITH CHECK ADD  CONSTRAINT [FK_RetencionesCompras_CajasDetalle] FOREIGN KEY([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso])
REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento])
GO

ALTER TABLE [dbo].[RetencionesCompras] CHECK CONSTRAINT [FK_RetencionesCompras_CajasDetalle]
GO

ALTER TABLE [dbo].[RetencionesCompras]  WITH CHECK ADD  CONSTRAINT [FK_RetencionesCompras_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[RetencionesCompras] CHECK CONSTRAINT [FK_RetencionesCompras_Proveedores]
GO

ALTER TABLE [dbo].[RetencionesCompras]  WITH CHECK ADD  CONSTRAINT [FK_RetencionesCompras_Regimenes] FOREIGN KEY([IdRegimen])
REFERENCES [dbo].[Regimenes] ([IdRegimen])
GO

ALTER TABLE [dbo].[RetencionesCompras] CHECK CONSTRAINT [FK_RetencionesCompras_Regimenes]
GO

ALTER TABLE [dbo].[RetencionesCompras]  WITH CHECK ADD  CONSTRAINT [FK_RetencionesCompras_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[RetencionesCompras] CHECK CONSTRAINT [FK_RetencionesCompras_Sucursales]
GO

ALTER TABLE [dbo].[RetencionesCompras]  WITH CHECK ADD  CONSTRAINT [FK_RetencionesCompras_TiposImpuestos] FOREIGN KEY([IdTipoImpuesto])
REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
GO

ALTER TABLE [dbo].[RetencionesCompras] CHECK CONSTRAINT [FK_RetencionesCompras_TiposImpuestos]
GO



---------------------
-------------------------
-----------------------------
--------------------------------

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE CuentasCorrientesRetenciones
	DROP CONSTRAINT FK_CuentasCorrientesRetenciones_Retenciones
GO

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE CuentasCorrientesProvRetenciones
	DROP CONSTRAINT FK_CuentasCorrientesProvRetenciones_Retenciones
GO

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE Retenciones
	DROP CONSTRAINT PK_Retenciones_1
GO

---- Cambio los registros a COMPRAS
INSERT INTO RetencionesCompras (
	IdSucursal, IdTipoImpuesto,
	EmisorRetencion,	NumeroRetencion,
	TipoDocProveedor,	NroDocProveedor,
	FechaEmision,	BaseImponible,
	Alicuota,	ImporteTotal,
	IdCajaIngreso,	NroPlanillaIngreso,
	NroMovimientoIngreso,	IdEstado,
	IdRegimen
	)
SELECT 
	IdSucursal,  IdTipoImpuesto,
	EmisorRetencion, NumeroRetencion,
	TipoDocProveedor, NroDocProveedor,
	FechaEmision, BaseImponible,
	Alicuota, ImporteTotal,
	IdCajaIngreso, NroPlanillaIngreso,
	NroMovimientoIngreso, IdEstado,
	IdRegimen
FROM Retenciones where TipoRetencion = 'COMPRA'
GO
----

----ELIMINO las retenciones de compra de la tabla Retenciones
DELETE FROM Retenciones where TipoRetencion = 'COMPRA'
GO


-- Drop a column from the table
ALTER TABLE Retenciones
	DROP COLUMN TipoRetencion
GO

-- Add a new PRIMARY KEY CONSTRAINT to the table
ALTER TABLE Retenciones
  ADD CONSTRAINT PK_Retenciones PRIMARY KEY (
  [IdSucursal] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC
  )
GO

-- Add a new CHECK CONSTRAINT to the table
ALTER TABLE [dbo].[CuentasCorrientesRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones] FOREIGN KEY([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion])
REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion])
GO

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones]
GO

------------------
---------------------------
---------------------------------------
----------------------------------

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE CuentasCorrientesProvRetenciones
	DROP CONSTRAINT PK_CuentasCorrientesProvRetenciones
GO

-- Drop a column from the table
ALTER TABLE CuentasCorrientesProvRetenciones
	DROP COLUMN TipoRetencion
GO

------

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones] FOREIGN KEY([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], TipoDocProveedor, NroDocProveedor)
REFERENCES [dbo].[RetencionesCompras] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], TipoDocProveedor, NroDocProveedor)
GO

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones]
GO
--------------

-- Add a new PRIMARY KEY CONSTRAINT to the table
ALTER TABLE CuentasCorrientesProvRetenciones
  ADD CONSTRAINT PK_CuentasCorrientesProvRetenciones PRIMARY KEY (
[IdSucursal] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC
  )
GO

------------------
---------------------------
---------------------------------------
----------------------------------

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE CuentasCorrientesRetenciones
	DROP CONSTRAINT PK_CuentasCorrientesRetenciones_1
GO

-- Drop a column from the table
ALTER TABLE CuentasCorrientesRetenciones
	DROP COLUMN TipoRetencion
GO

-- Add a new PRIMARY KEY CONSTRAINT to the table
ALTER TABLE CuentasCorrientesRetenciones
  ADD CONSTRAINT PK_CuentasCorrientesRetenciones PRIMARY KEY (
[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC
  )
GO

------------------
---------------------------
---------------------------------------
----------------------------------

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE Retenciones
	DROP CONSTRAINT FK_Retenciones_Proveedores
GO

-- Drop a column from the table
ALTER TABLE Retenciones
	DROP COLUMN TipoDocProveedor, NroDocProveedor
GO


--------------------

-- Inserto las Pantallas Nuevas --

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfRetencionesCompras', 'Inf. Retenciones de Compras', 'Inf. Retenciones de Compras', 'True', 'False', 'True', 'True', 
          'AFIP', 40, 'Eniac.Win', 'InfRetencionesCompras', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT IdRol, 'InfRetencionesCompras' AS Pantalla FROM RolesFunciones
 WHERE IdFuncion='InfRetenciones'
GO